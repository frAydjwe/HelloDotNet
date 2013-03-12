using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class Match
    {
        private Club home;
        private Club away;
        private int homeScore = 0;
        private int awayScore = 0;
        private bool homeForfeit = false;
        private bool awayForfeit = false;

        public Match(Club _home, int _homeScore, int _awayScore, Club _away)
        {
            this.home = _home;
            this.away = _away;
            this.homeScore = _homeScore;
            this.awayScore = _awayScore;
        }
        public Match(Club _home, Club _away, Club _forfait)
        {
            if ((_forfait != _home) && (_forfait != _away))
            {
                System.ArgumentException wrongArguments = new System.ArgumentException("Mauvais arguments");
                throw wrongArguments;
            }
            else
            {
                this.home = _home;
                this.away = _away;
                this.homeForfeit = (_forfait == _home);
                this.awayForfeit = (_forfait == _away);
            }
        }

        public Club Away 
        { 
            get { return this.away; }
        }
        public int AwayGoal
        {
            get { return this.awayScore; }
        }
        public Club Home
        {
            get {return this.home;}
        }
        public int HomeGoals
        {
            get { return this.homeScore; }
        }
        public int GetGoals(bool home)
        {
            int goals;
            if (home == true)
            {
                goals = this.HomeGoals;
            }
            else
            {
                goals = this.AwayGoal;
            }
            return goals;
        }
        public bool IsAwayForfeit
        {
            get { return this.awayForfeit ; }
        }
        public bool IsDraw
        {
            get { return this.homeScore == this.awayScore; }
        }
        public bool IsHomeForfeit
        {
            get { return this.homeForfeit; }
        }
    }
}
