namespace Spinngewebe
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.GBweb = new System.Windows.Forms.GroupBox();
      this.GBcontrol = new System.Windows.Forms.GroupBox();
      this.btnSaveDic = new System.Windows.Forms.Button();
      this.btnShowAnswer = new System.Windows.Forms.Button();
      this.lblResult = new System.Windows.Forms.Label();
      this.btnGo = new System.Windows.Forms.Button();
      this.numQty = new System.Windows.Forms.NumericUpDown();
      this.label1 = new System.Windows.Forms.Label();
      this.CMS_TB = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.GBcontrol.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numQty)).BeginInit();
      this.CMS_TB.SuspendLayout();
      this.SuspendLayout();
      // 
      // GBweb
      // 
      this.GBweb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.GBweb.Location = new System.Drawing.Point(12, 12);
      this.GBweb.Name = "GBweb";
      this.GBweb.Size = new System.Drawing.Size(952, 652);
      this.GBweb.TabIndex = 0;
      this.GBweb.TabStop = false;
      // 
      // GBcontrol
      // 
      this.GBcontrol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.GBcontrol.Controls.Add(this.btnSaveDic);
      this.GBcontrol.Controls.Add(this.btnShowAnswer);
      this.GBcontrol.Controls.Add(this.lblResult);
      this.GBcontrol.Controls.Add(this.btnGo);
      this.GBcontrol.Controls.Add(this.numQty);
      this.GBcontrol.Controls.Add(this.label1);
      this.GBcontrol.Location = new System.Drawing.Point(12, 670);
      this.GBcontrol.Name = "GBcontrol";
      this.GBcontrol.Size = new System.Drawing.Size(952, 68);
      this.GBcontrol.TabIndex = 1;
      this.GBcontrol.TabStop = false;
      this.GBcontrol.Enter += new System.EventHandler(this.GBcontrol_Enter);
      // 
      // btnSaveDic
      // 
      this.btnSaveDic.Location = new System.Drawing.Point(588, 25);
      this.btnSaveDic.Name = "btnSaveDic";
      this.btnSaveDic.Size = new System.Drawing.Size(120, 23);
      this.btnSaveDic.TabIndex = 5;
      this.btnSaveDic.Text = "Save Dictionary";
      this.btnSaveDic.UseVisualStyleBackColor = true;
      this.btnSaveDic.Click += new System.EventHandler(this.btnSaveDic_Click);
      // 
      // btnShowAnswer
      // 
      this.btnShowAnswer.Location = new System.Drawing.Point(444, 25);
      this.btnShowAnswer.Name = "btnShowAnswer";
      this.btnShowAnswer.Size = new System.Drawing.Size(123, 23);
      this.btnShowAnswer.TabIndex = 4;
      this.btnShowAnswer.Text = "Show Answer";
      this.btnShowAnswer.UseVisualStyleBackColor = true;
      this.btnShowAnswer.Click += new System.EventHandler(this.btnShowAnswer_Click);
      // 
      // lblResult
      // 
      this.lblResult.AutoSize = true;
      this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblResult.Location = new System.Drawing.Point(249, 23);
      this.lblResult.Name = "lblResult";
      this.lblResult.Size = new System.Drawing.Size(66, 25);
      this.lblResult.TabIndex = 3;
      this.lblResult.Text = "Result";
      // 
      // btnGo
      // 
      this.btnGo.Location = new System.Drawing.Point(122, 21);
      this.btnGo.Name = "btnGo";
      this.btnGo.Size = new System.Drawing.Size(75, 32);
      this.btnGo.TabIndex = 2;
      this.btnGo.Text = "&Go!";
      this.btnGo.UseVisualStyleBackColor = true;
      this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
      // 
      // numQty
      // 
      this.numQty.Location = new System.Drawing.Point(55, 21);
      this.numQty.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
      this.numQty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.numQty.Name = "numQty";
      this.numQty.Size = new System.Drawing.Size(45, 22);
      this.numQty.TabIndex = 1;
      this.numQty.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(19, 23);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(30, 17);
      this.label1.TabIndex = 0;
      this.label1.Text = "Qty";
      // 
      // CMS_TB
      // 
      this.CMS_TB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
      this.CMS_TB.Name = "CMS_TB";
      this.CMS_TB.Size = new System.Drawing.Size(119, 26);
      // 
      // deleteToolStripMenuItem
      // 
      this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
      this.deleteToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
      this.deleteToolStripMenuItem.Text = "Delete";
      this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(976, 750);
      this.Controls.Add(this.GBcontrol);
      this.Controls.Add(this.GBweb);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Form1";
      this.Text = "Spinngewebe";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      this.GBcontrol.ResumeLayout(false);
      this.GBcontrol.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numQty)).EndInit();
      this.CMS_TB.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox GBweb;
    private System.Windows.Forms.GroupBox GBcontrol;
    private System.Windows.Forms.NumericUpDown numQty;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnGo;
    private System.Windows.Forms.Label lblResult;
    private System.Windows.Forms.Button btnShowAnswer;
    private System.Windows.Forms.Button btnSaveDic;
    private System.Windows.Forms.ContextMenuStrip CMS_TB;
    private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
  }
}

