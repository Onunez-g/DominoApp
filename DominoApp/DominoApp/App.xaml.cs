using DominoApp.Data;
using DominoApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DominoApp
{
    public partial class App : Application
    {
        static MatchDatabaseController matchDatabase;
        public static MatchDatabaseController MatchDatabase
        {
            get
            {
                if (matchDatabase == null)
                    matchDatabase = new MatchDatabaseController();
                return matchDatabase;
            }
        }
        static SettingsDatabaseController settingsDatabase;
        public static SettingsDatabaseController SettingsDatabase
        {
            get
            {
                if (settingsDatabase == null)
                    settingsDatabase = new SettingsDatabaseController();
                return settingsDatabase;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new MatchView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
