using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IntelligentApp.CognitiveServices
{
    public class Emotion : IService
    {
        public async Task<List<Result>> Analyze(Stream stream)
        {
            var response = await Rest.Analyze<Response>(stream, Constants.EmotionApiEndpoint, Constants.EmotionApiKey);
            if (response == null)
                return null;
            return response.Convert();
        }

        private class Response
        {
            public FaceScore[] FaceScore { get; set; }

            public List<Result> Convert()
            {
                var first = this.FaceScore.FirstOrDefault();
                if (first == null) return null;
                return first.Scores
                            .ToRankList()
                            .Select(r => new Result(r.Key, r.Value.ToString()))
                            .ToList();
            }
        }

        private class FaceScore
        {
            [JsonProperty("faceRectangle")]
            public FaceRectangle FaceRectangle { get; set; }
            [JsonProperty("scores")]
            public Scores Scores { get; set; }
        }

        private class FaceRectangle
        {
            [JsonProperty("height")]
            public int Height { get; set; }
            [JsonProperty("left")]
            public int Left { get; set; }
            [JsonProperty("top")]
            public int Top { get; set; }
            [JsonProperty("width")]
            public int Width { get; set; }
        }

        private class Scores
        {
            [JsonProperty("anger")]
            public float Anger { get; set; }
            [JsonProperty("contempt")]
            public float Contempt { get; set; }
            [JsonProperty("disgust")]
            public float Disgust { get; set; }
            [JsonProperty("fear")]
            public float Fear { get; set; }
            [JsonProperty("happiness")]
            public float Happiness { get; set; }
            [JsonProperty("neutral")]
            public float Neutral { get; set; }
            [JsonProperty("sadness")]
            public float Sadness { get; set; }
            [JsonProperty("surprise")]
            public float Surprise { get; set; }

            public Dictionary<string, float> ToRankList()
            {
                var rank = new Dictionary<string, float>
                {
                    ["Anger"] = this.Anger,
                    ["Contempt"] = this.Contempt,
                    ["Disgust"] = this.Disgust,
                    ["Fear"] = this.Fear,
                    ["Happiness"] = this.Happiness,
                    ["Neutral"] = this.Neutral,
                    ["Sadness"] = this.Sadness,
                    ["Surprise"] = this.Surprise,
                };

                var order = rank.OrderByDescending(r => r.Value)
                                .ToDictionary(k => k.Key, v => v.Value);
                return order;
            }
        }

    }
}
