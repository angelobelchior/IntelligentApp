using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford;
using System.IO;
using IntelligentApp.Models;

namespace IntelligentApp.CognitiveServices
{
    public class Vision : IVisionService
    {
        public async Task<VisionResult> Analyze(Stream stream)
        {
            var client = new VisionServiceClient(Constants.VisionApiKey, Constants.VisionApiEndpoint);

            var attributes = new List<VisionAttribute>();
            var rectangles = new List<Rectangle>();
            using (stream)
            {
                var features = new VisualFeature[] { VisualFeature.Tags, VisualFeature.Faces };
                var visionsResult = await client.AnalyzeImageAsync(stream, features, null);
                if (visionsResult != null && visionsResult?.Tags.Length > 0)
                {
                    if (visionsResult.Faces != null)
                        foreach (var face in visionsResult.Faces)
                            rectangles.Add(face.FaceRectangle.ToRectangle());

                    foreach (var tag in visionsResult.Tags)
                        attributes.Add(new VisionAttribute(tag.Name, tag.Hint, tag.Confidence));
                }
            }
            return new VisionResult { Attributes = attributes, Rectangles = rectangles };
        }
    }
}
