using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ClassLibrary
{
    public sealed class FrenchLeague1PointSystem : PointSystem
    {
        private static FrenchLeague1PointSystem instance = null;
        private static readonly object padlock = new object();

        public override ITotal InitialPoints
        {
           get { return new PointTotal(); }
        }

        public static FrenchLeague1PointSystem Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new FrenchLeague1PointSystem();
                    }
                    return instance;
                }
            }
        }

        public override ITotal GetPointsFromMatch(Match m, bool isHome)
        {
            return new PointTotal(m, isHome);
        }

        private class PointTotal : ITotal
        {
            private int goalaverage;
            private int points;

            public int CompareTo(object obj)
            {

                /* Dans ce cas nous comparons les objets via les points et goalaverage
                 On pourrait aussi, dans un cas d'égalité parfaite, de comparer via le nombre de buts marqués. */

                if (this.points == ((PointTotal)obj).points)
                {
                    // test goalav
                    if (this.goalaverage == ((PointTotal)obj).goalaverage)
                    {
                        return 0;
                    }
                    else
                    {
                        if (this.goalaverage > ((PointTotal)obj).goalaverage)
                        {
                            return 1;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }
                else
                {
                    if (this.points > ((PointTotal)obj).points)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }

            public void Increment(PointSystem.ITotal with)
            {
                this.points += ((PointTotal)with).points;
                this.goalaverage += ((PointTotal)with).goalaverage;
            }
            public PointTotal()
            {
                this.points = 0;
                this.goalaverage = 0;
            }
            public PointTotal(Match m, bool isHome)
            {
                int result = m.GetGoals(isHome) - m.GetGoals(!isHome);
                this.goalaverage += result;
                if (result == 0)
                {
                    this.points += 1;
                }
                if (result > 0)
                {
                    this.points += 3;
                }
            }
            public override string ToString()
            {
                return ("Pts:" + this.points + "-Average:"+this.goalaverage);
            }
        }
    }
}
