using Microsoft.VisualStudio.TestTools.UnitTesting;
using Podium.Core.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Podium.Core.Test.Utility
{
    [TestClass]
    public class PodiumUtilityTest
    {
        [TestMethod]
        public void CalculateLTV_Should_Calculate_LTV_Equal_90()
        {
            
            var expect = 90;
            var result = PodiumUtility.CalculateLTV(100000, 10000);

            Assert.AreEqual(expect, result);
        }

        [TestMethod]
        public void CalculateLTV_Should_Calculate_LTV_Below_90()
        {

           
            var data = PodiumUtility.CalculateLTV(100000, 10001);
            var expect = true;
            var result = (data < 90);

            Assert.AreEqual(expect, result);
        }
        [TestMethod]
        public void CalculateLTV_Should_Calculate_LTV_Below_60()
        {


            var data = PodiumUtility.CalculateLTV(100000, 40001);
            var expect = true;
            var result = (data < 90);

            Assert.AreEqual(expect, result);
        }

        [TestMethod]
        public void IsUnder18_Should_Answer_Yes()
        {
            var expect = true;
            var result = PodiumUtility.IsUnder18(DateTime.Parse("2015-05-05"));

            Assert.AreEqual(expect, result);
        }

        [TestMethod]
        public void IsUnder18_Should_Answer_No()
        {
            var expect = false;
            var result = PodiumUtility.IsUnder18(DateTime.Parse("2000-05-05"));

            Assert.AreEqual(expect, result);
        }



    }
}
