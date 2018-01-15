using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Xamarin.Forms
{
    public static class Extentions
    {
        public static void LargeTitle(Page page)
        {
            page.On<PlatformConfiguration.iOS>()
                .SetLargeTitleDisplay(LargeTitleDisplayMode.Always);
        }
    }
}
