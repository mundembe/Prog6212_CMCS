using System;

namespace POE_of_Prog.Models
{
    public class Claim
    {
        public int ClaimId { get; set; }
        public string Course { get; set; } = "";
        public int SessionNumber { get; set; }
        public decimal HourlyRate { get; set; }
        public string ClaimType { get; set; } = "";
        public string SupportiveDocument { get; set; } = "";
        public int LecturerId { get; set; }
    }
}