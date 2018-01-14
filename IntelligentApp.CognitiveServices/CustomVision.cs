using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

namespace IntelligentApp.CognitiveServices
{
    public class CustomVision : IService
    {
        public async Task<List<Result>> Analyze(Stream stream)
        {
            var response = await Rest.Analyze<Response>(stream, Constants.CustomVisionsApiEndpoint, Constants.CustomVisionsApiKey);
            if (response == null)
                return null;
            return response.Convert();
        }

        private class Response
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

        private class Prediction
        {
            public string TagId { get; set; }
            public string Tag { get; set; }
            public float Probability { get; set; }

            public Result Convert()
                => new Result(this.Tag, this.Probability.ToString());
        }
    }
}