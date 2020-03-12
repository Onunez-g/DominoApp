using DominoApp.Data;
using DominoApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DominoApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public BasicSettings BasicSettings { get; set; }
        protected SettingsDatabaseController SettingsDatabase { get; set; }
        public BaseViewModel(SettingsDatabaseController settingsDatabase)
        {
            SettingsDatabase = settingsDatabase;
        }
        #pragma warning disable 67
        public event PropertyChangedEventHandler PropertyChanged;
        #pragma warning restore 67
    }
}
