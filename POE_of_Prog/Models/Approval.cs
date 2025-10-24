using System;

namespace POE_of_Prog.Models
{
    public class Approval
    {
        public int ApprovalId { get; set; }
        public int AdminId { get; set; }
        public int ClaimId { get; set; }
        public string Decision { get; set; } = "";
    }
}