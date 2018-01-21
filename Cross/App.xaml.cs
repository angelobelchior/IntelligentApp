using Xamarin.Forms;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;

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
            AppCenter.Start("ios=9175f4cf-ec87-492a-bd8a-41b63f3d7a0f;" +
                            "android=f7a2e08e-02fa-479a-beb3-687cd5b0f03c",
                            typeof(Analytics),
                            typeof(Crashes));

            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
