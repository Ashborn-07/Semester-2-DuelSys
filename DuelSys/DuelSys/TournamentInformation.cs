﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using LogicLayer;
using DataAccessLayer;

namespace DuelSys
{
    public partial class TournamentInformation : Form
    {
        private TournamentService service;
        private Tournament tournament;

        public TournamentInformation(Tournament tournament)
        {
            InitializeComponent();

            ITournamentRepository tournamentRepository = new TournamentRepository(ConfigurationManager.
                ConnectionStrings["phpma"].ToString());
            service = new TournamentService(tournamentRepository);

            this.tournament = tournament;
        }

        private void TournamentInformation_Load(object sender, EventArgs e)
        {
            tbTournamentName.Text = tournament.Name;
            tbDescription.Text = tournament.Description;
            tbLocation.Text = tournament.Location;
        }

        public void Alert(string msg, enmType type)
        {
            Notification frm = new Notification();
            frm.showAlert(msg, type);
        }

        private void btnUpdateTournament_Click(object sender, EventArgs e)
        {
            Tournament newTournament = tournament;
            newTournament.Name = tbTournamentName.Text;
            newTournament.Description = tbDescription.Text;
            newTournament.Location = tbLocation.Text;

            try
            {
                service.UpdateTournament(tournament);
            } catch (ConnectionException ex)
            {
                Alert(ex.Message, enmType.Error);
            }
        }

        private void btnDeleteTournament_Click(object sender, EventArgs e)
        {
            ConfirmationForm confirmationForm = new ConfirmationForm(tournament, service);
            confirmationForm.ShowDialog();
        }
    }
}
