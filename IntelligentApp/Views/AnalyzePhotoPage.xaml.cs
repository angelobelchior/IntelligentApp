using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace IntelligentApp.Views
{
    public partial class AnalyzePhoto : ContentPage
    {
        ViewModels.AnalyzePhotoViewModel _viewModel;
        public AnalyzePhoto(CognitiveServices.IService service, MediaFile mediaFile)
        {
            InitializeComponent();
            this._viewModel = new ViewModels.AnalyzePhotoViewModel(service, mediaFile);
            this.BindingContext = this._viewModel;
        }

        protected override void OnAppearing()
            => this._viewModel.OnInitialize();
        
    }
}