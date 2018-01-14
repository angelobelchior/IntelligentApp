using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IntelligentApp.CognitiveServices
{
    public class Face : IService
    {
        public async Task<List<Result>> Analyze(Stream stream)
        {
            var response = await Rest.Analyze<Response>(stream, Constants.FaceApiEndpoint, Constants.FaceApiKey);
            if (response == null)
                return null;
            return response.Convert();
        }

        public class Response
        {
            public FaceAttribute[] Faces { get; set; }

            public List<Result> Convert()
            {
                var first = this.Faces.FirstOrDefault();
                if (first == null) return null;

                return new List<Result>
                {
                    new Result("Gender", first.Attributes.Gender),
                    new Result("Age", first.Attributes.Age.ToString()),
                    new Result("Glasses", first.Attributes.Glasses),
                };
            }
        }

        public class FaceAttribute
        {
            [JsonProperty("faceId")]
            public string FaceId { get; set; }
            [JsonProperty("faceRectangle")]
            public FaceRectangle Face { get; set; }
            [JsonProperty("faceAttributes")]
            public Attributes Attributes { get; set; }
        }

        public class FaceRectangle
        {
            [JsonProperty("top")]
            public int Top { get; set; }
            [JsonProperty("left")]
            public int Left { get; set; }
            [JsonProperty("width")]
            public int Width { get; set; }
            [JsonProperty("height")]
            public int Height { get; set; }
        }

        public class Attributes
        {
            [JsonProperty("gender")]
            public string Gender { get; set; }
            [JsonProperty("age")]
            public float Age { get; set; }
            [JsonProperty("glasses")]
            public string Glasses { get; set; }
        }
    }
}
