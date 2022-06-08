namespace DuelSys
{
    partial class ScoreForm
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
            this.lblPlayer1 = new System.Windows.Forms.Label();
            this.lblPlayer2 = new System.Windows.Forms.Label();
            this.btnUpdateScore = new ReaLTaiizor.Controls.Button();
            this.numScorePlayer1 = new ReaLTaiizor.Controls.DungeonNumeric();
            this.numScorePlayer2 = new ReaLTaiizor.Controls.DungeonNumeric();
            this.SuspendLayout();
            // 
            // lblPlayer1
            // 
            this.lblPlayer1.AutoSize = true;
            this.lblPlayer1.ForeColor = System.Drawing.Color.White;
            this.lblPlayer1.Location = new System.Drawing.Point(13, 9);
            this.lblPlayer1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlayer1.Name = "lblPlayer1";
            this.lblPlayer1.Size = new System.Drawing.Size(19, 21);
            this.lblPlayer1.TabIndex = 0;
            this.lblPlayer1.Text = "...";
            // 
            // lblPlayer2
            // 
            this.lblPlayer2.AutoSize = true;
            this.lblPlayer2.ForeColor = System.Drawing.Color.White;
            this.lblPlayer2.Location = new System.Drawing.Point(12, 87);
            this.lblPlayer2.Name = "lblPlayer2";
            this.lblPlayer2.Size = new System.Drawing.Size(19, 21);
            this.lblPlayer2.TabIndex = 1;
            this.lblPlayer2.Text = "...";
            // 
            // btnUpdateScore
            // 
            this.btnUpdateScore.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdateScore.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnUpdateScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUpdateScore.Image = null;
            this.btnUpdateScore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateScore.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnUpdateScore.Location = new System.Drawing.Point(30, 162);
            this.btnUpdateScore.Name = "btnUpdateScore";
            this.btnUpdateScore.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnUpdateScore.Size = new System.Drawing.Size(174, 51);
            this.btnUpdateScore.TabIndex = 35;
            this.btnUpdateScore.Text = "Update Score";
            this.btnUpdateScore.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnUpdateScore.Click += new System.EventHandler(this.btnUpdateScore_Click);
            // 
            // numScorePlayer1
            // 
            this.numScorePlayer1.BackColor = System.Drawing.Color.Transparent;
            this.numScorePlayer1.BackColorA = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.numScorePlayer1.BackColorB = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.numScorePlayer1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.numScorePlayer1.ButtonForeColorA = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.numScorePlayer1.ButtonForeColorB = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.numScorePlayer1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numScorePlayer1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.numScorePlayer1.Location = new System.Drawing.Point(12, 44);
            this.numScorePlayer1.Maximum = ((long)(100));
            this.numScorePlayer1.Minimum = ((long)(0));
            this.numScorePlayer1.MinimumSize = new System.Drawing.Size(93, 28);
            this.numScorePlayer1.Name = "numScorePlayer1";
            this.numScorePlayer1.Size = new System.Drawing.Size(215, 28);
            this.numScorePlayer1.TabIndex = 36;
            this.numScorePlayer1.Text = "dungeonNumeric1";
            this.numScorePlayer1.TextAlignment = ReaLTaiizor.Controls.DungeonNumeric._TextAlignment.Near;
            this.numScorePlayer1.Value = ((long)(0));
            // 
            // numScorePlayer2
            // 
            this.numScorePlayer2.BackColor = System.Drawing.Color.Transparent;
            this.numScorePlayer2.BackColorA = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.numScorePlayer2.BackColorB = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.numScorePlayer2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.numScorePlayer2.ButtonForeColorA = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.numScorePlayer2.ButtonForeColorB = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.numScorePlayer2.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numScorePlayer2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.numScorePlayer2.Location = new System.Drawing.Point(12, 125);
            this.numScorePlayer2.Maximum = ((long)(100));
            this.numScorePlayer2.Minimum = ((long)(0));
            this.numScorePlayer2.MinimumSize = new System.Drawing.Size(93, 28);
            this.numScorePlayer2.Name = "numScorePlayer2";
            this.numScorePlayer2.Size = new System.Drawing.Size(215, 28);
            this.numScorePlayer2.TabIndex = 37;
            this.numScorePlayer2.Text = "dungeonNumeric1";
            this.numScorePlayer2.TextAlignment = ReaLTaiizor.Controls.DungeonNumeric._TextAlignment.Near;
            this.numScorePlayer2.Value = ((long)(0));
            // 
            // ScoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(53)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(239, 225);
            this.Controls.Add(this.numScorePlayer2);
            this.Controls.Add(this.numScorePlayer1);
            this.Controls.Add(this.btnUpdateScore);
            this.Controls.Add(this.lblPlayer2);
            this.Controls.Add(this.lblPlayer1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ScoreForm";
            this.Text = "ScoreForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScoreForm_FormClosing);
            this.Load += new System.EventHandler(this.ScoreForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblPlayer1;
        private Label lblPlayer2;
        private ReaLTaiizor.Controls.Button btnUpdateScore;
        private ReaLTaiizor.Controls.DungeonNumeric numScorePlayer1;
        private ReaLTaiizor.Controls.DungeonNumeric numScorePlayer2;
    }
}