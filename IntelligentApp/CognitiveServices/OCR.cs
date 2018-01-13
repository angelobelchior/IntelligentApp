using System.Collections.Generic;
using System.Threading.Tasks;
using IntelligentApp.Models;
using Microsoft.ProjectOxford.Vision;
using Plugin.Media.Abstractions;
using System.Linq;

namespace IntelligentApp.CognitiveServices
{
    public class OCR : IService
    {
        public async Task<List<Result>> Analyze(MediaFile photo)
        {
            var client = new VisionServiceClient(Constants.VisionApiKey);

            var result = new List<Result>();
            using (var photoStream = photo.GetStream())
            {
                var ocrResult = await client.RecognizeTextAsync(photoStream);
                foreach (var region in ocrResult.Regions)
                {
                    var lines = region.Lines.Select(l => string.Join(" ", l.Words.Select(w => w.Text)));
                    foreach (var line in lines)
                        result.Add(new Result(line));
                }
            }
            return result;
        }
    }
}
