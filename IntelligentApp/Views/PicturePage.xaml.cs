using Xamarin.Forms;

namespace IntelligentApp.Views
{
    public partial class PicturePage : ContentPage
    {
        private readonly ViewModels.PictureViewModel _viewModel;

        public PicturePage(Models.CognitiveService cognitiveService)
        {
            InitializeComponent();

            this._viewModel = new ViewModels.PictureViewModel(cognitiveService);
            this.BindingContext = this._viewModel;
        }
    }
}