using Xamarin.Forms;

namespace IntelligentApp.Views
{
    public partial class AnalyzePhoto : ContentPage
    {
        public AnalyzePhoto()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            if(this.BindingContext is ViewModels.ViewModel viewModel)
                viewModel.OnInitialize();
        }
    }
}