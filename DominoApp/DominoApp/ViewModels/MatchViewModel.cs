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
        public const int WinnerScore = 200; 
        public MatchRound MatchRound { get; set; } = new MatchRound();
        public int ThemTotalScore { get; set; } 
        public int WeTotalScore { get; set; } 
        public bool IsRefreshing { get; set; }
        public ObservableCollection<MatchRound> MatchRounds { get; set; } = new ObservableCollection<MatchRound>();
        public ICommand AddMatchRoundCommand { get; set; }
        public ICommand DeleteMatchRoundCommand { get; set; }
        public ICommand NewMatchCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        public MatchViewModel()
        {
            GetMatchRounds();
            AddMatchRoundCommand = new Command(async () =>
            {
                bool isNewGame = false;
                if(MatchRound.WeScore == 0 && MatchRound.ThemScore == 0)
                {
                    await App.Current.MainPage.DisplayAlert("Error", "El resultado de la ronda no puede estar en blanco", "Cancelar");
                    return;
                }
                await App.MatchDatabase.SaveMatchRound(MatchRound);
                if(WeTotalScore + MatchRound.WeScore >= WinnerScore || ThemTotalScore + MatchRound.ThemScore >= WinnerScore)
                {
                    string winnerTeam = WeTotalScore + MatchRound.WeScore > ThemTotalScore + MatchRound.ThemScore ? "Nosotros" : "Ellos";
                    isNewGame =  await App.Current.MainPage.DisplayAlert("GANADOR", $"El equipo de {winnerTeam} ha ganado!", "Nueva partida", "Cerrar");
                }
                if (isNewGame)
                {
                    await App.MatchDatabase.DeleteAllMatchRounds();
                }
                GetMatchRounds();
                MatchRound = new MatchRound();
            });
            DeleteMatchRoundCommand = new Command<MatchRound>(async (round) =>
            {
                await App.MatchDatabase.DeleteMatchRound(round.Id);
                GetMatchRounds();
            });
            NewMatchCommand = new Command(async () =>
            {
                await App.MatchDatabase.DeleteAllMatchRounds();
                GetMatchRounds();
            });
            RefreshCommand = new Command(() => GetMatchRounds());
        }
        async void GetMatchRounds()
        {
            MatchRounds = new ObservableCollection<MatchRound>(await App.MatchDatabase.GetMatchRoundsAsync());
            WeTotalScore = MatchRounds.Sum(x => x.WeScore);
            ThemTotalScore = MatchRounds.Sum(x => x.ThemScore);
            IsRefreshing = false;
        }
        #pragma warning disable 67
        public event PropertyChangedEventHandler PropertyChanged;
        #pragma warning restore 67
    }
}
