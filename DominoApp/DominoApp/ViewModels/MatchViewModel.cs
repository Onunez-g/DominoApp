using DominoApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DominoApp.ViewModels
{
    class MatchViewModel : INotifyPropertyChanged
    {
        public MatchRound MatchRound { get; set; } = new MatchRound();
        public int ThemTotalScore { get; set; } 
        public int WeTotalScore { get; set; } 
        public ObservableCollection<MatchRound> MatchRounds { get; set; } = new ObservableCollection<MatchRound>();
        public ICommand AddMatchRoundCommand { get; set; }
        public ICommand DeleteMatchRoundCommand { get; set; }
        public MatchViewModel()
        {
            GetMatchRounds();
            AddMatchRoundCommand = new Command(async () =>
            {
                if(MatchRound.WeScore == 0 && MatchRound.ThemScore == 0)
                {
                    await App.Current.MainPage.DisplayAlert("Error", "El resultado de la ronda no puede estar en blanco", "Cancelar");
                    return;
                }
                await App.MatchDatabase.SaveMatchRound(MatchRound);
                MatchRounds.Add(MatchRound);
                WeTotalScore += MatchRound.WeScore;
                ThemTotalScore += MatchRound.ThemScore;
                MatchRound = new MatchRound();
            });
            DeleteMatchRoundCommand = new Command<MatchRound>(async (round) =>
            {
                await App.MatchDatabase.DeleteMatchRound(round.Id);
                GetMatchRounds();
            });
        }
        async void GetMatchRounds()
        {
            MatchRounds = new ObservableCollection<MatchRound>(await App.MatchDatabase.GetMatchRoundsAsync());
            WeTotalScore = MatchRounds.Sum(x => x.WeScore);
            ThemTotalScore = MatchRounds.Sum(x => x.ThemScore);
        }
        #pragma warning disable 67
        public event PropertyChangedEventHandler PropertyChanged;
        #pragma warning restore 67
    }
}
