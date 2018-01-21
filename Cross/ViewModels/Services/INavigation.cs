using System.Threading.Tasks;
using static IntelligentApp.ViewModels.ViewModel;

namespace IntelligentApp.ViewModels.Services
{
    public interface INavigation
    {
        Task GoBack(bool modal = false);

        Task To<TViewModel>(Parameters parameters = null)
            where TViewModel : ViewModel;

        Task ToModal<TViewModel>(Parameters parameters = null, bool navigateOnIOS = true)
            where TViewModel : ViewModel;
    }
}