using IntelligentApp.Models;
using System.IO;
using System.Threading.Tasks;

namespace IntelligentApp.CognitiveServices
{
    public interface IVisionService
    {
        Task<VisionResult> Analyze(Stream stream);
    }
}
