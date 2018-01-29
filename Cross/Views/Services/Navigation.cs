using System.Threading.Tasks;
using IntelligentApp.ViewModels;
using Microsoft.AppCenter.Analytics;
using Xamarin.Forms;
using System.Linq;
using static IntelligentApp.ViewModels.ViewModel;

[assembly: Dependency(typeof(IntelligentApp.Views.Services.Navigation))]
namespace IntelligentApp.Views.Services
{
    public class Navigation : ViewModels.Services.INavigation
    {
        public async Task To<TViewModel>(Parameters parameters = null)
            where TViewModel : ViewModel
        {
            var page = Locator.GetView<TViewModel>(parameters);
            this.TrackEvent(page.Title, parameters);
            await App.Current.MainPage.Navigation.PushAsync(page);
        }

        public async Task ToModal<TViewModel>(Parameters parameters = null, bool navigateOnIOS = true) where TViewModel : ViewModel
        {
            var page = Locator.GetView<TViewModel>(parameters);

            this.TrackEvent(page.Title, parameters);

            if (navigateOnIOS)
                navigateOnIOS = (Device.RuntimePlatform == Device.iOS) || (Device.RuntimePlatform == Device.UWP);

            if (navigateOnIOS)
                await App.Current.MainPage.Navigation.PushAsync(page);
            else
                await App.Current.MainPage.Navigation.PushModalAsync(page);
        }

        public async Task GoBack(bool modal = true)
        {
            if (modal)
                await App.Current.MainPage.Navigation.PopModalAsync();
            else
                await App.Current.MainPage.Navigation.PopAsync();
        }

        private void TrackEvent(string page, Parameters parameters)
        {
            var properties = parameters?.ToDictionary(k => k.Key, v => v.Value?.ToString());
            properties.Add("Page", page);
            Analytics.TrackEvent(nameof(Navigation), properties);
        }
    }
}
