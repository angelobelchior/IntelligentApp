using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Vision;
using System.Linq;
using System.IO;
using IntelligentApp.Models;
using Microsoft.ProjectOxford;

namespace IntelligentApp.CognitiveServices
{
    public class OCR : IVisionService
    {
        public async Task<VisionResult> Analyze(Stream stream)
        {
            var client = new VisionServiceClient(Constants.VisionApiKey, Constants.VisionApiEndpoint);

            var attributes = new List<VisionAttribute>();
            var rectangles = new List<Rectangle>();
            using (stream)
            {
                var ocrResult = await client.RecognizeTextAsync(stream);
                foreach (var region in ocrResult.Regions)
                {

                    rectangles.Add(region.Rectangle.ToRectangle());

                    var lines = region.Lines
                                      .Select(l => new
                                      {
                                          phrase = string.Join(" ", l.Words.Select(w => w.Text)),
                                          rectangle = l.Rectangle?.ToRectangle()
                                      });
                    foreach (var line in lines)
                    {
                        attributes.Add(new VisionAttribute(line.phrase));
                        rectangles.Add(line.rectangle);
                    }
                }
            }

            return new VisionResult { Attributes = attributes, Rectangles = rectangles };
        }
    }
}
