using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpGL
{
    /// <summary>
    /// A FontBitmap entry contains the details of a font face.
    /// </summary>
    internal class FontBitmapEntry
    {
        public IntPtr HDC
        {
            get;
            set;
        }

        public IntPtr HRC
        {
            get;
            set;
        }

        public string FaceName
        {
            get;
            set;
        }

        public int Height
        {
            get;
            set;
        }

        public uint ListBase
        {
            get;
            set;
        }

        public uint ListCount
        {
            get;
            set;
        }
    }

    /// <summary>
    /// This class wraps the functionality of the wglUseFontBitmaps function to
    /// allow straightforward rendering of text.
    /// </summary>
    public class FontBitmaps
    {
        private FontBitmapEntry CreateFontBitmapEntry(OpenGL gl, string faceName, int height)
        {
            //  Make the OpenGL instance current.
            gl.MakeCurrent();

            //  Create the font based on the face name.
            var hFont = Win32.CreateFont(height, 0, 0, 0, Win32.FW_DONTCARE, 0, 0, 0, Win32.DEFAULT_CHARSET, 
                Win32.OUT_OUTLINE_PRECIS, Win32.CLIP_DEFAULT_PRECIS, Win32.CLEARTYPE_QUALITY, Win32.VARIABLE_PITCH, faceName);
            
            //  Select the font handle.
            var hOldObject = Win32.SelectObject(gl.RenderContextProvider.DeviceContextHandle, hFont);

            //  Create the list base.
            var listBase = gl.GenLists(1);

            //  Create the font bitmaps.
            bool result = Win32.wglUseFontBitmaps(gl.RenderContextProvider.DeviceContextHandle, 0, 255, listBase);

            //  Reselect the old font.
            Win32.SelectObject(gl.RenderContextProvider.DeviceContextHandle, hOldObject);

            //  Free the font.
            Win32.DeleteObject(hFont);

            //  Create the font bitmap entry.
            var fbe = new FontBitmapEntry()
            {
                HDC = gl.RenderContextProvider.DeviceContextHandle,
                HRC = gl.RenderContextProvider.RenderContextHandle,
                FaceName = faceName,
                Height = height,
                ListBase = listBase,
                ListCount = 255
            };

            //  Add the font bitmap entry to the internal list.
            fontBitmapEntries.Add(fbe);

            return fbe;
        }

        /// <summary>
        /// Draws the text.
        /// </summary>
        /// <param name="gl">The gl.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="r">The r.</param>
        /// <param name="g">The g.</param>
        /// <param name="b">The b.</param>
        /// <param name="faceName">Name of the face.</param>
        /// <param name="fontSize">Size of the font.</param>
        /// <param name="text">The text.</param>
        public void DrawText(OpenGL gl, int x, int y, float r, float g, float b, string faceName, float fontSize, string text)
        {
            //  Get the font size in pixels.
            var fontHeight = (int)(fontSize * (16.0f / 12.0f));

            //  Do we have a font bitmap entry for this OpenGL instance and face name?
            var result = (from fbe in fontBitmapEntries
                         where fbe.HDC == gl.RenderContextProvider.DeviceContextHandle
                         && fbe.HRC == gl.RenderContextProvider.RenderContextHandle
                         && String.Compare(fbe.FaceName, faceName, StringComparison.OrdinalIgnoreCase) == 0
                         && fbe.Height == fontHeight
                         select fbe).ToList();

            //  Get the FBE or null.
            var fontBitmapEntry = result.FirstOrDefault();

            //  If we don't have the FBE, we must create it.
            if (fontBitmapEntry == null)
                fontBitmapEntry = CreateFontBitmapEntry(gl, faceName, fontHeight);

            double width = gl.RenderContextProvider.Width;
            double height = gl.RenderContextProvider.Height;
            
            //  Create the appropriate projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.PushMatrix();
            gl.LoadIdentity();
            
            int[] viewport = new int[4];
            gl.GetInteger(OpenGL.GL_VIEWPORT, viewport);
            gl.Ortho(0, width, 0, height, -1, 1);

            //  Create the appropriate modelview matrix.
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            gl.PushMatrix();
            gl.LoadIdentity();
            gl.Color(r, g, b);
            gl.RasterPos(x, y);

            gl.PushAttrib(OpenGL.GL_LIST_BIT | OpenGL.GL_CURRENT_BIT |
                OpenGL.GL_ENABLE_BIT | OpenGL.GL_TRANSFORM_BIT);
            gl.Color(r, g, b);
            gl.Disable(OpenGL.GL_LIGHTING);
            gl.Disable(OpenGL.GL_TEXTURE_2D);
            gl.Disable(OpenGL.GL_DEPTH_TEST);
            gl.RasterPos(x, y);

            //  Set the list base.
            gl.ListBase(fontBitmapEntry.ListBase);

            //  Create an array of lists for the glyphs.
            var lists = text.Select(c => (byte) c).ToArray();

            //  Call the lists for the string.
            gl.CallLists(lists.Length, lists);
            gl.Flush();
            
            //  Reset the list bit.
            gl.PopAttrib();

            //  Pop the modelview.
            gl.PopMatrix();

            //  back to the projection and pop it, then back to the model view.
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.PopMatrix();
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }

        /// <summary>
        /// Cache of font bitmap enties.
        /// </summary>
        private readonly List<FontBitmapEntry> fontBitmapEntries = new List<FontBitmapEntry>();
    }
}
