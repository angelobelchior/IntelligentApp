using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.IO;

namespace IntelligentApp.CognitiveServices
{
    public class OCR : IService
    {
        public async Task<List<Result>> Analyze(Stream stream)
        {
            return null;
            //var client = new VisionServiceClient(Constants.VisionApiKey);

            //var result = new List<Result>();
            //using (stream)
            //{
            //    var ocrResult = await client.RecognizeTextAsync(stream);
            //    foreach (var region in ocrResult.Regions)
            //    {
            //        var lines = region.Lines.Select(l => string.Join(" ", l.Words.Select(w => w.Text)));
            //        foreach (var line in lines)
            //            result.Add(new Result(line));
            //    }
            //}
            //return result;
        }
    }
}
