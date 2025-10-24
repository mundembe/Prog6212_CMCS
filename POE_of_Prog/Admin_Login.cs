using System;
using System.Windows.Forms;
using POE_of_Prog.Services;

namespace POE_of_Prog
{
    public partial class Admin_Login : Form
    {
        public Admin_Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Adimi_Registration adimi_Registration = new Adimi_Registration();
            adimi_Registration.Show();
        }

        private readonly DataService _dataService = new DataService();

        private void Login_Click(object sender, EventArgs e)
        {
            string username = Username.Text;
            string password = Password.Text;

            var admin = _dataService.GetAdmin(username, password);
            if (admin != null)
            {
                Admin_DashBoard admin_DashBoard = new Admin_DashBoard();
                admin_DashBoard.Show();
            }
            else
            {
                MessageBox.Show("Enter the correct username and password");
            }
        }
    }
}
