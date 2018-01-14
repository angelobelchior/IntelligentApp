using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.IO;

namespace IntelligentApp.CognitiveServices
{
    public class Vision : IService
    {
        public async Task<List<Result>> Analyze(Stream stream)
        {
            return null;
            //var client = new VisionServiceClient(Constants.VisionApiKey);

            //var result = new List<Result>();
            //using (stream)
            //{
            //    VisualFeature[] features = { VisualFeature.Tags };
            //    var visionsResult = await client.AnalyzeImageAsync(stream, features.ToList(), null);
            //    if (visionsResult != null && visionsResult?.Tags.Length > 0)
            //        foreach (var tag in visionsResult.Tags)
            //            result.Add(new Result(tag.Name, tag.Confidence.ToString()));
            //}
            //return result;
        }
    }
}
