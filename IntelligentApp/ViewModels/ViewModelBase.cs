using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace IntelligentApp.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private string _title;
        public string Title
        {
            get => _title;
            set => this.SetValue(value, ref _title);
        }

        private bool _isBusy;

        public bool IsBusy
        {
            get => _isBusy;
            set => this.SetValue(value, ref _isBusy);
        }

        protected INavigationService Navigation { get; private set; }
        protected IMessageService Message { get; private set; }

        public ViewModelBase(string title = "")
        {
            this.Navigation = DependencyService.Get<INavigationService>(DependencyFetchTarget.GlobalInstance);
            this.Message = DependencyService.Get<IMessageService>(DependencyFetchTarget.GlobalInstance);

            this.Title = title;
        }

        public virtual void OnInitialize()
        {

        }

        public virtual void OnFinalize()
        {

        }

        protected void SetValue<T>(T value, ref T field, [CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            field = value;
        }
    }
}
