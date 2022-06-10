namespace DuelSys
{
    partial class ScheduleForm
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
            this.flPanelTournamentSchedule = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flPanelTournamentSchedule
            // 
            this.flPanelTournamentSchedule.AutoScroll = true;
            this.flPanelTournamentSchedule.Location = new System.Drawing.Point(12, 12);
            this.flPanelTournamentSchedule.Name = "flPanelTournamentSchedule";
            this.flPanelTournamentSchedule.Size = new System.Drawing.Size(772, 469);
            this.flPanelTournamentSchedule.TabIndex = 1;
            // 
            // ScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(53)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(806, 588);
            this.Controls.Add(this.flPanelTournamentSchedule);
            this.Name = "ScheduleForm";
            this.Text = "ScheduleForm";
            this.Load += new System.EventHandler(this.ScheduleForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel flPanelTournamentSchedule;
    }
}