using System;

namespace POE_of_Prog.Models
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Address { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
    }
}