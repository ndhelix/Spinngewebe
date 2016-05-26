using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Collections;
using bitLineControlProject;

namespace Spinngewebe
{
  public partial class Form1 : Form
  {
    DataTable dt; // all words
    myTextBox[] A;
    List<int> randomweb; //correspondence between left and right part
    List<int> ra; //contains selected (from dt) words for web 
    bool datachanged = false;

    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      dic2dt();
      ShowWeb();
    }
    
    // не показывать слово, если оно выучено
    bool AcceptEntry(DataRow dr)
    {
      bool ret = true;
      int c = 0;
      int w = 0;
      Int32.TryParse(dr["ca"].ToString(), out c);
      Int32.TryParse(dr["wa"].ToString(), out w);
      int m = 1; // set m = 1 for normal
      if (w == 0) return c - w < 3*m;
      if (c - w > 5 * m || c >= w * 3 * m) return false;
      return ret;
    }

    private List<int> GetRandomNumbers(int qty)
    {
      List<int> l = new List<int>();

      Random random = new Random();
      int i = 0;
      do
      {
        int val = random.Next(0, dt.Rows.Count - 1);
        if (!l.Exists(element => element == val))
          if (AcceptEntry(dt.Rows[val]))
            {
              l.Add(val);
              i++;
            }
      }
      while (i <= qty);
      return l;
    }

    private void FormRandomweb(int qty)
    {
      randomweb = new List<int>();
      Random random = new Random();
      int i = 0;
      do
      {
        int val = random.Next(qty );
        if (!randomweb.Exists(element => element == val))
        {
          randomweb.Add(val);
          i++;
        }
      }
      while (i <= qty-1);
    }

    private myTextBox GetWebControl()
    {
      myTextBox control = new myTextBox();
      control.Font = new Font("Tahoma", 12);
      control.ReadOnly = true;
      control.BorderStyle = BorderStyle.None;
      control.WordWrap = true;
      control.Click += new EventHandler(webcontrol_Click);
      control.ContextMenuStrip = CMS_TB;
      return control;
    }

    void webcontrol_Click(object sender, EventArgs e)
    {
      myTextBox mtb = (myTextBox)sender;

      SetHighlights(mtb.Number);

      if (mtb.Connected != -1)
      {
        A[mtb.Connected].Disconnect();
        mtb.Disconnect();
      }
      else
      {
        ConnectIfPossible(mtb.Number);
      }
      Score();
    }

    void Score()
    {
      for (int i = 0; i < A.Length; i++)
        if (A[i].Connected == -1)
          return;
      int score = 0;
      for (int i = 0; i < A.Length / 2; i++)
      {
        int a = 0;
        if (randomweb[i] == A[i].Connected - A.Length / 2)
        {
          score++;
          int.TryParse(dt.Rows[ra[i]]["ca"].ToString(), out a);
          dt.Rows[ra[i]]["ca"] = a + 1;
        }
        else
        {
          int.TryParse(dt.Rows[ra[i]]["wa"].ToString(), out a);
          dt.Rows[ra[i]]["wa"] = a + 1;
        }
        dt.Rows[ra[i]]["la"] = DateTime.Now.ToString();
      }
      //DrawCorrectLines();
      lblResult.Text = string.Format("Result: {0} of {1}", score, A.Length/2);
      datachanged = true;
    }

    void DrawCorrectLines()
    {
      for (int i = 0; i < A.Length / 2; i++)
        A[i].Disconnect();
      for (int i = 0; i < A.Length / 2; i++)
        Connect(i, randomweb[i] + A.Length / 2);
    }

    int Side(int a)
    {
      return a < A.Length / 2 ? 0 : 1;
    }

    bool OnTheSameSide(int a, int b)
    {
      return Side(a) == Side(b);
    }

    void SetHighlights(int number)
    {
      A[number].Selected = !A[number].Selected;
      if (A[number].Selected)
        for (int i = 0; i < A.Length; i++)
          if (OnTheSameSide(number, i))
            if (i != number)
              if (A[i].Connected == -1)
                A[i].Selected = false;
    }

    int OtherSideSelected(int number)
    {
      int ret = -1;
      for (int i = 0; i < A.Length; i++)
        if (!OnTheSameSide(number, i))
          if (A[i].Connected == -1)
            if (A[i].Selected)
              return i;
      return ret;
    }

    int GetX(int a)
    {
      if (Side(a) == 0)
        return A[a].Left + A[a].Width;
      else
        return A[a].Left;
    }
    int GetY(int a)
    {
      return A[a].Top + A[a].Height / 2 ;
    }

    void Connect(int a, int b)
    {
      
      int x1 = GetX(a);
      int x2 = GetX(b);
      int y1 = GetY(a);
      int y2 = GetY(b);

      bitLineControl varbitLine = new bitLineControl(new Point(x1, y1), new Point(x2, y2));
      varbitLine.Name = "Line_" + a.ToString() + "_" + b.ToString() + "_";
      //varbitLine.ForeColor = Color.Red;
      //varbitLine.BackColor = Color.Yellow;
      GBweb.Controls.Add(varbitLine);
      A[a].Connected = b;
      A[b].Connected = a;
      if (Side(a) == 0)
        A[a].Tag = varbitLine;
      else
        A[b].Tag = varbitLine;
    }

    void ConnectIfPossible(int number)
    {
      int othersel = OtherSideSelected(number);
      if (othersel == -1) return;
      Connect(number, othersel);
    }

    private void ShowWeb()
    {
      GBweb.Controls.Clear();
      int qty = (int)numQty.Value;
      ra = GetRandomNumbers(qty);
      A = new myTextBox[qty * 2];
      int ind_y = (GBweb.Height-30) / qty;
      FormRandomweb(qty);
      for (int i = 0; i < qty * 2; i++)
      {
        bool Col1 = qty * 2 / (i + 1) >= 2;
        int x = Col1 ? 15 : GBweb.Width *4/10;
        int y = Col1 ? i * ind_y + 30 : (i - qty) * ind_y + 30;
        A[i] = GetWebControl();
        A[i].Number = i;
        A[i].Location = new System.Drawing.Point(x, y);
//        A[i].Width = GBweb.Width / 2 - 20;

//        buttonArray[i].Text = "Text " + i.ToString();
        GBweb.Controls.Add(A[i]);

        string field = Col1 ? "from" : "to";
        int j = Col1 ? i : RandomwebPos(i - qty);
        A[i].Text = dt.Rows[ra[j]].Field<string>(field);
        Graphics g = Graphics.FromHwnd(A[i].Handle);
        SizeF f = g.MeasureString(A[i].Text, A[i].Font);
        A[i].Width = (int)(f.Width);
      }

    }

    private int RandomwebPos(int a)
    {
      int b = 0;
      foreach (int i in randomweb)
      {
        if (i == a)
          return b;
        b++;
      }
      return -1;
    }

    private void dic2dt()
    {
      dt = new DataTable();
      dt.Columns.Add("d", typeof(int)); // direction - направление перевода
      dt.Columns.Add("from", typeof(string));
      dt.Columns.Add("to", typeof(string));
      dt.Columns.Add("ca", typeof(int)); // correct answers
      dt.Columns.Add("wa", typeof(int)); // wrong answers
      dt.Columns.Add("la", typeof(DateTime)); //last answer datetime

      String[] csvData = File.ReadAllLines(ConfigurationSettings.AppSettings["DictFilename"]);
      try
      {
        for (int i = 0; i < csvData.Length; i++)
        {
          //create new rows
          DataRow row = dt.NewRow();
          for (int j = 0; j < csvData[i].Split('\t').Length; j++)
          {
            if (csvData[i].Split('\t')[j].Trim() != "")
              row[j] = csvData[i].Split('\t')[j];
          }
          //add rows to over DataTable
          dt.Rows.Add(row);
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void btnGo_Click(object sender, EventArgs e)
    {
      lblResult.Text = "";
      ShowWeb();
    }

    private void GBcontrol_Enter(object sender, EventArgs e)
    {
      //DrawCorrectLines();
    }

    private void btnSaveDic_Click(object sender, EventArgs e)
    {
      dt2dic();
    }

    void dt2dic()
    {
      StreamWriter sw = new StreamWriter(ConfigurationSettings.AppSettings["DictFilename"], false);
      foreach (DataRow dr in dt.Rows)
      {
        string[] dataArr = dr.ItemArray.Select(c => c.ToString()).ToArray();
        sw.WriteLine(String.Join("\t", dataArr));
      }
      sw.Close();
      datachanged = false;
    }

    private void btnShowAnswer_Click(object sender, EventArgs e)
    {
      DrawCorrectLines();
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (!datachanged) return;
      DialogResult dlg = MessageBox.Show("Save changes?", "Question", MessageBoxButtons.YesNo);
      if (dlg == DialogResult.Yes)
      {
        dt2dic();
      }
    }

    private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
      ContextMenuStrip cms = (ContextMenuStrip)tsmi.Owner;
      //DataBindings db =  TDBG_elm.DataBindings[0];
      myTextBox mtb = (myTextBox)cms.SourceControl;
      dt.Rows[ra[mtb.Number]].Delete();
      dt2dic();
    }

  }
}
