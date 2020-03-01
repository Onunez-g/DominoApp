using System;
using System.Collections.Generic;
using System.Text;

namespace DominoApp.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string TeanAlias { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
        public Player PlayerA { get; set; }
        public Player PlayerB { get; set; }
        public IEnumerable<Match> Matches { get; set; }
    }
}
