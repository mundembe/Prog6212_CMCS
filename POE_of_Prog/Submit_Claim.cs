using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using POE_of_Prog.Models;
using POE_of_Prog.Services;

namespace POE_of_Prog
{
    public partial class Submit_Claim : Form
    {
        private readonly DataService _dataService = new DataService();

        public Submit_Claim()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void Submit_Click(object sender, EventArgs e)
        {

            string hourlyworked = Hourlyworked.Text;
            string course = Course.Text;
            string nu_session = Nu_session.Text;
            string rate = Rate.Text;
            string lecturer_ID = Lecturer_ID.Text;
            string claim_type = Claim_type.Text;
            string total_Claim = Total_Claim.Text;
            string suportive_document = textBox1.Text;
            if (hourlyworked == "")
            {
                MessageBox.Show("insert the  hourlyworked field!");
            }
            if (course == "")
            {
                MessageBox.Show("insert the  course field!");
            }

            if (nu_session == "")
            {
                MessageBox.Show("insert the  nu_session field!");
            }

            if (rate == "")
            {
                MessageBox.Show("insert the  rate field!");
            }

            if (lecturer_ID == "")
            {
                MessageBox.Show("insert the  lecturer_ID field!");
            }

            if (claim_type == "")
            {
                MessageBox.Show("insert the  claim_type field!");
            }

            if (total_Claim == "")
            {
                MessageBox.Show("insert the  total_Claim field!");
            }
            if (!string.IsNullOrEmpty(suportive_document) && suportive_document.Length >= 500)
            {
                MessageBox.Show("Supporting document path is too long");
            }


            if (!String.IsNullOrEmpty(hourlyworked) && !String.IsNullOrEmpty(course) && !String.IsNullOrEmpty(nu_session) && !String.IsNullOrEmpty(rate) && !String.IsNullOrEmpty(lecturer_ID) && !String.IsNullOrEmpty(claim_type) && !String.IsNullOrEmpty(total_Claim))
            {
                MessageBox.Show("Success!");
                var claim = new Claim
                {
                    Course = course,
                    SessionNumber = int.Parse(nu_session),
                    HourlyRate = decimal.Parse(rate),
                    ClaimType = claim_type,
                    SupportiveDocument = suportive_document ?? string.Empty, // Make supporting document optional
                    LecturerId = int.Parse(lecturer_ID)
                };

                _dataService.AddClaim(claim);
                MessageBox.Show("Claim successfully sent!");
                Lecturer_DashBoard lecturer_DashBoard = new Lecturer_DashBoard();
                lecturer_DashBoard.Show();
            }
            else
            {
                MessageBox.Show("Error occur");
            }
        }

        private void Submit_Claim_Load(object sender, EventArgs e)
        {

        }

        private void Upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "PDF Files|*.pdf|Word Files|*.doc;*.docx|All Files|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog.FileName;
                //Empty.Image= new Bitmap(openFileDialog.FileName);
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            Hourlyworked.Text = "";
            Course.Text = "";
            Nu_session.Text = "";
            Rate.Text = "";
            Lecturer_ID.Text = "";
            Claim_type.Text = "";
            Total_Claim.Text = "";
            textBox1.Text = "";

        }

        private void Back_Click(object sender, EventArgs e)
        {
            Lecturer_DashBoard lecturer_DashBoard = new Lecturer_DashBoard();
            lecturer_DashBoard.Show();
        }
    }
}
