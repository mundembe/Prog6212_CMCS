using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using POE_of_Prog.Models;
using POE_of_Prog.Services;

namespace POE_of_Prog
{
    public partial class Adimi_Registration : Form
    {
        private readonly DataService _dataService = new DataService();

        public Adimi_Registration()
        {
            InitializeComponent();
        }

        private void sutmit_Click(object sender, EventArgs e)
        {
            string name = Firstname.Text;
            string lastname = Lastname.Text;
            string address = Address.Text;
            string email = Email.Text;
            string phone = Phone.Text;
            string username = Username.Text;
            string password = Password.Text;

            if (name == "")
            {
                MessageBox.Show("insert the  Firstname field!");
            }
            if (lastname == "")
            {
                MessageBox.Show("insert the  lastname field!");
            }

            if (address == "")
            {
                MessageBox.Show("insert the  address field!");
            }

            if (email == "")
            {
                MessageBox.Show("insert the  email field!");
            }

            if (phone == "")
            {
                MessageBox.Show("insert the  phone field!");
            }

            if (username == "")
            {
                MessageBox.Show("insert the  username field!");
            }

            if (password == "")
            {
                MessageBox.Show("insert the  password field!");
            }

            if (!Regex.IsMatch(name, @"^[A-Za-z\s]+$"))
            {
                MessageBox.Show("Admin name should contain only letters and spaces.");
            }

            if (!Regex.IsMatch(lastname, @"^[A-Za-z\s]+$"))
            {
                MessageBox.Show("Admin Lastname should contain only letters and spaces.");
            }
            if (!Regex.IsMatch(email, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$"))
            {
                MessageBox.Show("Email should be real Email!.");
            }

            if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$"))
            {
                MessageBox.Show("Password must At least have one lowercase letter, At least one uppercase letter,At least one digi,At least one special character");
            }

            if (Regex.IsMatch(name, @"^[A-Za-z\s]+$") && Regex.IsMatch(lastname, @"^[A-Za-z\s]+$") && !String.IsNullOrEmpty(address) && Regex.IsMatch(email, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$") && !String.IsNullOrEmpty(phone) && !String.IsNullOrEmpty(username) && Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$"))
            {
                MessageBox.Show("Well done!");
                var admin = new Admin
                {
                    FirstName = name,
                    LastName = lastname,
                    Address = address,
                    Email = email,
                    Phone = phone,
                    Username = username,
                    Password = password
                };

                _dataService.AddAdmin(admin);
                MessageBox.Show("Registration successfully saved");
                Admin_DashBoard admin_DashBoard = new Admin_DashBoard();
                admin_DashBoard.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
