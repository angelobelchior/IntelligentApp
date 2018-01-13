using System.Collections.Generic;
using System.Threading.Tasks;
using IntelligentApp.Models;
using Microsoft.ProjectOxford.Vision;
using Plugin.Media.Abstractions;
using System.Linq;

namespace IntelligentApp.CognitiveServices
{
    public class Vision : IService
    {
        public async Task<List<Result>> Analyze(MediaFile photo)
        {
            var client = new VisionServiceClient(Constants.VisionApiKey);

            var result = new List<Result>();
            using (var photoStream = photo.GetStream())
            {
                VisualFeature[] features = { VisualFeature.Tags };
                var visionsResult = await client.AnalyzeImageAsync(photoStream, features.ToList(), null);
                if (visionsResult != null && visionsResult?.Tags.Length > 0)
                    foreach (var tag in visionsResult.Tags)
                        result.Add(new Result(tag.Name, tag.Confidence.ToString()));
            }
            return result;
        }
    }
}
