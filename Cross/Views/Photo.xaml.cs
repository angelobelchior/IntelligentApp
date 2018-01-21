using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace IntelligentApp.Views
{
    public partial class Photo : ContentPage
    {
        public Photo()
        {
            InitializeComponent();
            Extentions.IPhone(this);
        }

        protected override void OnAppearing()
        {
            if (this.BindingContext is ViewModels.ViewModel viewModel)
                viewModel.OnInitialize();
        }
    }
}