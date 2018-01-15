using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntelligentApp.ViewModels.Services
{
    public interface INavigation
    {
        Task GoBack(bool modal = false);

        Task To<TViewModel>(Parameters parameters = null, bool modal = false)
            where TViewModel : ViewModel;
    }
}