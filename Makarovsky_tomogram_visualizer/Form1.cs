using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;


namespace Makarovsky_tomogram_visualizer
{
  public partial class Form1 : Form
  {
    GLGraphic glGraphics = new GLGraphic();
    public Form1()
    {
      InitializeComponent();
    }

    void Application_Idle(object sender, EventArgs e)
    {
       while (glControl1.IsIdle)
         glControl1.Refresh();
    }

    private void glControl1_Load(object sender, EventArgs e)
    {
      glGraphics.Resize(glControl1.Width, glControl1.Height);
      Application.Idle += Application_Idle;
    }

    private void glControl1_Paint(object sender, PaintEventArgs e)
    {
      int texID = glGraphics.LoadTexture("cat.jpeg");
      glGraphics.texturesIDs.Add(texID);
      glGraphics.Update();
      glControl1.SwapBuffers();
    }

    private void glControl1_MouseMove(object sender, MouseEventArgs e)
    {
      float widthCoef = (e.X - glControl1.Width * 0.5f) / (float)glControl1.Width;
      float heightCoef = (-e.Y + glControl1.Height * 0.5f) / (float)glControl1.Height;
      glGraphics.latitude = (heightCoef * 180);
      glGraphics.longitude = (widthCoef * 360);
      glControl1.Refresh();
    }

    private void glControl1_MouseDown(object sender, MouseEventArgs e)
    {

    }
  }
}
