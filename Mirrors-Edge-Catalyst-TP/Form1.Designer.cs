namespace Mirrors_Edge_Catalyst_TP
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.CheckGameStatus = new System.Windows.Forms.Timer(this.components);
            this.Menu = new NSTheme();
            this.nsGroupBox1 = new NSGroupBox();
            this.nsLabel2 = new NSLabel();
            this.TelePosition = new NSTextBox();
            this.nsLabel1 = new NSLabel();
            this.SavePosition = new NSTextBox();
            this.GroupBox = new NSGroupBox();
            this.TeleportButton = new NSButton();
            this.SaveButton = new NSButton();
            this.nsControlButton1 = new NSControlButton();
            this.GameStatus = new System.Windows.Forms.Label();
            this.GameName = new System.Windows.Forms.Label();
            this.Menu.SuspendLayout();
            this.nsGroupBox1.SuspendLayout();
            this.GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // CheckGameStatus
            // 
            this.CheckGameStatus.Enabled = true;
            this.CheckGameStatus.Interval = 1000;
            this.CheckGameStatus.Tick += new System.EventHandler(this.CheckGameStatus_Tick);
            // 
            // Menu
            // 
            this.Menu.AccentOffset = 0;
            this.Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Menu.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Menu.Colors = new Bloom[0];
            this.Menu.Controls.Add(this.nsGroupBox1);
            this.Menu.Controls.Add(this.GroupBox);
            this.Menu.Controls.Add(this.nsControlButton1);
            this.Menu.Controls.Add(this.GameStatus);
            this.Menu.Controls.Add(this.GameName);
            this.Menu.Customization = "";
            this.Menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Menu.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Menu.Image = null;
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Movable = true;
            this.Menu.Name = "Menu";
            this.Menu.NoRounding = false;
            this.Menu.Sizable = true;
            this.Menu.Size = new System.Drawing.Size(284, 261);
            this.Menu.SmartBounds = true;
            this.Menu.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.Menu.TabIndex = 0;
            this.Menu.Text = "Teleporter - by CaptainAnderz";
            this.Menu.TransparencyKey = System.Drawing.Color.Empty;
            this.Menu.Transparent = false;
            // 
            // nsGroupBox1
            // 
            this.nsGroupBox1.Controls.Add(this.nsLabel2);
            this.nsGroupBox1.Controls.Add(this.TelePosition);
            this.nsGroupBox1.Controls.Add(this.nsLabel1);
            this.nsGroupBox1.Controls.Add(this.SavePosition);
            this.nsGroupBox1.DrawSeperator = true;
            this.nsGroupBox1.Location = new System.Drawing.Point(16, 59);
            this.nsGroupBox1.Name = "nsGroupBox1";
            this.nsGroupBox1.Size = new System.Drawing.Size(112, 133);
            this.nsGroupBox1.SubTitle = "Set Hotkeys";
            this.nsGroupBox1.TabIndex = 4;
            this.nsGroupBox1.Text = "nsGroupBox1";
            this.nsGroupBox1.Title = "Settings";
            // 
            // nsLabel2
            // 
            this.nsLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nsLabel2.Location = new System.Drawing.Point(5, 85);
            this.nsLabel2.Name = "nsLabel2";
            this.nsLabel2.Size = new System.Drawing.Size(84, 18);
            this.nsLabel2.TabIndex = 3;
            this.nsLabel2.Text = "nsLabel2";
            this.nsLabel2.Value1 = "Tele Position";
            this.nsLabel2.Value2 = "";
            // 
            // TelePosition
            // 
            this.TelePosition.Cursor = System.Windows.Forms.Cursors.Default;
            this.TelePosition.Location = new System.Drawing.Point(3, 102);
            this.TelePosition.MaxLength = 32767;
            this.TelePosition.Multiline = false;
            this.TelePosition.Name = "TelePosition";
            this.TelePosition.ReadOnly = false;
            this.TelePosition.Size = new System.Drawing.Size(106, 22);
            this.TelePosition.TabIndex = 2;
            this.TelePosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TelePosition.UseSystemPasswordChar = false;
            this.TelePosition.Enter += new System.EventHandler(this.TelePosition_Enter);
            this.TelePosition.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TelePosition_KeyDown);
            this.TelePosition.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TelePosition_KeyUp);
            this.TelePosition.Leave += new System.EventHandler(this.TelePosition_Leave);
            // 
            // nsLabel1
            // 
            this.nsLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nsLabel1.Location = new System.Drawing.Point(5, 41);
            this.nsLabel1.Name = "nsLabel1";
            this.nsLabel1.Size = new System.Drawing.Size(84, 18);
            this.nsLabel1.TabIndex = 1;
            this.nsLabel1.Text = "nsLabel1";
            this.nsLabel1.Value1 = "Save Position";
            this.nsLabel1.Value2 = "";
            // 
            // SavePosition
            // 
            this.SavePosition.Cursor = System.Windows.Forms.Cursors.Default;
            this.SavePosition.Location = new System.Drawing.Point(3, 58);
            this.SavePosition.MaxLength = 32767;
            this.SavePosition.Multiline = false;
            this.SavePosition.Name = "SavePosition";
            this.SavePosition.ReadOnly = false;
            this.SavePosition.Size = new System.Drawing.Size(106, 22);
            this.SavePosition.TabIndex = 0;
            this.SavePosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.SavePosition.UseSystemPasswordChar = false;
            this.SavePosition.Enter += new System.EventHandler(this.SavePosition_Enter);
            this.SavePosition.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SavePosition_KeyDown);
            this.SavePosition.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SavePosition_KeyUp);
            this.SavePosition.Leave += new System.EventHandler(this.SavePosition_Leave);
            // 
            // GroupBox
            // 
            this.GroupBox.Controls.Add(this.TeleportButton);
            this.GroupBox.Controls.Add(this.SaveButton);
            this.GroupBox.DrawSeperator = true;
            this.GroupBox.Location = new System.Drawing.Point(146, 59);
            this.GroupBox.Name = "GroupBox";
            this.GroupBox.Size = new System.Drawing.Size(126, 133);
            this.GroupBox.SubTitle = " ";
            this.GroupBox.TabIndex = 3;
            this.GroupBox.Text = "TeleporterButtons";
            this.GroupBox.Title = "Teleport";
            // 
            // TeleportButton
            // 
            this.TeleportButton.Location = new System.Drawing.Point(3, 96);
            this.TeleportButton.Name = "TeleportButton";
            this.TeleportButton.Size = new System.Drawing.Size(119, 35);
            this.TeleportButton.TabIndex = 1;
            this.TeleportButton.Text = "Teleport";
            this.TeleportButton.Click += new System.EventHandler(this.TeleportButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(3, 51);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SaveButton.Size = new System.Drawing.Size(119, 35);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "Save";
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // nsControlButton1
            // 
            this.nsControlButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nsControlButton1.ControlButton = NSControlButton.Button.Close;
            this.nsControlButton1.Location = new System.Drawing.Point(261, 4);
            this.nsControlButton1.Margin = new System.Windows.Forms.Padding(0);
            this.nsControlButton1.MaximumSize = new System.Drawing.Size(18, 20);
            this.nsControlButton1.MinimumSize = new System.Drawing.Size(18, 20);
            this.nsControlButton1.Name = "nsControlButton1";
            this.nsControlButton1.Size = new System.Drawing.Size(18, 20);
            this.nsControlButton1.TabIndex = 2;
            this.nsControlButton1.Text = "nsControlButton1";
            this.nsControlButton1.Click += new System.EventHandler(this.nsControlButton1_Click);
            // 
            // GameStatus
            // 
            this.GameStatus.AutoSize = true;
            this.GameStatus.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameStatus.ForeColor = System.Drawing.Color.White;
            this.GameStatus.Location = new System.Drawing.Point(89, 40);
            this.GameStatus.Margin = new System.Windows.Forms.Padding(3);
            this.GameStatus.Name = "GameStatus";
            this.GameStatus.Size = new System.Drawing.Size(39, 13);
            this.GameStatus.TabIndex = 1;
            this.GameStatus.Text = "Status";
            // 
            // GameName
            // 
            this.GameName.AutoSize = true;
            this.GameName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameName.ForeColor = System.Drawing.Color.White;
            this.GameName.Location = new System.Drawing.Point(13, 39);
            this.GameName.Margin = new System.Windows.Forms.Padding(3);
            this.GameName.Name = "GameName";
            this.GameName.Size = new System.Drawing.Size(79, 13);
            this.GameName.TabIndex = 0;
            this.GameName.Text = "Mirror\'s Edge:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.Menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.nsGroupBox1.ResumeLayout(false);
            this.GroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private NSTheme Menu;
        private System.Windows.Forms.Label GameStatus;
        private System.Windows.Forms.Label GameName;
        private NSControlButton nsControlButton1;
        private System.Windows.Forms.Timer CheckGameStatus;
        private NSGroupBox nsGroupBox1;
        private NSGroupBox GroupBox;
        private NSTextBox SavePosition;
        private NSLabel nsLabel1;
        private NSLabel nsLabel2;
        private NSTextBox TelePosition;
        private NSButton TeleportButton;
        private NSButton SaveButton;

    }
}

