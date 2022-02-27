using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormMap : Form
    {
        //access to the main GPS form and all its variables
        private readonly FormGPS mf = null;

        //private Image imageMarker = Image.FromStream
        //    (System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream($"DemoApp.Marker.png"));

        private Image imageMarker = Properties.Resources.FlagGrn;
        

        private bool isClosing;
        Track bingLine = new Track(new TrackStyle(new Pen(Color.White, 4)));
        private int zoom = 15;

        public FormMap(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;

            InitializeComponent();

            mapControl.CacheFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MapControl");

            ITileServer[] tileServers = new ITileServer[]
            {
                new BingMapsHybridTileServer(),
                new BingMapsRoadsTileServer(),
                new OpenStreetMapTileServer(userAgent: "Map Control AgOpenGPS"),
                new OfflineTileServer(),
                new BingMapsAerialTileServer(),
            };

            cmbTileServers.Items.AddRange(tileServers);
            cmbTileServers.SelectedIndex = 0;
            mapControl.Tracks.Add(bingLine);
        }

        private void FormHeadland_Load(object sender, EventArgs e)
        {
            lblPoints.Text = "0";
            mapControl.ZoomLevel = 15;//mapControl
            mapControl.Center = new GeoPoint((float)mf.pn.longitude, (float)mf.pn.latitude);
            mapControl.Invalidate();   
        }

        private void FormHeadland_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isClosing)
            {
                e.Cancel = true;
                return;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

            isClosing = true;
            Close();
        }

        private void UpdateWindowTitle()
        {
            GeoPoint g = mapControl.Mouse;
            this.Text = $"Mouse = {g} / Zoom = {mapControl.ZoomLevel} ";
        }

        private void mapControl_MouseMove(object sender, MouseEventArgs e)
        {
            UpdateWindowTitle();
        }

        private void mapControl_MouseWheel(object sender, MouseEventArgs e)
        {
            UpdateWindowTitle();
        }

        private void btnClearCache_Click(object sender, EventArgs e)
        {
            mapControl.ClearCache(true);
            ActiveControl = mapControl;
        }

        private void cmbTileServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            mapControl.TileServer = cmbTileServers.SelectedItem as ITileServer;
            ActiveControl = mapControl;
        }

        //private void mapControl_DrawMarker(object sender, DrawMarkerEventArgs e)
        //{
        //    e.Handled = true;
        //    e.Graphics.DrawImage(imageMarker, new Rectangle((int)e.Point.X - 12, (int)e.Point.Y - 24, 24, 24));
        //    if (mapControl.ZoomLevel >= 5)
        //    {
        //        e.Graphics.DrawString(e.Marker.Label, SystemFonts.DefaultFont, Brushes.Red, new PointF(e.Point.X, e.Point.Y + 5), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near });
        //    }
        //}

        private void mapControl_DoubleClick(object sender, EventArgs e)
        {
            //var coord = mapControl.Mouse;
            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine($"Location: {coord}");
            //MessageBox.Show(sb.ToString(), "Info");
        }

        private void btnPic_Click(object sender, EventArgs e)
        {
            double nor = 0;
            double eas = 0;

            mf.worldGrid.isGeoMap = true;

            CornerPoint geoRef = mapControl.TopLeftCorner;
            mf.pn.ConvertWGS84ToLocal(geoRef.Latitude, geoRef.Longitude, out nor, out eas);
            if (Math.Abs(nor) > 4000 || Math.Abs(eas) > 4000) mf.worldGrid.isGeoMap = false;
            mf.worldGrid.northingMaxGeo = nor;
            mf.worldGrid.eastingMinGeo = eas;

            geoRef = mapControl.BottomRightCorner;
            mf.pn.ConvertWGS84ToLocal(geoRef.Latitude, geoRef.Longitude, out nor, out eas);
            if (Math.Abs(nor) > 4000 || Math.Abs(eas) > 4000) mf.worldGrid.isGeoMap = false;
            mf.worldGrid.northingMinGeo = nor;
            mf.worldGrid.eastingMaxGeo = eas;

            if (!mf.worldGrid.isGeoMap)
            {
                mf.TimedMessageBox(2000, "Map Error", "Map Too Large");
                ResetMapGrid();
                return;
            }

            Bitmap bitmap = new Bitmap(mapControl.Width, mapControl.Height);
            mapControl.DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));

            //bitmap = (Bitmap)ToolStripRenderer.CreateDisabledImage(bitmap);

            GL.BindTexture(TextureTarget.Texture2D, mf.texture[20]);
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapData.Width, bitmapData.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);
            bitmap.UnlockBits(bitmapData);

        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            mapControl.Center = new GeoPoint((float)mf.pn.longitude, (float)mf.pn.latitude);
            UpdateWindowTitle();
        }

        private void mapControl_Click(object sender, EventArgs e)
        {
            if (cboxEnableLineDraw.Checked)
            {
                var coord = mapControl.Mouse;
                bingLine.Add(coord);
                mapControl.Invalidate();
                lblPoints.Text = bingLine.Count.ToString();
            }
        }

        private void btnDeletePoint_Click(object sender, EventArgs e)
        {

            if (bingLine.Count > 0)  bingLine.RemoveAt(bingLine.Count - 1);
            mapControl.Invalidate();
            lblPoints.Text = bingLine.Count.ToString();
        }

        private void btnAddFence_Click(object sender, EventArgs e)
        {
            if (bingLine.Count > 2)
            {
                CBoundaryList New = new CBoundaryList();
                double east, nort;
                for (int i = 0; i < bingLine.Count; i++)
                {
                    mf.pn.ConvertWGS84ToLocal(bingLine[i].Latitude, bingLine[i].Longitude, out nort, out east);
                    vec3 v = new vec3(east, nort,0);
                    New.fenceLine.Add(v);
                }

                New.CalculateFenceArea(mf.bnd.bndList.Count);
                New.FixFenceLine(mf.bnd.bndList.Count);

                mf.bnd.bndList.Add(New);
                mf.fd.UpdateFieldBoundaryGUIAreas();

                //turn lines made from boundaries
                mf.CalculateMinMax();
                mf.FileSaveBoundary();
                mf.bnd.BuildTurnLines();
                mf.btnABDraw.Visible = true;

                //mf.hd.BuildSingleSpaceHeadLines();

                //clean up line
                bingLine.Clear();
                mapControl.Invalidate();
                lblPoints.Text = bingLine.Count.ToString();
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            DialogResult result3 = MessageBox.Show(gStr.gsCompletelyDeleteBoundary,
                gStr.gsDeleteForSure,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result3 == DialogResult.Yes)
            {
                mf.bnd.bndList.Clear();
                mf.FileSaveBoundary();
                mf.bnd.BuildTurnLines();
                mf.fd.UpdateFieldBoundaryGUIAreas();
                mf.btnABDraw.Visible = false;
                //clean up line
                bingLine.Clear();
                mapControl.Invalidate();
                lblPoints.Text = bingLine.Count.ToString();
            }
            else
            {
                mf.TimedMessageBox(1500, gStr.gsNothingDeleted, gStr.gsActionHasBeenCancelled);
            }


        }

        private void cboxEnableLineDraw_Click(object sender, EventArgs e)
        {
            if (cboxEnableLineDraw.Checked)
            {
                btnDeleteAll.Enabled = true;
                btnAddFence.Enabled = true;
                btnDeletePoint.Enabled = true;
            }
            else
            {
                btnDeleteAll.Enabled = false;   
                btnAddFence.Enabled = false;
                btnDeletePoint.Enabled = false;
            }
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            zoom--;
            if (zoom < 2) zoom = 2;
            mapControl.ZoomLevel = zoom;//mapControl
            mapControl.Invalidate();
            UpdateWindowTitle();
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            zoom++;
            if (zoom > 19) zoom = 19;
            mapControl.ZoomLevel = zoom;//mapControl
            mapControl.Invalidate();
            UpdateWindowTitle();
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            ResetMapGrid();

        }

        private void ResetMapGrid()
        {
            using (Bitmap bitmap = Properties.Resources.z_bingMap)
            {
                GL.GenTextures(1, out mf.texture[20]);
                GL.BindTexture(TextureTarget.Texture2D, mf.texture[20]);
                BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapData.Width, bitmapData.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);
                bitmap.UnlockBits(bitmapData);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, 9729);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, 9729);
            }

            mf.worldGrid.isGeoMap = false;

            bingLine.Clear();
            mapControl.Invalidate();
            lblPoints.Text = bingLine.Count.ToString();
        }

        private void btnN_Click(object sender, EventArgs e)
        {
            mf.worldGrid.northingMaxGeo += 0.2;
            mf.worldGrid.northingMinGeo += 0.2;
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            mf.worldGrid.northingMaxGeo -= 0.2;
            mf.worldGrid.northingMinGeo -= 0.2;
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            mf.worldGrid.eastingMaxGeo += 0.2;
            mf.worldGrid.eastingMinGeo += 0.2;
        }

        private void btnW_Click(object sender, EventArgs e)
        {
            mf.worldGrid.eastingMaxGeo -= 0.2;
            mf.worldGrid.eastingMinGeo -= 0.2;
        }
    }
}
