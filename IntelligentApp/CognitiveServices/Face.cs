using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Face;
using FaceCollection = Microsoft.ProjectOxford.Face.Contract.Face;

namespace IntelligentApp.CognitiveServices
{
    public class Face : IService
    {
        public async Task<List<Result>> Analyze(Stream stream)
        {
            var client = new FaceServiceClient(Constants.FaceApiKey);

            var result = new List<Result>();
            using (stream)
            {
                var attributes = new FaceAttributeType[] {
                    FaceAttributeType.Age,
                    FaceAttributeType.Gender,
                    FaceAttributeType.Glasses
                };
                var faceResult = await client.DetectAsync(stream, returnFaceAttributes: attributes);
                if (faceResult != null && faceResult.Length > 0)
                {
                    foreach (FaceCollection face in faceResult)
                    {
                        result.Add(new Result("Gênero", face.FaceAttributes.Gender));
                        result.Add(new Result("Idade", face.FaceAttributes.Age.ToString()));
                        result.Add(new Result("Óculos", face.FaceAttributes.Glasses.ToString()));
                    }
                }
            }
            return result;
        }
    }
}
