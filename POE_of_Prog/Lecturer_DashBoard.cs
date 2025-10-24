using System;
using System.Windows.Forms;
using POE_of_Prog.Models;
using POE_of_Prog.Services;

namespace POE_of_Prog
{
    public partial class Lecturer_DashBoard : Form
    {
        private readonly DataService _dataService = new DataService();

        public Lecturer_DashBoard()
        {
            InitializeComponent();
        }

        private void Lecturer_DashBoard_Load(object sender, EventArgs e)
        {

        }

        private void Claim_Click(object sender, EventArgs e)
        {
            Submit_Claim submit_Claim = new Submit_Claim();
            submit_Claim.Show();
        }

        private void viewClaim_Click(object sender, EventArgs e)
        {
            var claims = _dataService.GetClaimsWithLecturerDetails();
            dataGridView1.DataSource = claims;
        }

        private void TrackingStatus_Click(object sender, EventArgs e)
        {
            var approvals = _dataService.GetApprovals();
            dataGridView1.DataSource = approvals;

        }

        private void Logout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
