using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;


namespace Makarovsky_tomogram_visualizer
{
  internal class GLGraphic
  {
    public List<int> texturesIDs = new List<int>();
    Vector3 cameraPosition = new Vector3(2, 3, 4);
    Vector3 cameraDirecton = new Vector3(0, 0, 0);
    Vector3 cameraUp = new Vector3(0, 0, 1);
    public float latitude = 47.98f;
    public float longitude = 60.41f;
    public float radius = 5.385f;
    public float rotateAngle = 0.0f;


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

    public int LoadTexture(String filePath)
    {
      try
      {
        Bitmap image = new Bitmap(filePath);
        int texID = GL.GenTexture();
        GL.BindTexture(TextureTarget.Texture2D, texID);
        BitmapData data = image.LockBits(
            new System.Drawing.Rectangle(0, 0, image.Width, image.Height),
            ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        GL.TexImage2D(TextureTarget.Texture2D, 0,
            PixelInternalFormat.Rgba, data.Width, data.Height, 0,
            OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
        image.UnlockBits(data);
        GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
        return texID;
      }
      catch (System.IO.FileNotFoundException е)
      {
        return -1;
      }
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
      rotateAngle += 0.05f;
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

    private void drawTextureQuad()
    {
      GL.Enable(EnableCap.Texture2D);
      GL.BindTexture(TextureTarget.Texture2D, texturesIDs[0]);
      GL.Begin(PrimitiveType.Quads);
      GL.Color3(Color.Blue);
      GL.TexCoord2(0.0, 0.0);
      GL.Vertex3(-1.0f, -1.0f, -1.0f);
      GL.Color3(Color.Red);
      GL.TexCoord2(0.0, 1.0);
      GL.Vertex3(-1.0f, 1.0f, -1.0f);
      GL.Color3(Color.White);
      GL.TexCoord2(1.0, 1.0);
      GL.Vertex3(1.0f, 1.0f, -1.0f);
      GL.Color3(Color.Green);
      GL.TexCoord2(1.0, 0.0);
      GL.Vertex3(1.0f, -1.0f, -1.0f);
      GL.End();
      GL.Disable(EnableCap.Texture2D);
    }

    public void Render()
    {
      drawTestQuad();
      GL.PushMatrix();
      GL.Translate(1, 1, 1);
      GL.Rotate(rotateAngle, Vector3.UnitZ);
      GL.Scale(0.5f, 0.5f, 0.5f);
      drawTestQuad();
      GL.PopMatrix();

      GL.PushMatrix();
      GL.Translate(3, 3, 2);
      GL.Rotate(rotateAngle, Vector3.UnitZ);
      GL.Scale(0.5f, 0.5f, 0.5f);
      drawTextureQuad();
      GL.PopMatrix();

    }
}
}
