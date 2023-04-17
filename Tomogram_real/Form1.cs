using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Tomogram_real
{
  public partial class Form1 : Form
  {
    Bin bin = new Bin();
    View view = new View();
    bool loaded = false;
    bool needReload = true;
    int currentLayer = 0;
    int FrameCount;
    DateTime NextFPSUpdate = DateTime.Now.AddSeconds(1);

    public Form1()
    {
      InitializeComponent(); 
    }
    private void Form1_Load(object sender, EventArgs e)
    {
      Application.Idle += Application_Idle;
    }

    private void glControl1_Load(object sender, EventArgs e)
    {

    }

    private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      if (openFileDialog.ShowDialog() == DialogResult.OK)
      {
        string str = openFileDialog.FileName;
        bin.readBin(str);
        view.SetupVeiw(glControl1.Width, glControl1.Height);
        loaded = true;
        trackBar1.Maximum = bin.LayerSize() - 1;
        glControl1.Invalidate();
      }
    }

    private void glControl1_Paint(object sender, PaintEventArgs e)
    {
      if (loaded) 
      {
        if (radioButton2.Checked)
        {
          if (needReload)
          {
            view.generateTextureImage(currentLayer);
            view.Load2DTexture();
            needReload = false;
          }
          view.DrawTexture();
        }
        else
        {
          view.DrawQuad(currentLayer);
        }
        glControl1.SwapBuffers(); 
      }
    }

    private void trackBar1_Scroll(object sender, EventArgs e)
    {
      currentLayer = trackBar1.Value;
      needReload = true;
      glControl1.Refresh();
    }

    private void Application_Idle(object sender, EventArgs e)
    {
      while(glControl1.IsIdle)
      {
        displayFPS();
        glControl1.Invalidate();
      }
    }

    private void displayFPS()
    {
      if (DateTime.Now >= NextFPSUpdate)
      {
        this.Text = String.Format("CT Visualizer (fps = {0})", FrameCount);
        NextFPSUpdate = DateTime.Now.AddSeconds(1);
        FrameCount = 0;
      }
      ++FrameCount;
    }

  }
}
