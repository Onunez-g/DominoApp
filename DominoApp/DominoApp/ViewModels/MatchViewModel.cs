using DominoApp.Data;
using DominoApp.Models;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Collections.ObjectModel;
using System.Linq;

namespace DominoApp.ViewModels
{
    class MatchViewModel : BaseViewModel
    {
        public MatchRound MatchRound { get; set; } = new MatchRound();
        public int ThemTotalScore { get; set; } 
        public int WeTotalScore { get; set; } 
        public bool IsRefreshing { get; set; }
        public bool IsEmptyList { get; set; }
        public ObservableCollection<MatchRound> MatchRounds { get; set; } = new ObservableCollection<MatchRound>();
        public DelegateCommand AddMatchRoundCommand { get; set; }
        public DelegateCommand<MatchRound> DeleteMatchRoundCommand { get; set; }
        public DelegateCommand NewMatchCommand { get; set; }
        public DelegateCommand RefreshCommand { get; set; }
        public DelegateCommand GoToSettingsCommand { get; set; }
        readonly MatchDatabaseController _matchDatabase;
        public MatchViewModel(INavigationService navigationService, IPageDialogService pageDialog, MatchDatabaseController matchDatabase, SettingsDatabaseController settingsDatabase): base(settingsDatabase)
        {
            _matchDatabase = matchDatabase;
            GetSettings();
            GetMatchRounds();
            AddMatchRoundCommand = new DelegateCommand(async () =>
            {
                GetSettings();
                bool isNewGame = false;
                if(MatchRound.WeScore == 0 && MatchRound.ThemScore == 0)
                {
                    await pageDialog.DisplayAlertAsync("Error", "El resultado de la ronda no puede estar en blanco", "Cancelar");
                    return;
                }
                await matchDatabase.SaveMatchRound(MatchRound);
                if(WeTotalScore + MatchRound.WeScore >= BasicSettings.WinningScore || ThemTotalScore + MatchRound.ThemScore >= BasicSettings.WinningScore)
                {
                    string winnerTeam = WeTotalScore + MatchRound.WeScore > ThemTotalScore + MatchRound.ThemScore ? "Nosotros" : "Ellos";
                    isNewGame =  await pageDialog.DisplayAlertAsync("GANADOR", $"El equipo de {winnerTeam} ha ganado!", "Nueva partida", "Cerrar");
                }
                if (isNewGame)
                {
                    await matchDatabase.DeleteAllMatchRounds();
                }
                GetMatchRounds();
                MatchRound = new MatchRound();
            });
            DeleteMatchRoundCommand = new DelegateCommand<MatchRound>(async (round) =>
            {
                await matchDatabase.DeleteMatchRound(round.Id);
                GetMatchRounds();
            });
            NewMatchCommand = new DelegateCommand(async () =>
            {
                await matchDatabase.DeleteAllMatchRounds();
                GetMatchRounds();
            });
            RefreshCommand = new DelegateCommand(() => GetMatchRounds());
            GoToSettingsCommand = new DelegateCommand(async () => await navigationService.NavigateAsync(NavConstants.SettingsPage));
        }
        async void GetMatchRounds()
        {
            MatchRounds = new ObservableCollection<MatchRound>(await _matchDatabase.GetMatchRoundsAsync());
            WeTotalScore = MatchRounds.Sum(x => x.WeScore);
            ThemTotalScore = MatchRounds.Sum(x => x.ThemScore);
            IsRefreshing = false;
            IsEmptyList = MatchRounds.Count == 0;
        }
        async void GetSettings()
        {
            BasicSettings = await SettingsDatabase.GetBasicSettingsAsync();
        }
    }
}
