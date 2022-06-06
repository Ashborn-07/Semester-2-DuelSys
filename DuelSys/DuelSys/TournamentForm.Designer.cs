namespace DuelSys
{
    partial class TournamentForm
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
            this.flPanelTournament = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCreateTournament = new ReaLTaiizor.Controls.Button();
            this.SuspendLayout();
            // 
            // flPanelTournament
            // 
            this.flPanelTournament.Location = new System.Drawing.Point(22, 12);
            this.flPanelTournament.Name = "flPanelTournament";
            this.flPanelTournament.Size = new System.Drawing.Size(772, 469);
            this.flPanelTournament.TabIndex = 0;
            // 
            // btnCreateTournament
            // 
            this.btnCreateTournament.BackColor = System.Drawing.Color.Transparent;
            this.btnCreateTournament.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnCreateTournament.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCreateTournament.Image = null;
            this.btnCreateTournament.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateTournament.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnCreateTournament.Location = new System.Drawing.Point(620, 525);
            this.btnCreateTournament.Name = "btnCreateTournament";
            this.btnCreateTournament.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnCreateTournament.Size = new System.Drawing.Size(174, 51);
            this.btnCreateTournament.TabIndex = 1;
            this.btnCreateTournament.Text = "+ Create Tournament";
            this.btnCreateTournament.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnCreateTournament.Click += new System.EventHandler(this.btnCreateTournament_Click);
            // 
            // TournamentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(53)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(806, 588);
            this.Controls.Add(this.btnCreateTournament);
            this.Controls.Add(this.flPanelTournament);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TournamentForm";
            this.Text = "Tournament";
            this.Load += new System.EventHandler(this.Tournament_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel flPanelTournament;
        private ReaLTaiizor.Controls.Button btnCreateTournament;
    }
}