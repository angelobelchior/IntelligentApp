using Xamarin.Forms;

namespace IntelligentApp.Views
{
    public partial class HomePage : ContentPage
    {
        ViewModels.HomeViewModel _viewModel = new ViewModels.HomeViewModel();
        public HomePage()
        {
            InitializeComponent();

            this.BindingContext = this._viewModel;
            this.cognitiveServicesList.ItemTapped += (sender, e) =>
            {
                this._viewModel.CognitiveServiceSelectedCommand.Execute(e.Item);
            };
        }

        protected override void OnAppearing() => this._viewModel.OnInitialize();
    }
}