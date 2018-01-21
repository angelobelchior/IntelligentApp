using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using IntelligentApp.Models;

namespace IntelligentApp.CognitiveServices
{
    public class CustomVision : IVisionService
    {
        public async Task<VisionResult> Analyze(Stream stream)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/octet-stream");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Prediction-Key", Constants.CustomVisionsApiKey);

                var content = new MultipartFormDataContent();
                content.Add(new StreamContent(stream), "arquivo", "arquivo.jpg");

                var response = await client.PostAsync(Constants.CustomVisionsApiEndpoint, content);
                if (!response.IsSuccessStatusCode)
                    return null;

                var json = await response.Content.ReadAsStringAsync();
                var customVisionResponse = JsonConvert.DeserializeObject<Response>(json);
                if (customVisionResponse == null)
                    return null;

                //return customVisionResponse.Convert();
                return null;
            }
        }

        public class Response
        {
            public string Id { get; set; }
            public string Project { get; set; }
            public string Iteration { get; set; }
            public DateTime Created { get; set; }
            public Prediction[] Predictions { get; set; }

            //public List<VisionResult> Convert() => this.Predictions
            //                                     ?.OrderByDescending(p => p.Probability)
            //                                     ?.Select(p => p.Convert())
            //                                     ?.ToList();
        }

        public class Prediction
        {
            public string TagId { get; set; }
            public string Tag { get; set; }
            public float Probability { get; set; }

            //public VisionResult Convert()
            //    => new VisionResult(this.Tag, this.Probability);
        }
    }
}