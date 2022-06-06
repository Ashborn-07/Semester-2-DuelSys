namespace DuelSys
{
    partial class MatchesForm
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
            this.dgvMatches = new System.Windows.Forms.DataGridView();
            this.btnCreateSchedule = new ReaLTaiizor.Controls.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatches)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMatches
            // 
            this.dgvMatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatches.Location = new System.Drawing.Point(328, 12);
            this.dgvMatches.Name = "dgvMatches";
            this.dgvMatches.RowTemplate.Height = 25;
            this.dgvMatches.Size = new System.Drawing.Size(689, 415);
            this.dgvMatches.TabIndex = 0;
            // 
            // btnCreateSchedule
            // 
            this.btnCreateSchedule.BackColor = System.Drawing.Color.Transparent;
            this.btnCreateSchedule.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnCreateSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCreateSchedule.Image = null;
            this.btnCreateSchedule.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateSchedule.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnCreateSchedule.Location = new System.Drawing.Point(12, 376);
            this.btnCreateSchedule.Name = "btnCreateSchedule";
            this.btnCreateSchedule.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnCreateSchedule.Size = new System.Drawing.Size(174, 51);
            this.btnCreateSchedule.TabIndex = 2;
            this.btnCreateSchedule.Text = "+ Create Schedule";
            this.btnCreateSchedule.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnCreateSchedule.Click += new System.EventHandler(this.btnCreateSchedule_Click);
            // 
            // MatchesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(53)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(1029, 439);
            this.Controls.Add(this.btnCreateSchedule);
            this.Controls.Add(this.dgvMatches);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MatchesForm";
            this.Text = "MatchesForm";
            this.Load += new System.EventHandler(this.MatchesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatches)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvMatches;
        private ReaLTaiizor.Controls.Button btnCreateSchedule;
    }
}