using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims
{
    public class Claim
    {
        public int ClaimID { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime DateOfAccident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                TimeSpan timeSpan = DateOfClaim - DateOfAccident;
                double totalDays = timeSpan.TotalDays;
                if (totalDays < 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        public Claim() {}
        //If claimSpan = 30+ days then IsValid =  false
        //claimSpan = DateOfClaim - DateOfAccident
        public Claim(int claimID, string type, string description, double amount, DateTime dateOfAccident, DateTime dateOfClaim, bool isValid)
        {
            ClaimID = claimID;
            Type = type;
            Description = description;
            Amount = amount;
            DateOfAccident = dateOfAccident;
            DateOfClaim = dateOfAccident;
        }

    }
}
