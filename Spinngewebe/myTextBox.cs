using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;

namespace Spinngewebe
{
  class myTextBox:TextBox
  {
    private bool selected = false;
    public bool Selected
    {
      set 
      {
        if (value)
        {
          this.BackColor = System.Drawing.SystemColors.InfoText;
          this.ForeColor = System.Drawing.SystemColors.ScrollBar;
        }
        else
        {
          this.BackColor = System.Drawing.SystemColors.Window;
          this.ForeColor = System.Drawing.SystemColors.WindowText;
        }
        selected = value; 
      }
      get { return selected; }
    }

    private int connected = -1;
    public int Connected
    {
      set { connected = value; }
      get { return connected; }
    }

    private int number = -1;
    public int Number
    {
      set { number = value; }
      get { return number; }
    }

    public void Disconnect()
    {
      this.Selected = false;
      this.connected = -1;
      if (this.Tag != null)
      {
        this.Parent.Controls.Remove((Control)this.Tag);
        this.Tag = null;
      }
    }
  }
}
