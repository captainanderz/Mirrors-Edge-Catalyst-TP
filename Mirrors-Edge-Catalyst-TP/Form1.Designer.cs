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
            this.nsControlButton1 = new NSControlButton();
            this.GameStatus = new System.Windows.Forms.Label();
            this.GameName = new System.Windows.Forms.Label();
            this.Menu.SuspendLayout();
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
            this.ResumeLayout(false);

        }

        #endregion

        private NSTheme Menu;
        private System.Windows.Forms.Label GameStatus;
        private System.Windows.Forms.Label GameName;
        private NSControlButton nsControlButton1;
        private System.Windows.Forms.Timer CheckGameStatus;

    }
}

