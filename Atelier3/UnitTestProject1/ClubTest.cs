using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;

namespace UnitTestProject1
{
    [TestClass]
    public class ClubTest
    {

        [TestMethod]
        public void ClubTestConstructorMethod()
        {
            Club club = new Club("Bordeaux");
            Assert.IsNotNull(club);
        }

        [TestMethod]
        public void ClubTestName()
        {
            Club club = new Club("Bordeaux");
            Assert.AreEqual(club.ToString(), "Bordeaux");
        }
    }
}
