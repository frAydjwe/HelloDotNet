using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class Club
    {
        private string name;

        public Club(string _name)
        {
            this.name = _name;
        }

        public override string ToString()
        {
            return this.name;
        }

    }
}
