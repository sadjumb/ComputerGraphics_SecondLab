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
    private int mousePosX;
    private int mousePosY;
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
      int texID = glGraphics.LoadTexture("cat.jpeg");
      glGraphics.texturesIDs.Add(texID);
      texID = glGraphics.LoadTexture("Cats_2.jpg");
      glGraphics.texturesIDs.Add(texID);
      texID = glGraphics.LoadTexture("Cats_3.jpg");
      glGraphics.texturesIDs.Add(texID);
      texID = glGraphics.LoadTexture("Cats_4.jpeg");
      glGraphics.texturesIDs.Add(texID);
      texID = glGraphics.LoadTexture("Cats_5.jpg");
      glGraphics.texturesIDs.Add(texID);
      texID = glGraphics.LoadTexture("Cats_6.jpeg");
      glGraphics.texturesIDs.Add(texID);


      glGraphics.Resize(glControl1.Width, glControl1.Height);
      Application.Idle += Application_Idle;
    }

    private void glControl1_Paint(object sender, PaintEventArgs e)
    {
      glGraphics.Update();
      glControl1.SwapBuffers();
    }

    private void glControl1_MouseMove(object sender, MouseEventArgs e)
    {
      mousePosX = e.X;
      mousePosY = e.Y;
      float widthCoef = (mousePosX - glControl1.Width * 0.5f) / (float)glControl1.Width;
      float heightCoef = (-mousePosY + glControl1.Height * 0.5f) / (float)glControl1.Height;
      glGraphics.latitude = (heightCoef * 180);
      glGraphics.longitude = (widthCoef * 360);
      glControl1.Refresh();
    }

    private void glControl1_MouseDown(object sender, MouseEventArgs e)
    {

    }


  }
}
