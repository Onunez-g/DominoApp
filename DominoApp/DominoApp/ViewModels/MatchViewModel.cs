using DominoApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DominoApp.ViewModels
{
    class MatchViewModel : INotifyPropertyChanged
    {
        public MatchRound MatchRound { get; set; }
        public ObservableCollection<MatchRound> MatchRounds { get; set; }
        public ICommand AddMatchRoundCommand { get; set; }
        public ICommand DeleteMatchRoundCommand { get; set; }
        public MatchViewModel()
        {
            AddMatchRoundCommand = new Command(async () =>
            {
                if(MatchRound.WeScore == 0 && MatchRound.ThemScore == 0)
                {
                    await App.Current.MainPage.DisplayAlert("Error", "El resultado de la ronda no puede estar en blanco", "Cancelar");
                }
                await App.MatchDatabase.SaveMatchRound(MatchRound);
                MatchRound = new MatchRound();
            });
            DeleteMatchRoundCommand = new Command(async () =>
            {
                await App.MatchDatabase.DeleteMatchRound(MatchRound.Id);
            });
        }
        #pragma warning disable 67
        public event PropertyChangedEventHandler PropertyChanged;
        #pragma warning restore 67
    }
}
