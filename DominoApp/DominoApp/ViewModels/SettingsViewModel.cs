using DominoApp.Data;
using DominoApp.Models;
using Prism.Commands;
using Prism.Navigation;

namespace DominoApp.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    { 
        public DelegateCommand SaveSettingsCommand { get; set; }
        public DelegateCommand ReturnToGameCommand { get; set; }
        public SettingsViewModel(INavigationService navigationService, SettingsDatabaseController settingsDatabase) : base(settingsDatabase)
        {
            GetSettings();
            SaveSettingsCommand = new DelegateCommand(async () =>
            {
                if (BasicSettings.WinningScore <= 0)
                    BasicSettings.WinningScore = 200;
                await SettingsDatabase.SaveBasicSettingsAsync(BasicSettings);
                await navigationService.GoBackAsync();
            });
            ReturnToGameCommand = new DelegateCommand(async () =>
            {
                await navigationService.GoBackAsync();
            });
        }

        async void GetSettings()
        {
            BasicSettings = await SettingsDatabase.GetBasicSettingsAsync();
        }
    }
}
