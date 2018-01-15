using System.Threading.Tasks;
using IntelligentApp.ViewModels;
using Xamarin.Forms;
using System.Collections.Generic;

[assembly: Dependency(typeof(IntelligentApp.Views.Services.Navigation))]
namespace IntelligentApp.Views.Services
{
    public class Navigation : ViewModels.Services.INavigation
    {
        public async Task To<TViewModel>(Parameters parameters = null, bool modal = false)
            where TViewModel : ViewModel
        {
            var page = Locator.GetView<TViewModel>(parameters);
            if (modal)
                await App.Current.MainPage.Navigation.PushModalAsync(page);
            else
                await App.Current.MainPage.Navigation.PushAsync(page);
        }

        public async Task GoBack(bool modal = true)
        {
            if (modal)
                await App.Current.MainPage.Navigation.PopModalAsync();
            else
                await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
