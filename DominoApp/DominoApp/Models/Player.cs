using System;
using System.Collections.Generic;
using System.Text;

namespace DominoApp.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
        public IEnumerable<Team> Teams { get; set; }
    }
}
