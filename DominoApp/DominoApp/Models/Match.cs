using System;
using System.Collections.Generic;
using System.Text;

namespace DominoApp.Models
{
    public class Match
    {
        public Team TeamA { get; set; }
        public Team TeamB { get; set; }
        public int TeamAScore { get; set; }
        public int TeamBScore { get; set; }
        public IEnumerable<MatchRound> Rounds { get; set; }
    }
}
