using DominoApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DominoApp.ViewModels
{
    public class SettingsViewModel
    {
        public BasicSettings BasicSettings { get; set; } 
        public ICommand SaveSettingsCommand { get; set; }
        public ICommand ReturnToGameCommand { get; set; }
        public SettingsViewModel()
        {
            GetSettings();
            SaveSettingsCommand = new Command(async () =>
            {
                if (BasicSettings.WinningScore <= 0)
                    BasicSettings.WinningScore = 200;
                await App.SettingsDatabase.SaveBasicSettingsAsync(BasicSettings);
                await App.Current.MainPage.Navigation.PopModalAsync();
            });
            ReturnToGameCommand = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PopModalAsync();
            });
        }
        async void GetSettings()
        {
            BasicSettings = await App.SettingsDatabase.GetBasicSettingsAsync();
        }
    }
}
