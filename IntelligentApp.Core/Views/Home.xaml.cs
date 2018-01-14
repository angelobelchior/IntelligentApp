using Xamarin.Forms;

namespace IntelligentApp.Views
{
    public partial class Home : ContentPage
    {
        ViewModels.Home _viewModel = new ViewModels.Home();
        public Home()
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