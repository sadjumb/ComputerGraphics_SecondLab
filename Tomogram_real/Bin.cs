using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomogram_real
{
  internal class Bin
  {
    public static int X, Y, Z;
    public static short[] array;

    public Bin() { }

    public void readBin(string path)
    {
      if (File.Exists(path))
      {
        BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open));
        X = reader.ReadInt16();
        Y = reader.ReadInt16();
        Z = reader.ReadInt16();

        int arraySize = X * Y * Z;
        for (int i = 0; i < arraySize; ++i)
        {
          array[i] = reader.ReadInt16();
        }
      }
    }

    public int LayerSize()
    {
      return Z;
    }
  }
}
