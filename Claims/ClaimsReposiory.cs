using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims
{
    public class ClaimsReposiory
    {
        protected readonly Queue<Claim> _claimQueue = new Queue<Claim>();
        public bool AddClaim(Claim claim)
        {
            int queueLength = _claimQueue.Count();
            _claimQueue.Enqueue(claim);
            bool claimAdded = queueLength + 1 == _claimQueue.Count();
            return claimAdded;
        }

        public Queue<Claim> SeeAllClaims()
        {
            return _claimQueue;
        }

        public bool TakeNextClaim()
        {
            int queueLength = _claimQueue.Count();
            _claimQueue.Dequeue();
            bool claimTaken = queueLength - 1 == _claimQueue.Count();
            return claimTaken;
        }

        public string PeekClaim(Claim claim)
        {
           _claimQueue.Peek();
           return ($"{claim.ClaimID} {claim.Type} {claim.Description} {claim.Amount} {claim.DateOfAccident} {claim.DateOfClaim} {claim.IsValid}");
        }
    }
}