using IntelligentApp.CognitiveServices;
using IntelligentApp.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using IntelligentApp.Services;
using System.Collections.Generic;
using Microsoft.AppCenter.Analytics;

namespace IntelligentApp.ViewModels
{
    public class Photo : ViewModel
    {
        private bool _noItems = false;
        public bool NoItems
        {
            get => _noItems;
            set => this.SetValue(value, ref _noItems);
        }

        private bool _isVisible = true;
        public bool IsVisible
        {
            get => _isVisible;
            set => this.SetValue(value, ref _isVisible);
        }

        private string _image;
        public string Image
        {
            get => _image;
            set => this.SetValue(value, ref _image);
        }

        public ObservableCollection<GroupList<string, VisionAttribute>> Results { get; set; }

        public Command TakePhotoCommand { get; set; }
        public Command PickPhotoCommand { get; set; }
        public Command AboutServiceCommand { get; set; }

        private IVisionService _service;
        private Service _cognitiveService;

        [Preserve]
        public Photo(Parameters parameters)
        {
            this._cognitiveService = parameters["CognitiveService"] as Service;
            this._service = Activator.CreateInstance(this._cognitiveService.Type) as IVisionService;

            this.Title = this._cognitiveService.Name;

            this.TakePhotoCommand = new Command(async () => await this.TakePhoto());
            this.PickPhotoCommand = new Command(async () => await this.PickPhoto());
            this.AboutServiceCommand = new Command(async () => await this.AboutService());

            this.Results = new ObservableCollection<GroupList<string, VisionAttribute>>();
        }

        private async Task TakePhoto()
        {
            var result = await Execute(() => CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                Directory = this.Title.Replace(" ", string.Empty),
                Name = Guid.NewGuid().ToString(),
                CompressionQuality = 80
            }));
            this.TrackEvent(nameof(TakePhoto), result);
        }

        private async Task PickPhoto()
        {
            var result = await Execute(() => CrossMedia.Current.PickPhotoAsync());
            this.TrackEvent(nameof(PickPhoto), result);
        }

        private async Task AboutService()
        {
            var parameters = new Parameters("ServiceName", this.Title,
                                            "ServiceDescription", this._cognitiveService.Description,
                                            "ServiceInfo", this._cognitiveService.Info);

            await this.Navigation.ToModal<AboutService>(parameters);
        }

        private async Task<VisionResult> Execute(Func<Task<MediaFile>> func)
        {
            VisionResult result = null;

            try
            {
                var mediaFile = await func();
                if (mediaFile == null)
                    return null;

                this.IsBusy = true;

                this.Results.Clear();
                this.Image = string.Empty;

                this.IsVisible = false;

                result = await this._service.Analyze(mediaFile.GetStream());
                if (result != null)
                    this.Group(result);

                this.NoItems = this.Results.Count == 0;
                this.DrawRectangles(result, mediaFile);
            }
            catch (Exception ex)
            {
                this.TrackError(ex);
                await this.Message.DisplayAlert(this.Title, "Não foi possível obter a foto", "Ok");
            }
            finally
            {
                this.IsBusy = false;
            }

            return result;
        }

        private void Group(VisionResult result)
        {
            var items = from attribute in result.Attributes
                        orderby attribute.ElementeName
                        group attribute by attribute.ElementeName into groups
                        select new GroupList<string, VisionAttribute>(groups.Key, groups);
            items.ForEach(this.Results.Add);
        }

        private void DrawRectangles(VisionResult result, MediaFile mediaFile)
        {
            if (result.Rectangles?.Count == 0)
                return;

            var service = DependencyService.Get<IDrawingRectangle>(DependencyFetchTarget.GlobalInstance);
            service.Draw(mediaFile.Path, result.Rectangles);
            this.Image = mediaFile.Path;
        }

        private void TrackEvent(string source, VisionResult result)
        {
            try
            {
                var properties = new Dictionary<string, string>();
                properties.Add("Service", this.Title);
                properties.Add("Source", source);

                if (result != null)
                    foreach (var prop in result.ToProperties())
                        properties.Add(prop.Key, prop.Value);

                Analytics.TrackEvent(this.Title, properties);
            }
            catch (Exception ex)
            {
                this.TrackError(ex);
            }
        }

        private void TrackError(Exception ex)
            => Analytics.TrackEvent("Error", new Dictionary<string, string>
            {
                ["Exception"] = ex.Message
            });
    }
}