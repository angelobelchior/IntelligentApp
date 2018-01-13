using System.Threading.Tasks;
using Xamarin.Forms;

namespace IntelligentApp
{
    public interface INavigationService
    {
        Task Back(bool animated = true);
        Task BackModal(bool animated = true);
        Task Push(Page page, bool animated = true);
        Task PushModal(Page page, bool animated = true);
    }
}