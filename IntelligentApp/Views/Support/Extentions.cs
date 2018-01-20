using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Xamarin.Forms
{
    public static class Extentions
    {
        public static void IPhoneX(Page page)
        {
            var ios = page.On<PlatformConfiguration.iOS>();

            //ios.SetLargeTitleDisplay(LargeTitleDisplayMode.Automatic);
            //ios.SafeAreaInsets();
        }
    }
}
