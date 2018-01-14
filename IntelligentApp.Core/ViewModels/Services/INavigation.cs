using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntelligentApp.ViewModels.Services
{
    public interface INavigation
    {
        Task GoBack(bool modal = false);

        Task To<TViewModel>(string parameterName = "parameter", object parameterValue = null, bool modal = false) where TViewModel : ViewModel;
        Task To<TViewModel>(ViewModel.Parameter parameter = null, bool modal = false) where TViewModel : ViewModel;
        Task To<TViewModel>(IList<ViewModel.Parameter> parameters = null, bool modal = false) where TViewModel : ViewModel;
        Task To<TViewModel>(Dictionary<string, object> parameters, bool modal = false) where TViewModel : ViewModel;
    }
}