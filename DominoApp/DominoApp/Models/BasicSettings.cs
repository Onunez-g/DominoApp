using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DominoApp.Models
{
    public class BasicSettings
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int WinningScore { get; set; } = 200;
        public int WinningMode { get; set; } = 1;
    }
}
