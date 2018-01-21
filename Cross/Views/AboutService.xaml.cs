using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace IntelligentApp.Views
{
    public partial class AboutService : ContentPage
	{
		public AboutService ()
		{
			InitializeComponent ();

            Extentions.IPhone(this);
        }
	}
}