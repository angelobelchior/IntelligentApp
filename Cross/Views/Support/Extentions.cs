namespace Xamarin.Forms
{
    public static class Extentions
    {
        public static void IPhone(Page page)
        {
            var ios = page.On<PlatformConfiguration.iOS>();

            //ios.SetLargeTitleDisplay(LargeTitleDisplayMode.Automatic);
            //ios.SafeAreaInsets();
        }
    }
}
