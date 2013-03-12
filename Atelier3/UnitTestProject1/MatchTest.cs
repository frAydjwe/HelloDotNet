using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;

namespace UnitTestProject1
{
    [TestClass]
    public class MatchTest
    {
        // , ExpectedException(typeof(...)
        [TestMethod]
        public void MatchTestConstructorMethod()
        {
            Club bdx = new Club ("Bordeaux");
            Club tlse = new Club ("Toulouse");
            Match match = new Match(bdx, 3, 2, tlse);
            Assert.IsNotNull(match);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "forfeit team should be included in match")]

        public void MatchTestWrongConstructorMethod()
        {
            Club bdx = new Club("Bordeaux");
            Club tlse = new Club("Toulouse");
            Club marseille = new Club("Marseille");
            Match match = new Match(bdx, tlse, marseille);
        }

        [TestMethod]
        public void MatchTestNotDraw()
        {
            Club bdx = new Club("Bordeaux");
            Club tlse = new Club("Toulouse");
            Match match = new Match(bdx, 3, 2, tlse);
            Assert.AreEqual(match.IsDraw, false);
        }

        [TestMethod]
        public void MatchTestDraw()
        {
            Club bdx = new Club("Bordeaux");
            Club tlse = new Club("Toulouse");
            Match match = new Match(bdx, 3, 3, tlse);
            Assert.AreEqual(match.IsDraw, true);
        }
        [TestMethod]
        public void MatchTestAway()
        {
            Club bdx = new Club("Bordeaux");
            Club tlse = new Club("Toulouse");
            Match match = new Match(bdx, 3, 2, tlse);
            Assert.AreEqual(match.Away.ToString(), "Toulouse");
        }
        [TestMethod]
        public void MatchTestAwayGoal()
        {
            Club bdx = new Club("Bordeaux");
            Club tlse = new Club("Toulouse");
            Match match = new Match(bdx, 3, 2, tlse);
            Assert.AreEqual(match.AwayGoal, 2);
        }
        [TestMethod]
        public void MatchTestHomeGoal()
        {
            Club bdx = new Club("Bordeaux");
            Club tlse = new Club("Toulouse");
            Match match = new Match(bdx, 3, 2, tlse);
            Assert.AreEqual(match.HomeGoals, 3);
        }
        [TestMethod]
        public void MatchTestIsAwayForfeitWithLegalMatch()
        {
            Club bdx = new Club("Bordeaux");
            Club tlse = new Club("Toulouse");
            Match match = new Match(bdx, 3, 2, tlse);
            Assert.IsFalse(match.IsAwayForfeit);
        }
        [TestMethod]
        public void MatchTestIsAwayForfeitWithoutLegalMatch()
        {
            Club bdx = new Club("Bordeaux");
            Club tlse = new Club("Toulouse");
            Match match = new Match(bdx,tlse,tlse);
            Assert.IsTrue(match.IsAwayForfeit);
        }
        [TestMethod]
        public void MatchTestIsHomeForfeitWithoutLegalMatch()
        {
            Club bdx = new Club("Bordeaux");
            Club tlse = new Club("Toulouse");
            Match match = new Match(bdx,tlse,bdx);
            Assert.IsTrue(match.IsHomeForfeit);
        }
    }
}
