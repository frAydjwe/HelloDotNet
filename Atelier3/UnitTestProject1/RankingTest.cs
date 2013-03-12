using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;

namespace UnitTestProject1
{
    [TestClass]
    public class RankingTest
    {
        [TestMethod]
        public void RankingTestConstructorMethod()
        {
            FrenchLeague1PointSystem ptLeague = new FrenchLeague1PointSystem();

            // clubs
            Club bdx = new Club("Bordeaux");
            Club tlse = new Club("Toulouse");
            Club[] clubs = new Club[10];
            clubs[0] = bdx; clubs[1] = tlse;

            // ranking
            Ranking rk = new Ranking(ptLeague, clubs);
            Assert.IsNotNull(rk);
        }

        [TestMethod]
        public void RankingTestPremierMatchGagneDesPoints()
        {
            FrenchLeague1PointSystem ptLeague = new FrenchLeague1PointSystem();

            // clubs
            Club bdx = new Club("Bordeaux");
            Club tlse = new Club("Toulouse");
            Club[] clubs = new Club[10];
            clubs[0] = bdx; clubs[1] = tlse;
            Match match = new Match(bdx, 3,2,tlse);

            // ranking
            Ranking rk = new Ranking(ptLeague, clubs);
            rk.Register(match);
 
            Assert.AreNotEqual(rk.GetPoints(bdx),ptLeague.InitialPoints);
        }
        [TestMethod]
        public void RankingTestPremierMatchGagneEncorePlusDePoints()
        {
            FrenchLeague1PointSystem ptLeague = new FrenchLeague1PointSystem();
  
            // clubs
            Club bdx = new Club("Bordeaux");
            Club tlse = new Club("Toulouse");
            Club[] clubs = new Club[2];
            clubs[0] = bdx; clubs[1] = tlse;

            // matchs
            Match match = new Match(bdx, 2, 2, tlse);
            Match match2 = new Match(tlse, 3, 5, bdx);

            // ranking
            Ranking rk = new Ranking(ptLeague, clubs);
            rk.Register(match);
            rk.Register(match2);

            Assert.AreEqual(rk.GetPoints(bdx).ToString(),"Pts:4-Average:2");
        }

        [TestMethod]
        public void RankingTestCompareToBordeauxMeilleurQueToulouse()
        {
            FrenchLeague1PointSystem ptLeague = new FrenchLeague1PointSystem();

            // clubs
            Club bdx = new Club("Bordeaux");
            Club tlse = new Club("Toulouse");
            Club[] clubs = new Club[2];
            clubs[0] = bdx; clubs[1] = tlse;

            // matchs
            Match match = new Match(bdx, 2, 2, tlse);
            Match match2 = new Match(tlse, 3, 5, bdx);

            // ranking
            Ranking rk = new Ranking(ptLeague, clubs);
            rk.Register(match);
            rk.Register(match2);

            Assert.AreEqual(rk.GetPoints(bdx).CompareTo(rk.GetPoints(tlse)),1);
        }


        [TestMethod]
        public void RankingTestCompareToPerfectDrawAndForfeit()
        {
            FrenchLeague1PointSystem ptLeague = new FrenchLeague1PointSystem();

            // clubs
            Club bdx = new Club("Bordeaux");
            Club tlse = new Club("Toulouse");
            Club psg = new Club("Paris Saint-Germain");
            Club montpellier = new Club("Montpellier");
            Club marseille = new Club("Marseille");
            Club lyon = new Club("Lyon");

            Club[] clubs = new Club[6];
            clubs[0] = bdx; clubs[1] = tlse; clubs[2] = psg; clubs[3] = montpellier; clubs[4] = marseille; clubs[5] = lyon;

            // matchs 1er journee
            Match match = new Match(bdx, 2, 0, tlse);
            Match match2 = new Match(montpellier, 1, 2, bdx);
            Match match3 = new Match(psg, 3, 2, marseille);
            Match match4 = new Match(lyon, 2, 0, marseille);
            Match match5 = new Match(lyon, 1, 2, tlse);
            Match match6 = new Match(montpellier, 1, 2, psg);

            // matchs 2e journee
            Match match7 = new Match(marseille, 2, 0, bdx);
            Match match8 = new Match(bdx, 1, 1, lyon);
            Match match9 = new Match(montpellier, 3, 2, marseille);
            Match match10 = new Match(lyon, 0, 0, psg);
            Match match11 = new Match(tlse, 0, 3, montpellier);
            Match match12 = new Match(psg, 1, 2, tlse);

            // ranking
            Ranking rk = new Ranking(ptLeague, clubs);
            rk.Register(match);
            rk.Register(match2);
            rk.Register(match3);
            rk.Register(match4);
            rk.Register(match5);
            rk.Register(match6);
            rk.Register(match7);
            rk.Register(match8);
            rk.Register(match9);
            rk.Register(match10);
            rk.Register(match11);
            rk.Register(match12);

            Assert.AreEqual(rk.GetPoints(bdx).CompareTo(rk.GetPoints(tlse)), 1);    // bdx meilleur que toulouse
            Assert.AreEqual(rk.GetPoints(bdx).CompareTo(rk.GetPoints(psg)), 0); // égalité parfaite

            Match match13 = new Match(psg, montpellier, montpellier);
            rk.Register(match13);

            Assert.AreEqual(rk.GetPoints(bdx).CompareTo(rk.GetPoints(psg)), -1); // test du match forfait gagnant pour psg

            // marseille lanterne rouge
            Assert.AreEqual(rk.GetPoints(marseille).CompareTo(rk.GetPoints(psg)), -1);
            Assert.AreEqual(rk.GetPoints(marseille).CompareTo(rk.GetPoints(montpellier)), -1);
            Assert.AreEqual(rk.GetPoints(marseille).CompareTo(rk.GetPoints(lyon)), -1);
            Assert.AreEqual(rk.GetPoints(marseille).CompareTo(rk.GetPoints(bdx)), -1);
            Assert.AreEqual(rk.GetPoints(marseille).CompareTo(rk.GetPoints(tlse)), -1);
        }

        [TestMethod]
        public void RankingTestRankingClubs()
        {
            FrenchLeague1PointSystem ptLeague = new FrenchLeague1PointSystem();

            // clubs
            Club bdx = new Club("Bordeaux");
            Club tlse = new Club("Toulouse");
            Club psg = new Club("Paris Saint-Germain");
            Club montpellier = new Club("Montpellier");
            Club marseille = new Club("Marseille");
            Club lyon = new Club("Lyon");

            Club[] clubs = new Club[6];
            clubs[0] = bdx; clubs[1] = tlse; clubs[2] = psg; clubs[3] = montpellier; clubs[4] = marseille; clubs[5] = lyon;

            // matchs 1er journee
            Match match = new Match(bdx, 2, 0, tlse);
            Match match2 = new Match(montpellier, 1, 2, bdx);
            Match match3 = new Match(psg, 3, 2, marseille);
            Match match4 = new Match(lyon, 2, 0, marseille);
            Match match5 = new Match(lyon, 1, 2, tlse);
            Match match6 = new Match(montpellier, 1, 2, psg);

            // matchs 2e journee
            Match match7 = new Match(marseille, 2, 0, bdx);
            Match match8 = new Match(bdx, 1, 1, lyon);
            Match match9 = new Match(montpellier, 3, 2, marseille);
            Match match10 = new Match(lyon, 0, 0, psg);
            Match match11 = new Match(tlse, 0, 3, montpellier);
            Match match12 = new Match(psg, 1, 2, tlse);

            // ranking
            Ranking rk = new Ranking(ptLeague, clubs);
            rk.Register(match);
            rk.Register(match2);
            rk.Register(match3);
            rk.Register(match4);
            rk.Register(match5);
            rk.Register(match6);
            rk.Register(match7);
            rk.Register(match8);
            rk.Register(match9);
            rk.Register(match10);
            rk.Register(match11);
            rk.Register(match12);

            // test ranking clubs
            Assert.AreEqual(rk.GetPoints(marseille).CompareTo(rk.GetPoints(lyon)), -1);
            Assert.AreEqual(rk.GetPoints(lyon).CompareTo(rk.GetPoints(tlse)), -1);
            Assert.AreEqual(rk.GetPoints(tlse).CompareTo(rk.GetPoints(montpellier)), -1);
            Assert.AreEqual(rk.GetPoints(montpellier).CompareTo(rk.GetPoints(bdx)), -1);
            Assert.AreEqual(rk.GetPoints(bdx).CompareTo(rk.GetPoints(psg)), 0);
        }

    }
}
