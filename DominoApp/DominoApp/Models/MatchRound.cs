using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DominoApp.Models
{
    public class MatchRound : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int WeScore { get; set; }
        public int ThemScore { get; set; }
        #pragma warning disable 67
        public event PropertyChangedEventHandler PropertyChanged;
        #pragma warning restore 67
    }
}
