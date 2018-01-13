using System.Collections.Generic;
using System.Threading.Tasks;
using IntelligentApp.Models;
using Microsoft.ProjectOxford.Face;
using Plugin.Media.Abstractions;
using FaceCollection = Microsoft.ProjectOxford.Face.Contract.Face;

namespace IntelligentApp.CognitiveServices
{
    public class Face : IService
    {
        public async Task<List<Result>> Analyze(MediaFile photo)
        {
            var client = new FaceServiceClient(Constants.FaceApiKey);

            var result = new List<Result>();
            using (var photoStream = photo.GetStream())
            {
                var attributes = new FaceAttributeType[] {
                    FaceAttributeType.Age,
                    FaceAttributeType.Gender,
                    FaceAttributeType.Glasses
                };
                var faceResult = await client.DetectAsync(photoStream, returnFaceAttributes: attributes);
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
