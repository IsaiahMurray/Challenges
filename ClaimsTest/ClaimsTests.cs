using System;
using System.Collections.Generic;
using Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClaimsTest
{
    [TestClass]
    public class ClaimsTests
    {
        Claim claim = new Claim();
        ClaimsReposiory claimsRepository = new ClaimsReposiory();

        [TestMethod]
        public void AddClaim_ShouldGetBool()
        {
            bool addClaim = claimsRepository.AddClaim(claim);
            Assert.IsTrue(addClaim);
        }

        [TestMethod]
        public void SeeClaims_ShouldReturnQueue()
        {
        }

        [TestMethod]
        public void TakeCareOfClaims_ShouldDequque()
        {
            bool takeClaim = claimsRepository.TakeNextClaim();
            Assert.IsTrue(takeClaim);
        }
    }
}
