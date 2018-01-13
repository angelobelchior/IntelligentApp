using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using IntelligentApp.Models;
using Newtonsoft.Json;
using Plugin.Media.Abstractions;

namespace IntelligentApp.CognitiveServices
{
    public class CustomVision : IService
    {
        public async Task<List<Result>> Analyze(MediaFile photo)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/octet-stream");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Prediction-Key", Constants.CustomVisionsApiKey);

                var content = new MultipartFormDataContent();
                content.Add(new StreamContent(photo.GetStream()), "arquivo", "arquivo.jpg");

                var response = await client.PostAsync(Constants.CustomVisionsApiEndpoint, content);
                if (!response.IsSuccessStatusCode)
                    return null;

                var json = await response.Content.ReadAsStringAsync();
                var customVisionResponse = JsonConvert.DeserializeObject<Response>(json);
                if (customVisionResponse == null)
                    return null;

                return customVisionResponse.Convert();
            }
        }

        public class Response
        {
            public string Id { get; set; }
            public string Project { get; set; }
            public string Iteration { get; set; }
            public DateTime Created { get; set; }
            public Prediction[] Predictions { get; set; }

            public List<Result> Convert() => this.Predictions
                                                 ?.OrderByDescending(p => p.Probability)
                                                 ?.Select(p => p.Convert())
                                                 ?.ToList();
        }

        public class Prediction
        {
            public string TagId { get; set; }
            public string Tag { get; set; }
            public float Probability { get; set; }

            public Result Convert()
                => new Result(this.Tag, this.Probability.ToString());
        }
    }
}