using Xamarin.Forms;

namespace IntelligentApp.Views
{
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
            Extentions.LargeTitle(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (this.BindingContext is ViewModels.Home viewModel)
                this.cognitiveServicesList.ItemTapped += (sender, e) =>
                {
                    viewModel.CognitiveServiceSelectedCommand.Execute(e.Item);
                };
        }

        protected override void OnAppearing()
        {
            if (this.BindingContext is ViewModels.ViewModel viewModel)
                viewModel.OnInitialize();
        }
    }
}