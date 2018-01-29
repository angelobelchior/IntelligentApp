using Xamarin.Forms;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace IntelligentApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Locator.Register<ViewModels.Home, Views.Home>();
            Locator.Register<ViewModels.Photo, Views.Photo>();
            Locator.Register<ViewModels.About, Views.About>();
            Locator.Register<ViewModels.AboutService, Views.AboutService>();
            var home = Locator.GetView<ViewModels.Home>();

            var navigationPage = new NavigationPage(home);
            navigationPage.BarBackgroundColor = Color.FromHex("#2196F3");
            navigationPage.BarTextColor = Color.White;

            MainPage = navigationPage;
        }

        protected override void OnStart()
        {
            AppCenter.LogLevel = LogLevel.Verbose;
            AppCenter.Start("android=;" + 
                            "uwp=;" + 
                            "ios=", 
                            typeof(Analytics), 
                            typeof(Crashes));

            Crashes.NotifyUserConfirmation(UserConfirmation.AlwaysSend);
        }

        protected override void OnSleep() { }

        protected override void OnResume() { }
    }
}
