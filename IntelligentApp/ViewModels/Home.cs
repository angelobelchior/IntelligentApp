using Plugin.Media;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace IntelligentApp.ViewModels
{
    public class Home : ViewModel
    {
        public ICommand CognitiveServiceSelectedCommand { get; set; }

        public IReadOnlyCollection<Models.CognitiveService> CognitiveServices { get; set; }

        public Home()
        {
            this.Title = "Intelligent App";

            this.CognitiveServices = Models.CognitiveService.ListAll();
            this.CognitiveServiceSelectedCommand = new Command(this.CognitiveServiceSelected);
        }

        public override async void OnInitialize()
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                await this.Message.DisplayAlert(this.Title, ":( No camera available.", "Ok");
        }

        private async void CognitiveServiceSelected(object parameter)
        {
            if (parameter is Models.CognitiveService cognitiveService)
                await this.Navigation.To<Picture>(Parameter.Create("CognitiveService", cognitiveService));
        }
    }
}
