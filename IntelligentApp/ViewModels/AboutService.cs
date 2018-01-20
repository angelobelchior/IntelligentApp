using Xamarin.Forms.Internals;

namespace IntelligentApp.ViewModels
{
    public class AboutService : ViewModel
    {
        private string _description;
        public string Description
        {
            get => _description;
            set => this.SetValue(value, ref _description);
        }

        private string _info;
        public string Info
        {
            get => _info;
            set => this.SetValue(value, ref _info);
        }

        [Preserve]
        public AboutService(Parameters parameters)
        {
            this.Title = parameters["ServiceName"].ToString();
            this.Description = parameters["ServiceDescription"].ToString();
            this.Info = parameters["ServiceInfo"].ToString();
        }
    }
}
