using Plugin.Media;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace IntelligentApp.ViewModels
{
    public class Home : ViewModel
    {
        public Command CognitiveServiceSelectedCommand { get; set; }
        public Command AboutCommand { get; set; }

        public IReadOnlyCollection<Models.Service> CognitiveServices { get; set; }

        [Preserve]
        public Home()
        {
            this.Title = "Intelligent App";

            this.CognitiveServices = Models.Service.ListAll();
            this.CognitiveServiceSelectedCommand = new Command(this.CognitiveServiceSelected);
            this.AboutCommand = new Command(this.About);
        }

        public override async void OnInitialize()
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                await this.Message.DisplayAlert(this.Title, ":( No camera available.", "Ok");
        }

        private async void CognitiveServiceSelected(object parameter)
        {
            if (parameter is Models.Service cognitiveService)
                await this.Navigation.To<Photo>(new Parameters("CognitiveService", cognitiveService));
        }

        private async void About(object obj)
            => await this.Navigation.ToModal<About>();
    }
}
