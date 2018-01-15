using Xamarin.Forms;

namespace IntelligentApp.Views
{
    public partial class Analyze : ContentPage
    {
        public Analyze()
        {
            InitializeComponent();

            Extentions.LargeTitle(this);
        }

        protected override void OnAppearing()
        {
            if (this.BindingContext is ViewModels.ViewModel viewModel)
                viewModel.OnInitialize();
        }
    }
}