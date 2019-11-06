using System;
using System.Drawing;
using System.Windows.Forms;

namespace AgOpenGPS
{
    partial class FormBoundary
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnUnlock = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.btnLoadMultiBoundaryFromGE = new System.Windows.Forms.Button();
            this.btnOpenGoogleEarth = new System.Windows.Forms.Button();
            this.btnLoadBoundaryFromGE = new System.Windows.Forms.Button();
            this.btnLeftRight = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnOuter = new System.Windows.Forms.Button();
            this.btnSerialCancel = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 49);
            this.label1.TabIndex = 92;
            this.label1.Text = "Bounds";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(167, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 49);
            this.label2.TabIndex = 90;
            this.label2.Text = "Area";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(392, 23);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(80, 49);
            this.label4.TabIndex = 91;
            this.label4.Text = "Thru";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(467, 23);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 49);
            this.label5.TabIndex = 98;
            this.label5.Text = "Around";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(17, 89);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(535, 322);
            this.tableLayoutPanel1.TabIndex = 101;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(552, 60);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 40);
            this.button2.TabIndex = 104;
            this.button2.Text = "▲";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(552, 370);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 40);
            this.button1.TabIndex = 105;
            this.button1.Text = "▼";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button4
            // 
            this.button4.CausesValidation = false;
            this.button4.Location = new System.Drawing.Point(552, 129);
            this.button4.Margin = new System.Windows.Forms.Padding(0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(40, 80);
            this.button4.TabIndex = 200;
            this.button4.TabStop = false;
            this.button4.UseCompatibleTextRendering = true;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Mouse_Down);
            this.button4.MouseLeave += new System.EventHandler(this.Mouse_Leave);
            this.button4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Mouse_Move);
            this.button4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Mouse_Up);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(612, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 55);
            this.label3.TabIndex = 201;
            this.label3.Text = "Manually Driven";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(796, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 55);
            this.label6.TabIndex = 202;
            this.label6.Text = "From File";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(840, 217);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 34);
            this.label7.TabIndex = 203;
            this.label7.Text = "OR";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(2, 422);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(165, 44);
            this.label8.TabIndex = 204;
            this.label8.Text = "Caution: Delete All";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(201, 422);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(165, 44);
            this.label9.TabIndex = 205;
            this.label9.Text = "Delete Selected";
            this.label9.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(410, 422);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(165, 44);
            this.label10.TabIndex = 206;
            this.label10.Text = "Save and Return";
            this.label10.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnUnlock
            // 
            this.btnUnlock.BackColor = System.Drawing.Color.Transparent;
            this.btnUnlock.Enabled = false;
            this.btnUnlock.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnUnlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnlock.Image = global::AgOpenGPS.Properties.Resources.UnLock;
            this.btnUnlock.Location = new System.Drawing.Point(312, 43);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(71, 38);
            this.btnUnlock.TabIndex = 102;
            this.btnUnlock.UseVisualStyleBackColor = false;
            this.btnUnlock.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.BackColor = System.Drawing.Color.MistyRose;
            this.btnDeleteAll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDeleteAll.FlatAppearance.BorderSize = 3;
            this.btnDeleteAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteAll.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteAll.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnDeleteAll.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeleteAll.Location = new System.Drawing.Point(17, 473);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(120, 81);
            this.btnDeleteAll.TabIndex = 100;
            this.btnDeleteAll.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDeleteAll.UseVisualStyleBackColor = false;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // btnLoadMultiBoundaryFromGE
            // 
            this.btnLoadMultiBoundaryFromGE.BackColor = System.Drawing.Color.Lavender;
            this.btnLoadMultiBoundaryFromGE.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnLoadMultiBoundaryFromGE.FlatAppearance.BorderSize = 3;
            this.btnLoadMultiBoundaryFromGE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadMultiBoundaryFromGE.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadMultiBoundaryFromGE.Image = global::AgOpenGPS.Properties.Resources.FileOpen;
            this.btnLoadMultiBoundaryFromGE.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLoadMultiBoundaryFromGE.Location = new System.Drawing.Point(819, 267);
            this.btnLoadMultiBoundaryFromGE.Name = "btnLoadMultiBoundaryFromGE";
            this.btnLoadMultiBoundaryFromGE.Size = new System.Drawing.Size(120, 110);
            this.btnLoadMultiBoundaryFromGE.TabIndex = 99;
            this.btnLoadMultiBoundaryFromGE.Text = "Load Multi";
            this.btnLoadMultiBoundaryFromGE.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLoadMultiBoundaryFromGE.UseVisualStyleBackColor = false;
            this.btnLoadMultiBoundaryFromGE.Click += new System.EventHandler(this.btnLoadMultiBoundaryFromGE_Click);
            // 
            // btnOpenGoogleEarth
            // 
            this.btnOpenGoogleEarth.BackColor = System.Drawing.Color.Lavender;
            this.btnOpenGoogleEarth.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnOpenGoogleEarth.FlatAppearance.BorderSize = 3;
            this.btnOpenGoogleEarth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenGoogleEarth.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenGoogleEarth.Image = global::AgOpenGPS.Properties.Resources.GoogleEarth;
            this.btnOpenGoogleEarth.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOpenGoogleEarth.Location = new System.Drawing.Point(819, 436);
            this.btnOpenGoogleEarth.Name = "btnOpenGoogleEarth";
            this.btnOpenGoogleEarth.Size = new System.Drawing.Size(120, 110);
            this.btnOpenGoogleEarth.TabIndex = 69;
            this.btnOpenGoogleEarth.Text = "Google Earth";
            this.btnOpenGoogleEarth.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOpenGoogleEarth.UseVisualStyleBackColor = false;
            this.btnOpenGoogleEarth.Click += new System.EventHandler(this.btnOpenGoogleEarth_Click);
            // 
            // btnLoadBoundaryFromGE
            // 
            this.btnLoadBoundaryFromGE.BackColor = System.Drawing.Color.Lavender;
            this.btnLoadBoundaryFromGE.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnLoadBoundaryFromGE.FlatAppearance.BorderSize = 3;
            this.btnLoadBoundaryFromGE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadBoundaryFromGE.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadBoundaryFromGE.Image = global::AgOpenGPS.Properties.Resources.FileOpen;
            this.btnLoadBoundaryFromGE.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLoadBoundaryFromGE.Location = new System.Drawing.Point(819, 97);
            this.btnLoadBoundaryFromGE.Name = "btnLoadBoundaryFromGE";
            this.btnLoadBoundaryFromGE.Size = new System.Drawing.Size(120, 110);
            this.btnLoadBoundaryFromGE.TabIndex = 68;
            this.btnLoadBoundaryFromGE.Text = "Load KML";
            this.btnLoadBoundaryFromGE.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLoadBoundaryFromGE.UseVisualStyleBackColor = false;
            this.btnLoadBoundaryFromGE.Click += new System.EventHandler(this.btnLoadBoundaryFromGE_Click);
            // 
            // btnLeftRight
            // 
            this.btnLeftRight.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnLeftRight.Enabled = false;
            this.btnLeftRight.FlatAppearance.BorderColor = System.Drawing.Color.Fuchsia;
            this.btnLeftRight.FlatAppearance.BorderSize = 3;
            this.btnLeftRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeftRight.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftRight.Image = global::AgOpenGPS.Properties.Resources.BoundaryRight;
            this.btnLeftRight.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLeftRight.Location = new System.Drawing.Point(633, 267);
            this.btnLeftRight.Name = "btnLeftRight";
            this.btnLeftRight.Size = new System.Drawing.Size(120, 110);
            this.btnLeftRight.TabIndex = 67;
            this.btnLeftRight.Text = "3. Pick ?";
            this.btnLeftRight.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLeftRight.UseVisualStyleBackColor = false;
            this.btnLeftRight.Click += new System.EventHandler(this.btnLeftRight_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.MistyRose;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDelete.FlatAppearance.BorderSize = 3;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::AgOpenGPS.Properties.Resources.BoundaryDelete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelete.Location = new System.Drawing.Point(215, 473);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(131, 81);
            this.btnDelete.TabIndex = 65;
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnOuter
            // 
            this.btnOuter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnOuter.FlatAppearance.BorderColor = System.Drawing.Color.Fuchsia;
            this.btnOuter.FlatAppearance.BorderSize = 3;
            this.btnOuter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOuter.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOuter.Image = global::AgOpenGPS.Properties.Resources.BoundaryOuter;
            this.btnOuter.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOuter.Location = new System.Drawing.Point(633, 98);
            this.btnOuter.Name = "btnOuter";
            this.btnOuter.Size = new System.Drawing.Size(120, 110);
            this.btnOuter.TabIndex = 65;
            this.btnOuter.Text = "2. Start";
            this.btnOuter.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOuter.UseVisualStyleBackColor = false;
            this.btnOuter.Click += new System.EventHandler(this.btnOuter_Click);
            // 
            // btnSerialCancel
            // 
            this.btnSerialCancel.BackColor = System.Drawing.Color.Honeydew;
            this.btnSerialCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSerialCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSerialCancel.FlatAppearance.BorderSize = 2;
            this.btnSerialCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSerialCancel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSerialCancel.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnSerialCancel.Location = new System.Drawing.Point(432, 473);
            this.btnSerialCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btnSerialCancel.Name = "btnSerialCancel";
            this.btnSerialCancel.Size = new System.Drawing.Size(120, 74);
            this.btnSerialCancel.TabIndex = 64;
            this.btnSerialCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSerialCancel.UseVisualStyleBackColor = false;
            this.btnSerialCancel.Click += new System.EventHandler(this.btnSerialCancel_Click);
            // 
            // btnGo
            // 
            this.btnGo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnGo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGo.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGo.Enabled = false;
            this.btnGo.FlatAppearance.BorderColor = System.Drawing.Color.Fuchsia;
            this.btnGo.FlatAppearance.BorderSize = 3;
            this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGo.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGo.Image = global::AgOpenGPS.Properties.Resources.AutoGo;
            this.btnGo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGo.Location = new System.Drawing.Point(633, 436);
            this.btnGo.Margin = new System.Windows.Forms.Padding(5);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(120, 110);
            this.btnGo.TabIndex = 63;
            this.btnGo.Text = "4. Go!";
            this.btnGo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGo.UseVisualStyleBackColor = false;
            // 
            // FormBoundary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(950, 558);
            this.ControlBox = false;
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnUnlock);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnDeleteAll);
            this.Controls.Add(this.btnLoadMultiBoundaryFromGE);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOpenGoogleEarth);
            this.Controls.Add(this.btnLoadBoundaryFromGE);
            this.Controls.Add(this.btnLeftRight);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnOuter);
            this.Controls.Add(this.btnSerialCancel);
            this.Controls.Add(this.btnGo);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FormBoundary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Start or Delete A Boundary";
            this.Load += new System.EventHandler(this.FormBoundary_Load);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.MouseWheel_scroll);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSerialCancel;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnOuter;
        private System.Windows.Forms.Button btnLeftRight;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnLoadBoundaryFromGE;
        private System.Windows.Forms.Button btnOpenGoogleEarth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLoadMultiBoundaryFromGE;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnUnlock;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private Button button4;
        private Label label3;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
    }
}