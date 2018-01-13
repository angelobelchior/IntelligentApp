using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(IntelligentApp.Views.Services.Navigation))]
namespace IntelligentApp.Views.Services
{
    public class Navigation : INavigationService
    {
        public async Task Push(Page page, bool animated = true)
            => await App.Current.MainPage.Navigation.PushAsync(page, animated);

        public async Task PushModal(Page page, bool animated = true)
            => await App.Current.MainPage.Navigation.PushModalAsync(page, animated);

        public async Task Back(bool animated = true)
            => await App.Current.MainPage.Navigation.PopAsync(animated);

        public async Task BackModal(bool animated = true)
            => await App.Current.MainPage.Navigation.PopModalAsync(animated);
    }
}
