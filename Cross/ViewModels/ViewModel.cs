using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace IntelligentApp.ViewModels
{
    public class ViewModel : INotifyPropertyChanged
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

        protected Services.INavigation Navigation { get; private set; }
        protected Services.IMessage Message { get; private set; }

        public ViewModel()
        {
            this.Navigation = DependencyService.Get<Services.INavigation>(DependencyFetchTarget.GlobalInstance);
            this.Message = DependencyService.Get<Services.IMessage>(DependencyFetchTarget.GlobalInstance);
        }

        public virtual void OnInitialize() { }

        public virtual void OnFinalize() { }

        protected void SetValue<T>(T value, ref T field, [CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            field = value;
        }

        public class Parameters : Dictionary<string, object>
        {
            private Parameters()
                : base(StringComparer.CurrentCultureIgnoreCase)
            {
            }

            public Parameters(string key, object value)
            {
                this.Add(key, value);
            }

            public Parameters(params object[] args)
            {
                if (args.Length < 2) throw new ArgumentException();
                if (args.Length % 2 != 0) throw new ArgumentException();
                for (int i = 0; i < args.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        if(args[i] is string key)
                        this.Add(args[i].ToString(), args[i + 1]);
                        i++;
                    }
                }
            }
        }
    }
}
