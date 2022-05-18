namespace DuelSys
{
    partial class Menu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.picBoxSettings = new System.Windows.Forms.PictureBox();
            this.picBoxCup = new System.Windows.Forms.PictureBox();
            this.picboxCalendar = new System.Windows.Forms.PictureBox();
            this.btnSettings = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnSchedule = new System.Windows.Forms.Button();
            this.btnTournament = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.panelSideMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxCup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxCalendar)).BeginInit();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(64)))), ((int)(((byte)(96)))));
            this.panelSideMenu.Controls.Add(this.picBoxSettings);
            this.panelSideMenu.Controls.Add(this.picBoxCup);
            this.panelSideMenu.Controls.Add(this.picboxCalendar);
            this.panelSideMenu.Controls.Add(this.btnSettings);
            this.panelSideMenu.Controls.Add(this.button3);
            this.panelSideMenu.Controls.Add(this.btnSchedule);
            this.panelSideMenu.Controls.Add(this.btnTournament);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(259, 534);
            this.panelSideMenu.TabIndex = 0;
            // 
            // picBoxSettings
            // 
            this.picBoxSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(54)))), ((int)(((byte)(245)))));
            this.picBoxSettings.BackgroundImage = global::DuelSys.Properties.Resources.Settings_PNG_File_Download_Free;
            this.picBoxSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picBoxSettings.Location = new System.Drawing.Point(27, 315);
            this.picBoxSettings.Name = "picBoxSettings";
            this.picBoxSettings.Size = new System.Drawing.Size(56, 45);
            this.picBoxSettings.TabIndex = 7;
            this.picBoxSettings.TabStop = false;
            this.picBoxSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // picBoxCup
            // 
            this.picBoxCup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(54)))), ((int)(((byte)(245)))));
            this.picBoxCup.BackgroundImage = global::DuelSys.Properties.Resources.purepng_com_golden_cupgolden_cupgoldtrophymedal_1421526534718zlbrf;
            this.picBoxCup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picBoxCup.Location = new System.Drawing.Point(27, 141);
            this.picBoxCup.Name = "picBoxCup";
            this.picBoxCup.Size = new System.Drawing.Size(56, 46);
            this.picBoxCup.TabIndex = 6;
            this.picBoxCup.TabStop = false;
            this.picBoxCup.Click += new System.EventHandler(this.btnTournament_Click);
            // 
            // picboxCalendar
            // 
            this.picboxCalendar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(54)))), ((int)(((byte)(245)))));
            this.picboxCalendar.BackgroundImage = global::DuelSys.Properties.Resources.calendar_icon_png_4;
            this.picboxCalendar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picboxCalendar.Location = new System.Drawing.Point(27, 199);
            this.picboxCalendar.Name = "picboxCalendar";
            this.picboxCalendar.Size = new System.Drawing.Size(56, 46);
            this.picboxCalendar.TabIndex = 5;
            this.picboxCalendar.TabStop = false;
            this.picboxCalendar.Click += new System.EventHandler(this.btnSchedule_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(54)))), ((int)(((byte)(245)))));
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Location = new System.Drawing.Point(0, 309);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(259, 58);
            this.btnSettings.TabIndex = 4;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(54)))), ((int)(((byte)(245)))));
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(0, 251);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(259, 58);
            this.button3.TabIndex = 3;
            this.button3.Text = "Menu 3";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnSchedule
            // 
            this.btnSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(54)))), ((int)(((byte)(245)))));
            this.btnSchedule.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSchedule.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSchedule.ForeColor = System.Drawing.Color.White;
            this.btnSchedule.Location = new System.Drawing.Point(0, 193);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(259, 58);
            this.btnSchedule.TabIndex = 2;
            this.btnSchedule.Text = "Schedule";
            this.btnSchedule.UseVisualStyleBackColor = false;
            this.btnSchedule.Click += new System.EventHandler(this.btnSchedule_Click);
            // 
            // btnTournament
            // 
            this.btnTournament.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(54)))), ((int)(((byte)(245)))));
            this.btnTournament.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTournament.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTournament.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTournament.ForeColor = System.Drawing.Color.White;
            this.btnTournament.Location = new System.Drawing.Point(0, 135);
            this.btnTournament.Name = "btnTournament";
            this.btnTournament.Size = new System.Drawing.Size(259, 58);
            this.btnTournament.TabIndex = 1;
            this.btnTournament.Text = "Tournament";
            this.btnTournament.UseVisualStyleBackColor = false;
            this.btnTournament.Click += new System.EventHandler(this.btnTournament_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.pbLogo);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(259, 135);
            this.panelLogo.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbLogo.BackgroundImage = global::DuelSys.Properties.Resources.elden_ring;
            this.pbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(259, 135);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(53)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(1029, 534);
            this.Controls.Add(this.panelSideMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Menu";
            this.Text = "Main";
            this.panelSideMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxCup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxCalendar)).EndInit();
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelSideMenu;
        private Panel panelLogo;
        private PictureBox pbLogo;
        private Button btnTournament;
        private Button btnSettings;
        private Button button3;
        private Button btnSchedule;
        private PictureBox picboxCalendar;
        private PictureBox picBoxCup;
        private PictureBox picBoxSettings;
    }
}