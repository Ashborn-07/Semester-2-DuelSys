namespace DuelSys
{
    partial class UserControlScheduleTournament
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTournamentId = new System.Windows.Forms.Label();
            this.lblSport = new System.Windows.Forms.Label();
            this.lblRegisteredPlayers = new System.Windows.Forms.Label();
            this.lblTournamentName = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTournamentId);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(57, 83);
            this.panel1.TabIndex = 7;
            this.panel1.Click += new System.EventHandler(this.UserControlScheduleTournament_Click);
            // 
            // lblTournamentId
            // 
            this.lblTournamentId.AutoSize = true;
            this.lblTournamentId.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTournamentId.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTournamentId.ForeColor = System.Drawing.Color.White;
            this.lblTournamentId.Location = new System.Drawing.Point(7, 28);
            this.lblTournamentId.Name = "lblTournamentId";
            this.lblTournamentId.Size = new System.Drawing.Size(34, 21);
            this.lblTournamentId.TabIndex = 0;
            this.lblTournamentId.Text = "ID: ";
            this.lblTournamentId.Click += new System.EventHandler(this.UserControlScheduleTournament_Click);
            // 
            // lblSport
            // 
            this.lblSport.AutoSize = true;
            this.lblSport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSport.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSport.ForeColor = System.Drawing.Color.White;
            this.lblSport.Location = new System.Drawing.Point(237, 52);
            this.lblSport.Name = "lblSport";
            this.lblSport.Size = new System.Drawing.Size(59, 21);
            this.lblSport.TabIndex = 11;
            this.lblSport.Text = "Sport: ";
            this.lblSport.Click += new System.EventHandler(this.UserControlScheduleTournament_Click);
            // 
            // lblRegisteredPlayers
            // 
            this.lblRegisteredPlayers.AutoSize = true;
            this.lblRegisteredPlayers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRegisteredPlayers.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRegisteredPlayers.ForeColor = System.Drawing.Color.White;
            this.lblRegisteredPlayers.Location = new System.Drawing.Point(63, 52);
            this.lblRegisteredPlayers.Name = "lblRegisteredPlayers";
            this.lblRegisteredPlayers.Size = new System.Drawing.Size(149, 21);
            this.lblRegisteredPlayers.TabIndex = 10;
            this.lblRegisteredPlayers.Text = "Players registered: ";
            this.lblRegisteredPlayers.Click += new System.EventHandler(this.UserControlScheduleTournament_Click);
            // 
            // lblTournamentName
            // 
            this.lblTournamentName.AutoSize = true;
            this.lblTournamentName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTournamentName.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTournamentName.ForeColor = System.Drawing.Color.White;
            this.lblTournamentName.Location = new System.Drawing.Point(63, 21);
            this.lblTournamentName.Name = "lblTournamentName";
            this.lblTournamentName.Size = new System.Drawing.Size(77, 30);
            this.lblTournamentName.TabIndex = 9;
            this.lblTournamentName.Text = "Label1";
            this.lblTournamentName.Click += new System.EventHandler(this.UserControlScheduleTournament_Click);
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblEndTime.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEndTime.ForeColor = System.Drawing.Color.White;
            this.lblEndTime.Location = new System.Drawing.Point(9, 52);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(45, 21);
            this.lblEndTime.TabIndex = 5;
            this.lblEndTime.Text = "End: ";
            this.lblEndTime.Click += new System.EventHandler(this.UserControlScheduleTournament_Click);
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblStartTime.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStartTime.ForeColor = System.Drawing.Color.White;
            this.lblStartTime.Location = new System.Drawing.Point(3, 15);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(53, 21);
            this.lblStartTime.TabIndex = 4;
            this.lblStartTime.Text = "Start: ";
            this.lblStartTime.Click += new System.EventHandler(this.UserControlScheduleTournament_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblEndTime);
            this.panel2.Controls.Add(this.lblStartTime);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(427, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(188, 83);
            this.panel2.TabIndex = 8;
            this.panel2.Click += new System.EventHandler(this.UserControlScheduleTournament_Click);
            // 
            // UserControlScheduleTournament
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(151)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblSport);
            this.Controls.Add(this.lblRegisteredPlayers);
            this.Controls.Add(this.lblTournamentName);
            this.Controls.Add(this.panel2);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "UserControlScheduleTournament";
            this.Size = new System.Drawing.Size(615, 83);
            this.Load += new System.EventHandler(this.UserControlScheduleTournament_Load);
            this.DoubleClick += new System.EventHandler(this.UserControlScheduleTournament_Click);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private Label lblTournamentId;
        private Label lblSport;
        private Label lblRegisteredPlayers;
        private Label lblTournamentName;
        private Label lblEndTime;
        private Label lblStartTime;
        private Panel panel2;
    }
}
