namespace IntelligentApp.ViewModels
{
    public class About : ViewModel
    {
        public string Version { get; set; }

        public About()
        {
            var version = global::Version.Plugin.CrossVersion.Current.Version;
            this.Version = $"Versão {version}";
        }
    }
}
