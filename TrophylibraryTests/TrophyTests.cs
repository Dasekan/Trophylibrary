using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trophylibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trophylibrary.Tests
{
    [TestClass()]
    public class TrophyTests
    {
        [TestInitialize]

        [TestMethod()]
        public void CheckCompetitionForNullOrLessThan3Characters()
        {
            var trophy = new Trophy();

            // Test null input
            Assert.ThrowsException<ArgumentNullException>(() => trophy.Competition = null);

            // Test empty string
            Assert.ThrowsException<ArgumentException>(() => trophy.Competition = "");

            // Test string with less than 3 characters
            Assert.ThrowsException<ArgumentException>(() => trophy.Competition = "AB");
        }

        [TestMethod()]
        public void CheckYearForOutOfRange()
        {
            var trophy = new Trophy();

            // Test year less than 1970
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophy.Year = 1969);

            // Test year greater than 2025
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophy.Year = 2026);
        }

        [TestMethod()]
        public void ValidYearValuesAreAccepted()
        {
            var trophy = new Trophy();

            // Test boundary and mid-range years
            int[] validYears = { 1970, 2000, 2025 };
            foreach (var year in validYears)
            {
                trophy.Year = year;
                Assert.AreEqual(year, trophy.Year);
            }
        }

  

        [TestMethod()]
        public void ValidCompetitionValuesAreAccepted()
        {
            var trophy = new Trophy();

            // Test valid competition names
            string[] validCompetitions = { "ABC", "World Championship", "Olympic Games" };
            foreach (var competition in validCompetitions)
            {
                trophy.Competition = competition;
                Assert.AreEqual(competition, trophy.Competition);
            }
        }

        [TestMethod()]
        public void ToString_Test()
        {
            var trophy = new Trophy
            {
                Id = 2,
                Competition = "World Championship",
                Year = 2024
            };

            Assert.AreEqual("Trophy: Id = 2 Competition = World Championship, Year = 2024", trophy.ToString());
        }
    }
}