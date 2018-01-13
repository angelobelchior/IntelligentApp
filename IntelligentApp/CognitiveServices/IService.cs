using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntelligentApp.CognitiveServices
{
    public interface IService
    {
        Task<List<Models.Result>> Analyze(Plugin.Media.Abstractions.MediaFile photo);
    }
}
