using Plugin.Media.Abstractions;
using System.Collections.ObjectModel;

namespace IntelligentApp.ViewModels
{
    public class AnalyzePhotoViewModel : ViewModelBase
    {
        private readonly CognitiveServices.IService _service;
        private readonly MediaFile _mediaFile;

        private bool _hasItems = false;
        public bool HasItems
        {
            get => _hasItems;
            set => this.SetValue(value, ref _hasItems);
        }

        public ObservableCollection<Models.Result> Results { get; set; }

        public AnalyzePhotoViewModel(CognitiveServices.IService service, MediaFile mediaFile)
            : base("Análise da Imagem")
        {
            this._service = service;
            this._mediaFile = mediaFile;

            this.Results = new ObservableCollection<Models.Result>();
        }

        public override async void OnInitialize()
        {
            try
            {
                this.IsBusy = true;
                if (this._mediaFile != null)
                {
                    var results = await this._service.Analyze(this._mediaFile);
                    this.Results.Clear();
                    if(results != null)
                        foreach (var result in results)
                            this.Results.Add(result);

                    this.HasItems = this.Results.Count == 0;
                }
            }
            catch
            {
                await this.Message.DisplayAlert(this.Title, "Erro ao processar a imagem", "Ok");
            }
            finally
            {
                this.IsBusy = false;
            }
        }
    }
}
