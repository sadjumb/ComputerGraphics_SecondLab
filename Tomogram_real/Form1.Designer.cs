﻿namespace Tomogram_real
{
  partial class Form1
  {
    /// <summary>
    /// Обязательная переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
      this.glControl1 = new OpenTK.GLControl();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.trackBar1 = new System.Windows.Forms.TrackBar();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.radioButton1 = new System.Windows.Forms.RadioButton();
      this.radioButton2 = new System.Windows.Forms.RadioButton();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // glControl1
      // 
      this.glControl1.BackColor = System.Drawing.Color.Black;
      this.glControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.glControl1.Location = new System.Drawing.Point(0, 0);
      this.glControl1.Name = "glControl1";
      this.glControl1.Size = new System.Drawing.Size(1573, 908);
      this.glControl1.TabIndex = 2;
      this.glControl1.VSync = false;
      this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
      this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl1_Paint);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.radioButton2);
      this.groupBox1.Controls.Add(this.radioButton1);
      this.groupBox1.Controls.Add(this.trackBar1);
      this.groupBox1.Controls.Add(this.menuStrip1);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
      this.groupBox1.Location = new System.Drawing.Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(1573, 81);
      this.groupBox1.TabIndex = 3;
      this.groupBox1.TabStop = false;
      // 
      // trackBar1
      // 
      this.trackBar1.Location = new System.Drawing.Point(97, 36);
      this.trackBar1.Name = "trackBar1";
      this.trackBar1.Size = new System.Drawing.Size(1211, 45);
      this.trackBar1.TabIndex = 1;
      this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(3, 16);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(1567, 24);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // openFileToolStripMenuItem
      // 
      this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
      this.openFileToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
      this.openFileToolStripMenuItem.Text = "Open file";
      this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
      // 
      // radioButton1
      // 
      this.radioButton1.AutoSize = true;
      this.radioButton1.Location = new System.Drawing.Point(1314, 43);
      this.radioButton1.Name = "radioButton1";
      this.radioButton1.Size = new System.Drawing.Size(56, 17);
      this.radioButton1.TabIndex = 2;
      this.radioButton1.TabStop = true;
      this.radioButton1.Text = "Quads";
      this.radioButton1.UseVisualStyleBackColor = true;
      // 
      // radioButton2
      // 
      this.radioButton2.AutoSize = true;
      this.radioButton2.Location = new System.Drawing.Point(1405, 43);
      this.radioButton2.Name = "radioButton2";
      this.radioButton2.Size = new System.Drawing.Size(61, 17);
      this.radioButton2.TabIndex = 3;
      this.radioButton2.TabStop = true;
      this.radioButton2.Text = "Texture";
      this.radioButton2.UseVisualStyleBackColor = true;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1573, 908);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.glControl1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private OpenTK.GLControl glControl1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
    private System.Windows.Forms.TrackBar trackBar1;
    private System.Windows.Forms.RadioButton radioButton2;
    private System.Windows.Forms.RadioButton radioButton1;
  }
}

