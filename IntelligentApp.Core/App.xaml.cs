using Xamarin.Forms;
using IntelligentApp.ViewModels;
using IntelligentApp.ViewModels.Services;

namespace IntelligentApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Locator.Register<Home, Views.Home>();
            Locator.Register<Picture, Views.Picture>();
            Locator.Register<AnalyzePhoto, Views.AnalyzePhoto>();

            var page = Locator.GetView<Home>();

            var navigationPage = new NavigationPage(page);
            navigationPage.BarBackgroundColor = Color.FromHex("#2196F3");
            navigationPage.BarTextColor = Color.White;

            MainPage = navigationPage;
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
