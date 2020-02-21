using Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsUI
{
    public class ProgramUI
    {
        private readonly ClaimsReposiory _claimsReposiory = new ClaimsReposiory();
        private readonly Queue<Claim> _claims = new Queue<Claim>();

        public void Run()
        {
            SeedContent();
            RunMenu();
           
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Choose a menu item:\n" +
                    "1.See all claims\n" +
                    "2.Take care of next claim\n" +
                    "3.Enter a new claim\n" +
                    "4.Exit");

                string userInput = Console.ReadLine();
                userInput = userInput.Replace(" ", "");
                switch (userInput)
                {
                    case "1":
                        ViewClaims();
                        break;

                    case "2":
                        TakeNextClaim();
                        break;

                    case "3":
                        AddClaim();
                        break;

                    case "4":
                        continueToRun = false;
                        break;

                    default:
                        break;
                }
            }
        }

        private void ViewClaims()
        {
            Console.Clear();
            Queue<Claim> claimQ = _claimsReposiory.SeeAllClaims();

            Console.WriteLine("ClaimID	Type	Description	Amount	DateOfAccident	DateOfClaim	IsValid");

            if (claimQ.Count > 0)
            {
                foreach (Claim claim in claimQ)
                {
                    Console.WriteLine($"{claim.ClaimID} {claim.Type} {claim.Description} {claim.Amount} {claim.DateOfAccident} {claim.DateOfClaim} {claim.IsValid}");
                    
                }
                Console.WriteLine("Now type something and go away");
                Console.ReadKey();
            }

            else
            {
                Console.WriteLine("There are no claims to take care of. Press a key and leave please.");
                Console.ReadKey();
            }
        }

        private void TakeNextClaim()
        {
            Console.Clear();
            Queue<Claim> claimQ = _claimsReposiory.SeeAllClaims();

            if (claimQ.Count > 0)
            {
                Claim claimP = claimQ.Peek();

                Console.WriteLine($"Here are the details for the next claim to be handled: \n" +
                    $"{claimP.ClaimID} {claimP.Type} {claimP.Description} {claimP.Amount} {claimP.DateOfAccident} {claimP.DateOfClaim} {claimP.IsValid}");
                Console.WriteLine("Do you want to deal with this claim now(y/n)?");
                string userInput = Console.ReadLine();
                userInput = userInput.Replace(" ", "");
                switch (userInput)
                {
                    case "y":
                        _claimsReposiory.TakeNextClaim();
                        break;

                    case "n":
                        RunMenu();
                        break;

                    default:
                        RunMenu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("There are no claims to take care of. Press a key and leave please.");
                Console.ReadKey();
            }
        }

        private void AddClaim()
        {
            Claim claim = new Claim();
            Console.Clear();

            Console.WriteLine("Enter the claim id(whole numbers only):");
            string idInput = Console.ReadLine();
            int.Parse(idInput);

            Console.WriteLine("Is the claim type of Car, Home, or Theft?");
            string typeInput = Console.ReadLine();
            typeInput = typeInput.Replace(" ", "");
            typeInput = typeInput.ToLower();
            switch (typeInput)
            {
                case "car":
                    claim.Type = "Car";
                    break;
                case "home":
                    claim.Type = "Home";
                    break;
                case "theft":
                    claim.Type = "Theft";
                    break;
            }

            Console.WriteLine("Please enter a description of the claim");
            claim.Description = Console.ReadLine();


            Console.WriteLine("What is amount of money are you are trying to get?");
            string amountInput = Console.ReadLine();
            double.Parse(amountInput);
            claim.Description = amountInput;

            string inputA;
            DateTime outputA;
            Console.WriteLine("Enter the Date of the accident in this Format(YYYY-MM-DD): ");
            inputA = Console.ReadLine();
            outputA = Convert.ToDateTime(inputA);
            claim.DateOfAccident = outputA;

            string inputC;
            DateTime outputC;
            Console.WriteLine("Enter the Date of the claim in this Format(YYYY-MM-DD): ");
            inputC = Console.ReadLine();
            outputC = Convert.ToDateTime(inputC);
            claim.DateOfClaim = outputC;

            if (claim.IsValid)
            {
                Console.WriteLine("This claim is valid.");
            }
            else
            {
                Console.WriteLine("This claim is not valid.");
            }

            _claimsReposiory.AddClaim(claim);
            Console.WriteLine("Your claim has been processed! Now press something and go away!");
            Console.ReadKey();
        }

        private void SeedContent()
        {
            Claim claim = new Claim(34, "car", "hit a parked car", 1000000.23, new DateTime(1997, 09, 05), new DateTime(2020, 02, 02), false);
            _claimsReposiory.AddClaim(claim);
        }
    }
}
