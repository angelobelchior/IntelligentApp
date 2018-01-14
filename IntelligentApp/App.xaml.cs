using Xamarin.Forms;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;

namespace IntelligentApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            Locator.Register<ViewModels.Home, Views.Home>();
            Locator.Register<ViewModels.AnalyzePhoto, Views.AnalyzePhoto>();
            Locator.Register<ViewModels.Picture, Views.Picture>();
            var home = Locator.GetView<ViewModels.Home>();

            var navigationPage = new NavigationPage(home);
            navigationPage.BarBackgroundColor = Color.FromHex("#2196F3");
            navigationPage.BarTextColor = Color.White;

            MainPage = navigationPage;
        }

        protected override void OnStart()
        {
            AppCenter.Start("ios=7966ff68-0c94-423b-8aad-9326c89df212;" +
                            "android=96241571-bdbb-4836-b104-6efb9340869f",
                            typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
