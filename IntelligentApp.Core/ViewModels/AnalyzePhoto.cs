using IntelligentApp.CognitiveServices;
using Plugin.Media.Abstractions;
using System.Collections.ObjectModel;

namespace IntelligentApp.ViewModels
{
    public class AnalyzePhoto : ViewModel
    {
        private bool _hasItems = false;
        public bool HasItems
        {
            get => _hasItems;
            set => this.SetValue(value, ref _hasItems);
        }

        public ObservableCollection<Result> Results { get; set; }

        public AnalyzePhoto()
        {
            this.Results = new ObservableCollection<Result>();
        }

        public override async void OnInitialize()
        {
            try
            {
                var service = this.Parameters["CognitiveServices"] as IService;
                var mediaFile = this.Parameters["MediaFile"] as MediaFile;

                this.IsBusy = true;
                if (mediaFile != null)
                {
                    var results = await service.Analyze(mediaFile.GetStream());
                    this.Results.Clear();
                    if (results != null)
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
