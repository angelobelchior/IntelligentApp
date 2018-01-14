using System.Threading.Tasks;
using IntelligentApp.ViewModels;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;

[assembly: Dependency(typeof(IntelligentApp.Views.Services.Navigation))]
namespace IntelligentApp.Views.Services
{
    public class Navigation : ViewModels.Services.INavigation
    {
        public async Task To<TViewModel>(Dictionary<string, object> parameters, bool modal = false)
            where TViewModel : ViewModel
            => await this.To<TViewModel>(parameters.Select(p => new ViewModel.Parameter(p.Key, p.Value)).ToList(), modal);

        public async Task To<TViewModel>(string parameterName = "parameter", object parameterValue = null, bool modal = false)
            where TViewModel : ViewModel
            => await this.To<TViewModel>(new ViewModel.Parameter(parameterName, parameterValue), modal);


        public async Task To<TViewModel>(ViewModel.Parameter parameter = null, bool modal = false)
            where TViewModel : ViewModel
            => await this.To<TViewModel>(new List<ViewModel.Parameter> { parameter }, modal);

        public async Task To<TViewModel>(IList<ViewModel.Parameter> parameters = null, bool modal = false)
            where TViewModel : ViewModel
        {
            var page = Locator.GetView<TViewModel>();
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
