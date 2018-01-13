using IntelligentApp.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(LargeTitle))]
namespace IntelligentApp.iOS.Renderers
{
    public class LargeTitle: NavigationRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (UIDevice.CurrentDevice.CheckSystemVersion(11, 0))
                NavigationBar.PrefersLargeTitles = true;
        }
    }
}