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
    public float rotateSpeed = 0.0001f;
    public float radiusMove = 3f;


    public GLGraphic() { }
    public void Init()
    {
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
      rotateAngle += rotateSpeed;
      Render();
    }

    public void Render()
    {

      //  1
      //drawTestQuad();
      //
      //GL.PushMatrix();
      //GL.Translate(radiusMove * Math.Cos(rotateAngle), radiusMove * Math.Sin(rotateAngle), 0);
      //GL.Rotate(rotateAngle, Vector3.UnitZ);
      //GL.Scale(0.5f, 0.5f, 0.5f);
      //drawTestQuad();
      //GL.PopMatrix();

      //  2
      //GL.PushMatrix();
      //GL.Translate(1, 1, 1);
      ////GL.Rotate(rotateAngle, Vector3.UnitZ);
      ////GL.Scale(0.5f, 0.5f, 0.5f);
      //drawTextureQuad();
      //GL.PopMatrix();

      //  3
      //GL.Color3(Color.BlueViolet);
      //drawSphere(1.0f, 20, 20);

      // 4
      //drawPoint();

      // 5
      //drawLineLoop();

      // 6
      //drawTriangle();

      // 7
      //drawTriangleStrip();

      // 8
      //drawTriangleFan();

      // 9
      //drawCube();

      // 10, 11
      //GL.PushMatrix();
      //GL.Translate(radiusMove * Math.Cos(rotateAngle), radiusMove * Math.Sin(rotateAngle), 0);
      //drawTextureCube();
      //GL.PopMatrix();

      // 12 light
      drawTextureCube();

    }

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
      SetupLightning();
    }

    private void SetupLightning()
    {
      SetupLightning0();
      SetupLightning1();
    }

    private void SetupLightning0()
    {
      GL.Enable(EnableCap.Lighting);
      GL.Enable(EnableCap.Light0);
      GL.Enable(EnableCap.ColorMaterial);

      Vector4 lightPosition = new Vector4(0.0f, 7.0f, 1.0f, 0.0f);
      GL.Light(LightName.Light0, LightParameter.Position, lightPosition);

      Vector4 ambientColor = new Vector4(0.2f, 0.2f, 0.2f, 1.0f);
      GL.Light(LightName.Light0, LightParameter.Ambient, ambientColor);

      Vector4 diffuseColor = new Vector4(0.6f, 0.6f, 0.6f, 1.0f);
      GL.Light(LightName.Light0, LightParameter.Diffuse, diffuseColor);

      Vector4 materialSpecular = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
      GL.Material(MaterialFace.Front, MaterialParameter.Specular, materialSpecular);
      float materialShininess = 100;
      GL.Material(MaterialFace.Front, MaterialParameter.Shininess, materialShininess);
    }

    private void SetupLightning1()
    {
      GL.Enable(EnableCap.Lighting);
      GL.Enable(EnableCap.Light1);
      GL.Enable(EnableCap.ColorMaterial);

      Vector4 lightPosition = new Vector4(7.0f, 7.0f, 1.0f, 0.0f);
      GL.Light(LightName.Light1, LightParameter.Position, lightPosition);

      Vector4 ambientColor = new Vector4(25f, 15f, 240f, 1.0f);
      GL.Light(LightName.Light1, LightParameter.Ambient, ambientColor);

      Vector4 diffuseColor = new Vector4(0.7f, 0.7f, 0.7f, 1.0f);
      GL.Light(LightName.Light1, LightParameter.Diffuse, diffuseColor);

      Vector4 materialSpecular = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
      GL.Material(MaterialFace.Front, MaterialParameter.Specular, materialSpecular);
      float materialShininess = 100;
      GL.Material(MaterialFace.Front, MaterialParameter.Shininess, materialShininess);
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

      GL.Color3(Color.White);
      GL.TexCoord2(0.0, 0.0);
      GL.Vertex3(-1.0f, -1.0f, -1.0f);

      GL.Color3(Color.White);
      GL.TexCoord2(0.0, 1.0);
      GL.Vertex3(-1.0f, 1.0f, -1.0f);

      GL.Color3(Color.White);
      GL.TexCoord2(1.0, 1.0);
      GL.Vertex3(1.0f, 1.0f, -1.0f);

      GL.Color3(Color.White);
      GL.TexCoord2(1.0, 0.0); 
      GL.Vertex3(1.0f, -1.0f, -1.0f);
      
      GL.End();
      GL.Disable(EnableCap.Texture2D);
    }

    private void drawSphere(double r, int nx, int ny)
    {
      int ix, iy;
      double x, y, z;
      for (iy = 0; iy < ny; ++iy)
      {
        GL.Begin(PrimitiveType.QuadStrip);
        for (ix = 0; ix <= nx; ++ix)
        {
          x = r * Math.Sin(iy * Math.PI / ny) * Math.Cos(2 * ix * Math.PI / nx);
          y = r * Math.Sin(iy * Math.PI / ny) * Math.Sin(2 * ix * Math.PI / nx);
          z = r * Math.Cos(iy * Math.PI / ny);
          GL.Normal3(x, y, z);
          GL.Vertex3(x, y, z);

          x = r * Math.Sin((iy + 1) * Math.PI / ny) * Math.Cos(2 * ix * Math.PI / nx);
          y = r * Math.Sin((iy + 1) * Math.PI / ny) * Math.Sin(2 * ix * Math.PI / nx);
          z = r * Math.Cos((iy + 1) * Math.PI / ny);
          GL.Normal3(x, y, z);
          GL.Vertex3(x, y, z);
        }
        GL.End();
      }
    }

    // New TT: 1)draw: Poin, Line, Triangle, TriangleStrip, TriangleFan 
    private void drawPoint()
    {
      GL.PointSize(10f);
      GL.Begin(PrimitiveType.Points);
      
      GL.Vertex2(1.0f, 1.0f);
      GL.Color3(Color.Black);
      GL.End();
    }

    private void drawLineLoop()
    {
      GL.LineWidth(5);
      GL.Begin(PrimitiveType.LineLoop);

      GL.Color3(Color.Blue);
      GL.Vertex2(1.0f, 1.0f);

      GL.Color3(Color.Orange);
      GL.Vertex2(2.0f, 2.0f);

      GL.Color3(Color.Yellow);
      GL.Vertex2(3, 1);

      GL.Color3(Color.Green);
      GL.Vertex2(2, 0);

      GL.End();
    }

    private void drawTriangle()
    {
      GL.Begin(PrimitiveType.Triangles);

      GL.Color3(Color.Red);
      GL.Vertex2(-1.0f, -1.0f);

      GL.Color3(Color.Green);
      GL.Vertex2(2f, 2f);

      GL.Color3(Color.Blue);
      GL.Vertex2(4f, -1f);

      GL.End();
      
    }

    private void drawTriangleStrip()
    {
      GL.Begin(PrimitiveType.TriangleStrip);

      GL.Color3(Color.Red);
      GL.Vertex2(-1.0f, -1.0f);

      GL.Color3(Color.Green);
      GL.Vertex2(2f, 2f);

      GL.Color3(Color.Blue);
      GL.Vertex2(4f, -1f);

      GL.Color3(Color.Yellow);
      GL.Vertex3(3f, 3f, 3f);

      GL.End();
    }

    private void drawTriangleFan()
    {
      GL.Begin(PrimitiveType.TriangleFan);

      GL.Color3(Color.Red);
      GL.Vertex2(-1.0f, -1.0f);

      GL.Color3(Color.Green);
      GL.Vertex2(2f, 2f);

      GL.Color3(Color.Blue);
      GL.Vertex2(4f, -1f);

      GL.Color3(Color.Yellow);
      GL.Vertex3(3f, 3f, 3f);

      GL.End();
    }


    // 2) Create function Cube, with other texture in all 
    private void drawCube()
    {
      GL.Begin(PrimitiveType.QuadStrip);

      GL.Color3(Color.Red);
      GL.Vertex3(0f, 0f, 0f);

      GL.Color3(Color.Green);
      GL.Vertex3(0, 0, 1f);

      GL.Color3(Color.Yellow);
      GL.Vertex3(0, 1, 0f);

      GL.Color3(Color.Blue);
      GL.Vertex3(0, 1, 1f);

      GL.Color3(Color.Purple);
      GL.Vertex3(1, 1, 0f);

      GL.Color3(Color.RosyBrown);
      GL.Vertex3(1, 1, 1f);

      GL.Color3(Color.Yellow);
      GL.Vertex3(1, 0, 0f);

      GL.Color3(Color.Yellow);
      GL.Vertex3(1, 0, 1f);

      GL.Color3(Color.Green);
      GL.Vertex3(0, 0, 0f);
      
      GL.Color3(Color.Blue);
      GL.Vertex3(0, 0, 1f);

      GL.End();


      GL.Begin(PrimitiveType.Quads);

      GL.Color3(Color.Yellow);
      GL.Vertex3(0, 0, 0f);

      GL.Color3(Color.Yellow);
      GL.Vertex3(1, 0, 0f);

      GL.Color3(Color.Green);
      GL.Vertex3(1, 1, 0f);

      GL.Color3(Color.Blue);
      GL.Vertex3(0, 1, 0f);

      GL.End();


      GL.Begin(PrimitiveType.Quads);

      GL.Color3(Color.Yellow);
      GL.Vertex3(0, 0, 1f);

      GL.Color3(Color.Yellow);
      GL.Vertex3(0, 1, 1f);

      GL.Color3(Color.Green);
      GL.Vertex3(1, 1, 1f);

      GL.Color3(Color.Blue);
      GL.Vertex3(1, 0, 1f);

      GL.End();
    }

    private void drawTextureCube()
    {
      GL.Enable(EnableCap.Texture2D);

      GL.BindTexture(TextureTarget.Texture2D, texturesIDs[0]);
      GL.Begin(PrimitiveType.Quads);
      GL.Color3(Color.White);
      GL.TexCoord2(0.0, 0.0);
      GL.Vertex3(0, 0, 0f);

      GL.Color3(Color.White);
      GL.TexCoord2(0.0, 1.0);
      GL.Vertex3(2, 0, 0f);

      GL.Color3(Color.White);
      GL.TexCoord2(1.0, 1.0);
      GL.Vertex3(2, 2, 0f);

      GL.Color3(Color.White);
      GL.TexCoord2(1.0, 0.0);
      GL.Vertex3(0, 2, 0f);
      GL.End();

      GL.BindTexture(TextureTarget.Texture2D, texturesIDs[1]);
      GL.Begin(PrimitiveType.Quads);
      GL.Color3(Color.White);
      GL.TexCoord2(0.0, 0.0);
      GL.Vertex3(0, 0, 2f);

      GL.Color3(Color.White);
      GL.TexCoord2(0.0, 1.0);
      GL.Vertex3(0, 0, 0f);

      GL.Color3(Color.White);
      GL.TexCoord2(1.0, 1.0);
      GL.Vertex3(0, 2, 0f);

      GL.Color3(Color.White);
      GL.TexCoord2(1.0, 0.0);
      GL.Vertex3(0, 2, 2f);
      GL.End();

      GL.BindTexture(TextureTarget.Texture2D, texturesIDs[2]);
      GL.Begin(PrimitiveType.Quads);
      GL.Color3(Color.White);
      GL.TexCoord2(0.0, 0.0);
      GL.Vertex3(0, 2, 2f);

      GL.Color3(Color.White);
      GL.TexCoord2(0.0, 1.0);
      GL.Vertex3(0, 0, 2f);

      GL.Color3(Color.White);
      GL.TexCoord2(1.0, 1.0);
      GL.Vertex3(2, 0, 2f);

      GL.Color3(Color.White);
      GL.TexCoord2(1.0, 0.0);
      GL.Vertex3(2, 2, 2f);
      GL.End();

      GL.BindTexture(TextureTarget.Texture2D, texturesIDs[3]);
      GL.Begin(PrimitiveType.Quads);
      GL.Color3(Color.White);
      GL.TexCoord2(0.0, 0.0);
      GL.Vertex3(2, 2, 2f);

      GL.Color3(Color.White);
      GL.TexCoord2(0.0, 1.0);
      GL.Vertex3(2, 2, 0f);

      GL.Color3(Color.White);
      GL.TexCoord2(1.0, 1.0);
      GL.Vertex3(2, 0, 0f);

      GL.Color3(Color.White);
      GL.TexCoord2(1.0, 0.0);
      GL.Vertex3(2, 0, 2f);
      GL.End();

      GL.BindTexture(TextureTarget.Texture2D, texturesIDs[4]);
      GL.Begin(PrimitiveType.Quads);
      GL.Color3(Color.White);
      GL.TexCoord2(0.0, 0.0);
      GL.Vertex3(0, 2, 2f);

      GL.Color3(Color.White);
      GL.TexCoord2(0.0, 1.0);
      GL.Vertex3(0, 2, 0f);

      GL.Color3(Color.White);
      GL.TexCoord2(1.0, 1.0);
      GL.Vertex3(2, 2, 0f);

      GL.Color3(Color.White);
      GL.TexCoord2(1.0, 0.0);
      GL.Vertex3(2, 2, 2f);
      GL.End();

      GL.BindTexture(TextureTarget.Texture2D, texturesIDs[5]);
      GL.Begin(PrimitiveType.Quads);
      GL.Color3(Color.White);
      GL.TexCoord2(0.0, 0.0);
      GL.Vertex3(0, 0, 2f);

      GL.Color3(Color.White);
      GL.TexCoord2(0.0, 1.0);
      GL.Vertex3(0, 0, 0f);

      GL.Color3(Color.White);
      GL.TexCoord2(1.0, 1.0);
      GL.Vertex3(2, 0, 0f);

      GL.Color3(Color.White);
      GL.TexCoord2(1.0, 0.0);
      GL.Vertex3(2, 0, 2f);
      GL.End();

      GL.Disable(EnableCap.Texture2D);
    }

  }
}
