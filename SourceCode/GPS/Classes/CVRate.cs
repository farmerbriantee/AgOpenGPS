using System;
using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public class CMapPt
    {
        public double easting { get; set; }
        public double northing { get; set; }
        public int blu { get; set; }
        public int grn { get; set; }
        public int red { get; set; }

        //constructor
        public CMapPt(double _easting, double _northing, int _blu, int _grn, int _red)
        {
            easting = _easting;
            northing = _northing;
            blu = _blu;
            grn = _grn;
            red = _red;
        }
    }

    public class CVRate
    {
        private readonly FormGPS mf;
        public List<CMapPt> mapList;
        public bool isVRateSet;
        public int bmpWidth, bmpHeight;

        //vec3[,] gridArr = new vec3[1, 1];

        public CVRate(FormGPS _f)
        {
            mf = _f;
            mapList = new List<CMapPt>();
            isVRateSet = false;
            bmpHeight = 0;
            bmpWidth = 0;
        }

    public void BuildRateMap()
        {
            // Create bitmap.
            isVRateSet = false;

            string fileAndDirectory = mf.fieldsDirectory + mf.currentFieldDirectory + "\\Background.JPG";
            if (!File.Exists(fileAndDirectory)) return;

            //create a bitmap mage from the jpeg
            using (Bitmap bmpRate = (Bitmap)Image.FromFile(fileAndDirectory))
            {
                // Lock the bitmap's bits.  
                Rectangle rect = new Rectangle(0, 0, bmpRate.Width, bmpRate.Height);
                System.Drawing.Imaging.BitmapData bmpData =
                    bmpRate.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bmpRate.PixelFormat);

                if (bmpRate.PixelFormat != System.Drawing.Imaging.PixelFormat.Format24bppRgb) return;

                // Get the address of the first line.
                IntPtr ptr = bmpData.Scan0;

                // Declare an array to hold the bytes of the bitmap.
                int bytes = Math.Abs(bmpData.Stride) * bmpRate.Height;
                byte[] rgbValues = new byte[bytes];

                // Copy the RGB values into the array.
                System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

                //save the width and height
                bmpWidth = bmpRate.Width*3;
                bmpHeight = bmpRate.Height;

                //24 bits per pixel - 3 bytes format is BGR
                byte[] allBytes = new byte[(int)(bmpWidth * bmpHeight)];
                byte[] flipped = new byte[(int)(bmpWidth * bmpHeight)];

                ////extract the red values
                int rc = 0;
                for (var r = 0; r < bmpHeight; r++) //each scanline row
                {
                    for (var c = 0; c < bmpWidth; c ++) //each red pixel
                    {
                        allBytes[rc] = rgbValues[(r * bmpData.Stride) + c]; //remove padding bytes
                        rc++;
                    }
                }

                //flip the image top to bottom
                for (int i = 0, j = allBytes.Length - bmpWidth; i < allBytes.Length; i += bmpWidth, j -= bmpWidth)
                {
                    for (int k = 0; k < bmpWidth; ++k)
                    {
                        flipped[i + k] = allBytes[j + k];
                    }
                }

                int bmpPixelCount = flipped.Length;

                double fieldHeight = (mf.maxFieldY - mf.minFieldY); // field height
                double fieldWidth = (mf.maxFieldX - mf.minFieldX); // field width

                int rateMapScale = 1;

                if (fieldHeight > fieldWidth) rateMapScale = (int)(fieldHeight / 75);
                else rateMapScale = (int)(fieldWidth / 75);

                if (rateMapScale < 4) rateMapScale = 4; //blocks no smaller then 8 meters
                                                        //rateMapScale = 4;

                //how many points of height width of the field grid based on 8 meter square blocks
                int gridHeight = (int)fieldHeight / rateMapScale;
                int gridWidth = (int)fieldWidth / rateMapScale;

                //return to how many pixels wide from color triples
                //bmpWidth /= 3;

                //how much bigger or smaller the bmp is to the field grid
                double bmpToGridScaleWidth = ((double)bmpWidth) / (double)gridWidth / 3.0;
                double bmpToGridScaleHeight = (double)bmpHeight / (double)gridHeight;

                //put bitmap in 2d array for magnification or minification
                int[,] bmpArr = new int[bmpHeight, bmpWidth];

                for (int i = 0; i < bmpHeight; i++)
                {
                    for (int j = 0; j < bmpWidth; j++)
                    {
                        bmpArr[i, j] = flipped[(i * bmpWidth) + j];
                    }
                }

                // [y,x] or [height,width] or [i,j]
                mapList?.Clear();

                for (int i = 0; i < gridHeight; i++)
                {
                    for (int j = 0; j < gridWidth; j++)
                    {
                        //create map point
                        CMapPt pt = new CMapPt((j * rateMapScale) + (int)mf.minFieldX,
                                              (i * rateMapScale) + (int)mf.minFieldY,
                                              bmpArr[(int)(i * bmpToGridScaleHeight), ((int)(j * bmpToGridScaleWidth) * 3) + 0],
                                              bmpArr[(int)(i * bmpToGridScaleHeight), ((int)(j * bmpToGridScaleWidth) * 3) + 1],
                                              bmpArr[(int)(i * bmpToGridScaleHeight), ((int)(j * bmpToGridScaleWidth) * 3) + 2]
                                              );
                        //add the point
                        mapList.Add(pt);
                    }
                }

                // Unlock the bits, add transparency, make png
                bmpRate.UnlockBits(bmpData);
                bmpRate.MakeTransparent(Color.Black);
                {
                    bmpRate.Save("output.png", ImageFormat.Png);  // Or Png
                }

                try
                {
                    string text2 = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Output.png");
                    if (File.Exists(text2))
                    {
                        using (Bitmap bitmap2 = new Bitmap(text2))
                        {
                            GL.GenTextures(1, out mf.texture[9]);
                            GL.BindTexture(TextureTarget.Texture2D, mf.texture[9]);
                            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, 9729);
                            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, 9729);
                            BitmapData bitmapData2 = bitmap2.LockBits(new Rectangle(0, 0, bitmap2.Width, bitmap2.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapData2.Width, bitmapData2.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData2.Scan0);
                            bitmap2.UnlockBits(bitmapData2);
                        }
                    }
                }
                catch (Exception ex2)
                {
                    //WriteErrorLog("Loading Floor Texture" + ex2);
                    MessageBox.Show("Texture File OUPUT.PNG is Missing", ex2.Message);
                }
                mf.isBackgroundOn = true;
            }
        }

        public void DrawArr()
        {
            int ptCount = mapList.Count;
            if (ptCount == 0) return;
            GL.Enable(EnableCap.Texture2D);
            GL.Color3(0.96f, .96f, 0.96f);
            GL.BindTexture(TextureTarget.Texture2D, mf.texture[9]);
            GL.Begin(PrimitiveType.TriangleStrip);
            GL.TexCoord2(0, 0);
            GL.Vertex3(mf.minFieldX - mf.maxFieldDistance + mf.offXB, mf.maxFieldY + mf.maxFieldDistance + mf.offYB, 0.0);
            GL.TexCoord2(1.0, 0.0);
            GL.Vertex3(mf.maxFieldX + mf.maxFieldDistance + mf.offXB, mf.maxFieldY + mf.maxFieldDistance + mf.offYB, 0.0);
            GL.TexCoord2(0.0, 1.0);
            GL.Vertex3(mf.minFieldX - mf.maxFieldDistance + mf.offXB, mf.minFieldY - mf.maxFieldDistance + mf.offYB, 0.0);
            GL.TexCoord2(1.0, 1.0);
            GL.Vertex3(mf.maxFieldX + mf.maxFieldDistance + mf.offXB, mf.minFieldY - mf.maxFieldDistance + mf.offYB, 0.0);
            GL.End();
            GL.Disable(EnableCap.Texture2D);

            //GL.PointSize(8.0f);
            //GL.Begin(PrimitiveType.Points);
            //GL.Color3(0.95f, 0.7520f, 0.07530f);

            //for (int i = 0; i < ptCount; i++)
            //{
            //    GL.Color3((byte)mapList[i].red, (byte)mapList[i].grn, (byte)mapList[i].blu);
            //    GL.Vertex3(mapList[i].easting, mapList[i].northing, -0.2);
            //}
            //GL.End();
        }
    }
}
