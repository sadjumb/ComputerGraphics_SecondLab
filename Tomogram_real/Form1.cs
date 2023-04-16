using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tomogram_real
{
  public partial class Form1 : Form
  {
    Bin bin = new Bin();
    View view = new View();
    bool loaded = false;
    int currentLayer = 15;
    public Form1()
    {
      InitializeComponent(); 
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
        glControl1.Invalidate();
      }
    }

    private void glControl1_Paint(object sender, PaintEventArgs e)
    {
      if (loaded) 
      {
        view.DrawQuad(currentLayer);
        glControl1.SwapBuffers();
        trackBar1.Maximum = bin.LayerSize();
      }
    }

    private void trackBar1_Scroll(object sender, EventArgs e)
    {
      currentLayer = trackBar1.Value;
    }
  }
}
