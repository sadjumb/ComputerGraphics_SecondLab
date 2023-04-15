﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;


namespace Makarovsky_tomogram_visualizer
{
  internal class GLGraphic
  {
    Vector3 cameraPosition = new Vector3(2, 3, 4);
    Vector3 cameraDirecton = new Vector3(0, 0, 0);
    Vector3 cameraUp = new Vector3(0, 0, 1);
    public float latitude = 47.98f;
    public float longitude = 60.41f;
    public float radius = 5.385f;


    public GLGraphic() { }
    public void Init() { }
    public void Resize(int width, int height)
    {
      GL.ClearColor(Color.DarkGray);
      GL.ShadeModel(ShadingModel.Smooth);
      GL.Enable(EnableCap.DepthTest);
      Matrix4 perspectiveMat = Matrix4.CreatePerspectiveFieldOfView(
                MathHelper.PiOver4,
                width / (float)height,
                1,
                64);
      GL.MatrixMode(MatrixMode.Projection);

      GL.LoadMatrix(ref perspectiveMat);
    }

    public void Update()
    {
      cameraPosition = new Vector3( (float)(radius * Math.Cos(Math.PI / 180.0f * latitude) * Math.Cos(Math.PI / 180.0f * longitude)),
                                    (float)(radius * Math.Cos(Math.PI / 180.0f * latitude) * Math.Sin(Math.PI / 180.0f * longitude)),
                                    (float)(radius * Math.Sin(Math.PI / 180.0f * latitude)) );

      GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
      Matrix4 viewMat = Matrix4.LookAt(cameraPosition, cameraDirecton, cameraUp);
      GL.MatrixMode(MatrixMode.Modelview);
      GL.LoadMatrix(ref viewMat);
      Render();


    }

    private void drawTestQuad()
    {
      GL.Begin(PrimitiveType.Quads);
      GL.Color3(Color.Blue);
      GL.Vertex3(-1.0f, -1.0f, -1.0f);
      GL.Color3(Color.Red);
      GL.Vertex3(-1.0f, 1.0f, -1.0f);
      GL.Color3(Color.White);
      GL.Vertex3(1.0f, 1.0f, -1.0f);
      GL.Color3(Color.Green);
      GL.Vertex3(1.0f, -1.0f, -1.0f);
      GL.End();
    }

    public void Render()
    {
      drawTestQuad();
      GL.PushMatrix();
      GL.Translate(1, 1, 1);
      GL.Rotate(45, Vector3.UnitZ);
      GL.Scale(0.5f, 0.5f, 0.5f);
      drawTestQuad();
      GL.PopMatrix();

    }
    void Application_Idle(object sender, EventArgs e)
    {
      while (glControl1.IsIdle)
        glControl1.Refresh();
    }


}
}
