using Xamarin.Forms;

namespace IntelligentApp.Views
{
    public partial class About : ContentPage
    {
        public About()
        {
            InitializeComponent();

            Extentions.IPhoneX(this);

            this.webView.Navigated += Navigated;
        }

        private void Navigated(object sender, WebNavigatedEventArgs e)
        {
            if (e.Result == WebNavigationResult.Success)
            {
                activityIndicator.IsRunning = false;
                activityIndicator.IsVisible = false;
                webView.IsVisible = true;
            }
        }
    }
}