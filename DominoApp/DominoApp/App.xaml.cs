using DominoApp.Data;
using DominoApp.ViewModels;
using DominoApp.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;

namespace DominoApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }
        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync(NavConstants.MatchPage);
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MatchView, MatchViewModel>();
            containerRegistry.RegisterForNavigation<SettingsPage, SettingsViewModel>();
            containerRegistry.Register<MatchDatabaseController>();
            containerRegistry.Register<SettingsDatabaseController>();
        }
    }
}
