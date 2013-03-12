using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public abstract class PointSystem
    {
        public abstract ITotal InitialPoints
        {
            get;
        }

        public abstract ITotal GetPointsFromMatch(Match mtch, bool isHome);

        public interface ITotal : IComparable
        {
           void Increment(ITotal with);

           string ToString();
   
        }
    }
}
