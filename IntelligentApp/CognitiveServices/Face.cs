using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using IntelligentApp.Models;
using Microsoft.ProjectOxford;
using Microsoft.ProjectOxford.Face;

namespace IntelligentApp.CognitiveServices
{
    public class Face : IVisionService
    {
        public async Task<VisionResult> Analyze(Stream stream)
        {
            var client = new FaceServiceClient(Constants.FaceApiKey, Constants.FaceApiEndpoint);

            var visionAttributes = new List<VisionAttribute>();
            var visionRectangles = new List<Rectangle>();

            using (stream)
            {
                var attributes = new FaceAttributeType[] {
                    FaceAttributeType.Age,
                    FaceAttributeType.Gender,
                    FaceAttributeType.Glasses,
                    FaceAttributeType.Smile,
                };
                var faceResult = await client.DetectAsync(stream, returnFaceAttributes: attributes);
                if (faceResult != null && faceResult.Length > 0)
                {
                    for (int i = 0; i < faceResult.Length; i++)
                    {
                        //Evoluir para colocar o nome da pessoa caso ela já esteja cadastrada.

                        var face = faceResult[i];
                        visionAttributes.Add(new VisionAttribute($"Pessoa {i}", "Gênero", face.FaceAttributes.Gender));
                        visionAttributes.Add(new VisionAttribute($"Pessoa {i}", "Idade", face.FaceAttributes.Age.ToString()));
                        visionAttributes.Add(new VisionAttribute($"Pessoa {i}", "Sorrindo", face.FaceAttributes.Smile.ToString()));
                        visionAttributes.Add(new VisionAttribute($"Pessoa {i}", "Óculos", face.FaceAttributes.Glasses.ToString()));

                        visionRectangles.Add(face.FaceRectangle.ToRectangle());
                    }
                }
            }
            return new VisionResult { Attributes = visionAttributes, Rectangles = visionRectangles };
        }
    }
}
