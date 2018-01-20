using Foundation;
using UIKit;

namespace IntelligentApp.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Xamarin.Forms.Forms.Init();
            Xamarin.Forms.DependencyService.Register<DrawingRectangle>();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
