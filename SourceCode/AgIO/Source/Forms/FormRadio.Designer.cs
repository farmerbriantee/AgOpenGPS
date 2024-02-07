
namespace AgIO
{
    partial class FormRadio
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
        private void InitializeComponent()
        {
            this.cboxRadioPort = new System.Windows.Forms.ComboBox();
            this.lblCurrentPort = new System.Windows.Forms.Label();
            this.cboxBaud = new System.Windows.Forms.ComboBox();
            this.lblCurrentBaud = new System.Windows.Forms.Label();
            this.lvChannels = new System.Windows.Forms.ListView();
            this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderFreq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbCommand = new System.Windows.Forms.TextBox();
            this.lblCommand = new System.Windows.Forms.Label();
            this.tbResponse = new System.Windows.Forms.TextBox();
            this.lbResponse = new System.Windows.Forms.Label();
            this.cboxIsRadioOn = new System.Windows.Forms.CheckBox();
            this.btnEditChannel = new System.Windows.Forms.Button();
            this.btnDeleteChannel = new System.Windows.Forms.Button();
            this.btnSetChannel = new System.Windows.Forms.Button();
            this.btnRescan = new System.Windows.Forms.Button();
            this.btnCloseSerial = new System.Windows.Forms.Button();
            this.btnOpenSerial = new System.Windows.Forms.Button();
            this.btnRadioCancel = new System.Windows.Forms.Button();
            this.btnRadioOK = new System.Windows.Forms.Button();
            this.btnSendCommand = new System.Windows.Forms.Button();
            this.btnAddChannel = new System.Windows.Forms.Button();
            this.labelChannels = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboxRadioPort
            // 
            this.cboxRadioPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxRadioPort.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.cboxRadioPort.FormattingEnabled = true;
            this.cboxRadioPort.Location = new System.Drawing.Point(63, 38);
            this.cboxRadioPort.Name = "cboxRadioPort";
            this.cboxRadioPort.Size = new System.Drawing.Size(124, 37);
            this.cboxRadioPort.TabIndex = 98;
            // 
            // lblCurrentPort
            // 
            this.lblCurrentPort.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPort.Location = new System.Drawing.Point(70, 17);
            this.lblCurrentPort.Name = "lblCurrentPort";
            this.lblCurrentPort.Size = new System.Drawing.Size(119, 18);
            this.lblCurrentPort.TabIndex = 99;
            this.lblCurrentPort.Text = "Port";
            this.lblCurrentPort.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblCurrentPort.UseCompatibleTextRendering = true;
            // 
            // cboxBaud
            // 
            this.cboxBaud.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cboxBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxBaud.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.cboxBaud.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cboxBaud.FormattingEnabled = true;
            this.cboxBaud.Items.AddRange(new object[] {
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "128000",
            "256000"});
            this.cboxBaud.Location = new System.Drawing.Point(218, 38);
            this.cboxBaud.Name = "cboxBaud";
            this.cboxBaud.Size = new System.Drawing.Size(127, 37);
            this.cboxBaud.TabIndex = 101;
            // 
            // lblCurrentBaud
            // 
            this.lblCurrentBaud.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentBaud.Location = new System.Drawing.Point(218, 17);
            this.lblCurrentBaud.Name = "lblCurrentBaud";
            this.lblCurrentBaud.Size = new System.Drawing.Size(127, 18);
            this.lblCurrentBaud.TabIndex = 100;
            this.lblCurrentBaud.Text = "Baud";
            this.lblCurrentBaud.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lvChannels
            // 
            this.lvChannels.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvChannels.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lvChannels.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderId,
            this.columnHeaderName,
            this.columnHeaderFreq,
            this.columnHeaderDist});
            this.lvChannels.Font = new System.Drawing.Font("Tahoma", 21.75F);
            this.lvChannels.FullRowSelect = true;
            this.lvChannels.GridLines = true;
            this.lvChannels.HideSelection = false;
            this.lvChannels.Location = new System.Drawing.Point(12, 105);
            this.lvChannels.MultiSelect = false;
            this.lvChannels.Name = "lvChannels";
            this.lvChannels.Size = new System.Drawing.Size(685, 326);
            this.lvChannels.TabIndex = 104;
            this.lvChannels.UseCompatibleStateImageBehavior = false;
            this.lvChannels.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderId
            // 
            this.columnHeaderId.Text = "Id";
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 189;
            // 
            // columnHeaderFreq
            // 
            this.columnHeaderFreq.Text = "Frequency";
            this.columnHeaderFreq.Width = 220;
            // 
            // columnHeaderDist
            // 
            this.columnHeaderDist.Text = "Distance";
            this.columnHeaderDist.Width = 133;
            // 
            // tbCommand
            // 
            this.tbCommand.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.tbCommand.Location = new System.Drawing.Point(12, 468);
            this.tbCommand.Name = "tbCommand";
            this.tbCommand.Size = new System.Drawing.Size(598, 30);
            this.tbCommand.TabIndex = 107;
            this.tbCommand.Click += new System.EventHandler(this.tbox_Click);
            // 
            // lblCommand
            // 
            this.lblCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCommand.AutoSize = true;
            this.lblCommand.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommand.Location = new System.Drawing.Point(11, 447);
            this.lblCommand.Name = "lblCommand";
            this.lblCommand.Size = new System.Drawing.Size(80, 18);
            this.lblCommand.TabIndex = 108;
            this.lblCommand.Text = "Command";
            // 
            // tbResponse
            // 
            this.tbResponse.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.tbResponse.Location = new System.Drawing.Point(12, 522);
            this.tbResponse.Name = "tbResponse";
            this.tbResponse.ReadOnly = true;
            this.tbResponse.Size = new System.Drawing.Size(598, 30);
            this.tbResponse.TabIndex = 110;
            // 
            // lbResponse
            // 
            this.lbResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbResponse.AutoSize = true;
            this.lbResponse.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbResponse.Location = new System.Drawing.Point(12, 501);
            this.lbResponse.Name = "lbResponse";
            this.lbResponse.Size = new System.Drawing.Size(80, 18);
            this.lbResponse.TabIndex = 111;
            this.lbResponse.Text = "Response";
            // 
            // cboxIsRadioOn
            // 
            this.cboxIsRadioOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxIsRadioOn.Appearance = System.Windows.Forms.Appearance.Button;
            this.cboxIsRadioOn.BackColor = System.Drawing.Color.Salmon;
            this.cboxIsRadioOn.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cboxIsRadioOn.Checked = true;
            this.cboxIsRadioOn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxIsRadioOn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cboxIsRadioOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxIsRadioOn.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxIsRadioOn.Location = new System.Drawing.Point(396, 569);
            this.cboxIsRadioOn.Name = "cboxIsRadioOn";
            this.cboxIsRadioOn.Size = new System.Drawing.Size(150, 50);
            this.cboxIsRadioOn.TabIndex = 112;
            this.cboxIsRadioOn.Text = "Radio";
            this.cboxIsRadioOn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboxIsRadioOn.UseVisualStyleBackColor = false;
            // 
            // btnEditChannel
            // 
            this.btnEditChannel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditChannel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEditChannel.FlatAppearance.BorderSize = 0;
            this.btnEditChannel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditChannel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditChannel.Image = global::AgIO.Properties.Resources.Edit;
            this.btnEditChannel.Location = new System.Drawing.Point(703, 287);
            this.btnEditChannel.Name = "btnEditChannel";
            this.btnEditChannel.Size = new System.Drawing.Size(105, 64);
            this.btnEditChannel.TabIndex = 114;
            this.btnEditChannel.UseVisualStyleBackColor = true;
            this.btnEditChannel.Click += new System.EventHandler(this.btnEditChannel_Click);
            // 
            // btnDeleteChannel
            // 
            this.btnDeleteChannel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteChannel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDeleteChannel.FlatAppearance.BorderSize = 0;
            this.btnDeleteChannel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteChannel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteChannel.Image = global::AgIO.Properties.Resources.Trash;
            this.btnDeleteChannel.Location = new System.Drawing.Point(703, 378);
            this.btnDeleteChannel.Name = "btnDeleteChannel";
            this.btnDeleteChannel.Size = new System.Drawing.Size(105, 64);
            this.btnDeleteChannel.TabIndex = 113;
            this.btnDeleteChannel.UseVisualStyleBackColor = true;
            this.btnDeleteChannel.Click += new System.EventHandler(this.btnDeleteChannel_Click);
            // 
            // btnSetChannel
            // 
            this.btnSetChannel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetChannel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSetChannel.FlatAppearance.BorderSize = 0;
            this.btnSetChannel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetChannel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetChannel.Image = global::AgIO.Properties.Resources.ArrowRight;
            this.btnSetChannel.Location = new System.Drawing.Point(703, 105);
            this.btnSetChannel.Name = "btnSetChannel";
            this.btnSetChannel.Size = new System.Drawing.Size(105, 64);
            this.btnSetChannel.TabIndex = 106;
            this.btnSetChannel.UseVisualStyleBackColor = true;
            this.btnSetChannel.Click += new System.EventHandler(this.btnSetChannel_Click);
            // 
            // btnRescan
            // 
            this.btnRescan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRescan.BackColor = System.Drawing.Color.Transparent;
            this.btnRescan.FlatAppearance.BorderSize = 0;
            this.btnRescan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRescan.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRescan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRescan.Image = global::AgIO.Properties.Resources.ScanPorts;
            this.btnRescan.Location = new System.Drawing.Point(703, 469);
            this.btnRescan.Name = "btnRescan";
            this.btnRescan.Size = new System.Drawing.Size(105, 63);
            this.btnRescan.TabIndex = 105;
            this.btnRescan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRescan.UseVisualStyleBackColor = false;
            this.btnRescan.Click += new System.EventHandler(this.btnRescan_Click);
            // 
            // btnCloseSerial
            // 
            this.btnCloseSerial.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseSerial.FlatAppearance.BorderSize = 0;
            this.btnCloseSerial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseSerial.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseSerial.Image = global::AgIO.Properties.Resources.USB_Disconnect;
            this.btnCloseSerial.Location = new System.Drawing.Point(486, 24);
            this.btnCloseSerial.Name = "btnCloseSerial";
            this.btnCloseSerial.Size = new System.Drawing.Size(101, 58);
            this.btnCloseSerial.TabIndex = 102;
            this.btnCloseSerial.UseVisualStyleBackColor = false;
            this.btnCloseSerial.Click += new System.EventHandler(this.btnCloseSerial_Click);
            // 
            // btnOpenSerial
            // 
            this.btnOpenSerial.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenSerial.FlatAppearance.BorderSize = 0;
            this.btnOpenSerial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenSerial.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenSerial.Image = global::AgIO.Properties.Resources.USB_Connect;
            this.btnOpenSerial.Location = new System.Drawing.Point(365, 24);
            this.btnOpenSerial.Name = "btnOpenSerial";
            this.btnOpenSerial.Size = new System.Drawing.Size(101, 58);
            this.btnOpenSerial.TabIndex = 103;
            this.btnOpenSerial.UseVisualStyleBackColor = false;
            this.btnOpenSerial.Click += new System.EventHandler(this.btnOpenSerial_Click);
            // 
            // btnRadioCancel
            // 
            this.btnRadioCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRadioCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRadioCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRadioCancel.FlatAppearance.BorderSize = 0;
            this.btnRadioCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRadioCancel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRadioCancel.Image = global::AgIO.Properties.Resources.Cancel64;
            this.btnRadioCancel.Location = new System.Drawing.Point(601, 560);
            this.btnRadioCancel.Name = "btnRadioCancel";
            this.btnRadioCancel.Size = new System.Drawing.Size(105, 64);
            this.btnRadioCancel.TabIndex = 97;
            this.btnRadioCancel.UseVisualStyleBackColor = true;
            // 
            // btnRadioOK
            // 
            this.btnRadioOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRadioOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRadioOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRadioOK.FlatAppearance.BorderSize = 0;
            this.btnRadioOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRadioOK.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRadioOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRadioOK.Image = global::AgIO.Properties.Resources.OK64;
            this.btnRadioOK.Location = new System.Drawing.Point(703, 560);
            this.btnRadioOK.Name = "btnRadioOK";
            this.btnRadioOK.Size = new System.Drawing.Size(105, 64);
            this.btnRadioOK.TabIndex = 96;
            this.btnRadioOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnRadioOK.UseVisualStyleBackColor = true;
            this.btnRadioOK.Click += new System.EventHandler(this.btnRadioOK_Click);
            // 
            // btnSendCommand
            // 
            this.btnSendCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendCommand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSendCommand.FlatAppearance.BorderSize = 0;
            this.btnSendCommand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendCommand.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendCommand.Image = global::AgIO.Properties.Resources.ArrowRight;
            this.btnSendCommand.Location = new System.Drawing.Point(592, 455);
            this.btnSendCommand.Name = "btnSendCommand";
            this.btnSendCommand.Size = new System.Drawing.Size(105, 64);
            this.btnSendCommand.TabIndex = 109;
            this.btnSendCommand.UseVisualStyleBackColor = true;
            this.btnSendCommand.Click += new System.EventHandler(this.btnSendCommand_Click);
            // 
            // btnAddChannel
            // 
            this.btnAddChannel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddChannel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddChannel.FlatAppearance.BorderSize = 0;
            this.btnAddChannel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddChannel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddChannel.Image = global::AgIO.Properties.Resources.AddNew;
            this.btnAddChannel.Location = new System.Drawing.Point(703, 196);
            this.btnAddChannel.Name = "btnAddChannel";
            this.btnAddChannel.Size = new System.Drawing.Size(105, 64);
            this.btnAddChannel.TabIndex = 114;
            this.btnAddChannel.UseVisualStyleBackColor = true;
            this.btnAddChannel.Click += new System.EventHandler(this.btnAddChannel_Click);
            // 
            // labelChannels
            // 
            this.labelChannels.AutoSize = true;
            this.labelChannels.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChannels.Location = new System.Drawing.Point(11, 84);
            this.labelChannels.Name = "labelChannels";
            this.labelChannels.Size = new System.Drawing.Size(76, 18);
            this.labelChannels.TabIndex = 115;
            this.labelChannels.Text = "Channels";
            // 
            // FormRadio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 627);
            this.ControlBox = false;
            this.Controls.Add(this.labelChannels);
            this.Controls.Add(this.btnAddChannel);
            this.Controls.Add(this.btnEditChannel);
            this.Controls.Add(this.btnDeleteChannel);
            this.Controls.Add(this.cboxIsRadioOn);
            this.Controls.Add(this.lbResponse);
            this.Controls.Add(this.tbResponse);
            this.Controls.Add(this.lblCommand);
            this.Controls.Add(this.tbCommand);
            this.Controls.Add(this.btnSetChannel);
            this.Controls.Add(this.btnRescan);
            this.Controls.Add(this.lvChannels);
            this.Controls.Add(this.btnCloseSerial);
            this.Controls.Add(this.btnOpenSerial);
            this.Controls.Add(this.cboxBaud);
            this.Controls.Add(this.lblCurrentBaud);
            this.Controls.Add(this.cboxRadioPort);
            this.Controls.Add(this.btnRadioCancel);
            this.Controls.Add(this.btnRadioOK);
            this.Controls.Add(this.btnSendCommand);
            this.Controls.Add(this.lblCurrentPort);
            this.MinimumSize = new System.Drawing.Size(838, 668);
            this.Name = "FormRadio";
            this.Text = "Radio Settings";
            this.Load += new System.EventHandler(this.FormRadio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRadioCancel;
        private System.Windows.Forms.Button btnRadioOK;
        private System.Windows.Forms.ComboBox cboxRadioPort;
        private System.Windows.Forms.Label lblCurrentPort;
        private System.Windows.Forms.ComboBox cboxBaud;
        private System.Windows.Forms.Label lblCurrentBaud;
        private System.Windows.Forms.Button btnCloseSerial;
        private System.Windows.Forms.Button btnOpenSerial;
        private System.Windows.Forms.ListView lvChannels;
        private System.Windows.Forms.ColumnHeader columnHeaderId;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderFreq;
        private System.Windows.Forms.Button btnRescan;
        private System.Windows.Forms.Button btnSetChannel;
        private System.Windows.Forms.TextBox tbCommand;
        private System.Windows.Forms.Label lblCommand;
        private System.Windows.Forms.Button btnSendCommand;
        private System.Windows.Forms.TextBox tbResponse;
        private System.Windows.Forms.Label lbResponse;
        private System.Windows.Forms.CheckBox cboxIsRadioOn;
        private System.Windows.Forms.Button btnDeleteChannel;
        private System.Windows.Forms.Button btnEditChannel;
        private System.Windows.Forms.Button btnAddChannel;
        private System.Windows.Forms.Label labelChannels;
        private System.Windows.Forms.ColumnHeader columnHeaderDist;
    }
}