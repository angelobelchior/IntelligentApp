using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using System.Linq;

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

        protected Dictionary<string, object> Parameters { get; }

        public ViewModel()
        {
            this.Navigation = DependencyService.Get<Services.INavigation>(DependencyFetchTarget.GlobalInstance);
            this.Message = DependencyService.Get<Services.IMessage>(DependencyFetchTarget.GlobalInstance);
            this.Parameters = new Dictionary<string, object>();
        }

        public virtual void OnInitialize() { }

        public virtual void OnFinalize() { }

        public void AddParameter(string name, object value)
            => this.Parameters.Add(name, value);

        public void AddParameter(Parameter parameter)
            => this.Parameters.Add(parameter.Name, parameter.Value);

        public void AddParameters(IList<Parameter> parameters)
        {
            foreach (var parameter in parameters)
                this.AddParameter(parameter);
        }

        protected void SetValue<T>(T value, ref T field, [CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            field = value;
        }

        public class Parameter
        {
            public string Name { get; }
            public object Value { get; }

            public Parameter(string name, object value)
            {
                this.Name = name;
                this.Value = value;
            }

            public static IList<Parameter> Create(Parameter parameter)
                => new List<Parameter> { parameter };

            public static IList<Parameter> Create(string name, object value)
                => Create(new Parameter(name, value));

            public static IList<Parameter> Create(Dictionary<string, object> parameters)
                => parameters.Select(p => new Parameter(p.Key, p.Value))
                             .ToList();

            public static IList<Parameter> Create(params Parameter[] parameters)
                => new List<Parameter>(parameters);
        }
    }
}
