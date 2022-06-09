namespace DuelSys
{
    partial class TournamentInformation
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
            this.label3 = new System.Windows.Forms.Label();
            this.tbLocation = new ReaLTaiizor.Controls.TextBoxEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTournamentName = new ReaLTaiizor.Controls.TextBoxEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDescription = new ReaLTaiizor.Controls.TextBoxEdit();
            this.btnDeleteTournament = new ReaLTaiizor.Controls.Button();
            this.btnUpdateTournament = new ReaLTaiizor.Controls.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 222);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 21);
            this.label3.TabIndex = 25;
            this.label3.Text = "Tournament Location:";
            // 
            // tbLocation
            // 
            this.tbLocation.BackColor = System.Drawing.Color.Transparent;
            this.tbLocation.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbLocation.ForeColor = System.Drawing.Color.White;
            this.tbLocation.Image = null;
            this.tbLocation.Location = new System.Drawing.Point(12, 256);
            this.tbLocation.Margin = new System.Windows.Forms.Padding(4);
            this.tbLocation.MaxLength = 32767;
            this.tbLocation.Multiline = false;
            this.tbLocation.Name = "tbLocation";
            this.tbLocation.ReadOnly = false;
            this.tbLocation.Size = new System.Drawing.Size(311, 43);
            this.tbLocation.TabIndex = 24;
            this.tbLocation.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbLocation.UseSystemPasswordChar = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 21);
            this.label1.TabIndex = 27;
            this.label1.Text = "Tournament Name:";
            // 
            // tbTournamentName
            // 
            this.tbTournamentName.BackColor = System.Drawing.Color.Transparent;
            this.tbTournamentName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbTournamentName.ForeColor = System.Drawing.Color.White;
            this.tbTournamentName.Image = null;
            this.tbTournamentName.Location = new System.Drawing.Point(13, 42);
            this.tbTournamentName.Margin = new System.Windows.Forms.Padding(4);
            this.tbTournamentName.MaxLength = 32767;
            this.tbTournamentName.Multiline = false;
            this.tbTournamentName.Name = "tbTournamentName";
            this.tbTournamentName.ReadOnly = false;
            this.tbTournamentName.Size = new System.Drawing.Size(311, 43);
            this.tbTournamentName.TabIndex = 26;
            this.tbTournamentName.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbTournamentName.UseSystemPasswordChar = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 21);
            this.label2.TabIndex = 29;
            this.label2.Text = "Tournament Description:";
            // 
            // tbDescription
            // 
            this.tbDescription.BackColor = System.Drawing.Color.Transparent;
            this.tbDescription.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbDescription.ForeColor = System.Drawing.Color.White;
            this.tbDescription.Image = null;
            this.tbDescription.Location = new System.Drawing.Point(12, 113);
            this.tbDescription.MaxLength = 32767;
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ReadOnly = false;
            this.tbDescription.Size = new System.Drawing.Size(242, 106);
            this.tbDescription.TabIndex = 28;
            this.tbDescription.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbDescription.UseSystemPasswordChar = false;
            // 
            // btnDeleteTournament
            // 
            this.btnDeleteTournament.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteTournament.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnDeleteTournament.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteTournament.Image = null;
            this.btnDeleteTournament.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteTournament.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnDeleteTournament.Location = new System.Drawing.Point(192, 318);
            this.btnDeleteTournament.Name = "btnDeleteTournament";
            this.btnDeleteTournament.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnDeleteTournament.Size = new System.Drawing.Size(174, 51);
            this.btnDeleteTournament.TabIndex = 30;
            this.btnDeleteTournament.Text = "- Delete Tournament";
            this.btnDeleteTournament.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnDeleteTournament.Click += new System.EventHandler(this.btnDeleteTournament_Click);
            // 
            // btnUpdateTournament
            // 
            this.btnUpdateTournament.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdateTournament.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnUpdateTournament.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUpdateTournament.Image = null;
            this.btnUpdateTournament.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateTournament.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnUpdateTournament.Location = new System.Drawing.Point(12, 318);
            this.btnUpdateTournament.Name = "btnUpdateTournament";
            this.btnUpdateTournament.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnUpdateTournament.Size = new System.Drawing.Size(174, 51);
            this.btnUpdateTournament.TabIndex = 31;
            this.btnUpdateTournament.Text = "+ Update Tournament";
            this.btnUpdateTournament.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnUpdateTournament.Click += new System.EventHandler(this.btnUpdateTournament_Click);
            // 
            // TournamentInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(53)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(388, 381);
            this.Controls.Add(this.btnUpdateTournament);
            this.Controls.Add(this.btnDeleteTournament);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbTournamentName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbLocation);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TournamentInformation";
            this.Text = "Tournament Information";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TournamentInformation_FormClosing);
            this.Load += new System.EventHandler(this.TournamentInformation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label3;
        private ReaLTaiizor.Controls.TextBoxEdit tbLocation;
        private Label label1;
        private ReaLTaiizor.Controls.TextBoxEdit tbTournamentName;
        private Label label2;
        private ReaLTaiizor.Controls.TextBoxEdit tbDescription;
        private ReaLTaiizor.Controls.Button btnDeleteTournament;
        private ReaLTaiizor.Controls.Button btnUpdateTournament;
    }
}