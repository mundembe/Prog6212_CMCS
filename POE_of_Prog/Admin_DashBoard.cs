using System;
using System.Windows.Forms;
using POE_of_Prog.Models;
using POE_of_Prog.Services;

namespace POE_of_Prog
{
    public partial class Admin_DashBoard : Form
    {
        private readonly DataService _dataService = new DataService();

        public Admin_DashBoard()
        {
            InitializeComponent();
        }

        private void VerifyClaim_Click(object sender, EventArgs e)
        {
            var claims = _dataService.GetClaimsWithLecturerDetails();
            dataGridView1.DataSource = claims;
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            var approval = new Approval
            {
                AdminId = int.Parse(ADmin.Text),
                ClaimId = int.Parse(Claim.Text),
                Decision = "Pending"
            };

            _dataService.AddApproval(approval);
            MessageBox.Show("Status has been successfully saved");
            var approvals = _dataService.GetApprovals();
            dataGridView2.DataSource = approvals;
        }

        private void Status_Click(object sender, EventArgs e)
        {
            var approvals = _dataService.GetApprovals();
            dataGridView2.DataSource = approvals;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string approval = Approval_ID.Text;
            if (!string.IsNullOrEmpty(approval))
            {
                int approvalId = int.Parse(approval);
                _dataService.UpdateApprovalDecision(approvalId, "Approved");
                var approvals = _dataService.GetApprovals();
                dataGridView2.DataSource = approvals;
                MessageBox.Show($"Approval_ID {approval} has been successfully Approved");
            }
            else
            {
                MessageBox.Show("Fill up the Approval ID field");
            }
        }

        private void reject_Click(object sender, EventArgs e)
        {
            string approval = Approval_ID.Text;
            if (!string.IsNullOrEmpty(approval))
            {
                int approvalId = int.Parse(approval);
                _dataService.UpdateApprovalDecision(approvalId, "Rejected");
                var approvals = _dataService.GetApprovals();
                dataGridView2.DataSource = approvals;
                MessageBox.Show($"Approval_ID {approval} has been Rejected");
            }
            else
            {
                MessageBox.Show("Fill up the Approval ID field");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
