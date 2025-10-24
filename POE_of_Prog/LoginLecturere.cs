using System;
using System.Windows.Forms;
using POE_of_Prog.Services;
using POE_of_Prog.Models;

namespace POE_of_Prog
{
    public partial class LoginLecturere : Form
    {
        public LoginLecturere()
        {
            InitializeComponent();
            string password = Password.Text;
        }

        private void LoginLecturere_Load(object sender, EventArgs e)
        {

        }

        private readonly DataService _dataService = new DataService();

        private void Submit_Click(object sender, EventArgs e)
        {
            string username = Username.Text;
            string password = Password.Text;

            var lecturer = _dataService.GetLecturer(username, password);

            if (lecturer != null)
            {
                var dashBoard = new Lecturer_DashBoard();
                dashBoard.ShowDialog();
            }
            else
            {
                MessageBox.Show("Enter the correct username and password");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Username.Text = "";
            Password.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
           this.Close();

        }
    }
}
