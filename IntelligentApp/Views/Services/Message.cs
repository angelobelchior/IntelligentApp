using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(IntelligentApp.Views.Services.Message))]
namespace IntelligentApp.Views.Services
{   
    public class Message : IMessageService
    {
        public async Task DisplayAlert(string title, string message, string cancel)
            => await App.Current.MainPage.DisplayAlert(title, message, cancel);

        public async Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
            => await App.Current.MainPage.DisplayAlert(title, message, accept, cancel);

        public async Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons)
            => await App.Current.MainPage.DisplayActionSheet(title, cancel, destruction, buttons);
    }
}
