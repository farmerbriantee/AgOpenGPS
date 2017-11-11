using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharpGL;

namespace OGL
{
    public partial class Form1 : Form
    {
        Texture particleTexture;
        public uint[] texture = new uint[3];		

        public Form1()
        {
            InitializeComponent();
        }

        private void LoadTex()
        {
            OpenGL gl = openGLControl1.OpenGL;
            particleTexture = new Texture();
            particleTexture.Create(gl, @".\Dependencies\landscape.png");
            texture[0] = particleTexture.TextureName;
        }
    }
}
