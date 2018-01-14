using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace IntelligentApp.CognitiveServices
{
    public interface IService
    {
        Task<List<Result>> Analyze(Stream stream);
    }

    public class Result
    {
        public string Text { get; set; }
        public string Detail { get; set; }

        public Result() { }

        public Result(string text)
            => this.Text = text;

        public Result(string text, string detail) : this(text)
            => this.Detail = detail;
    }

    public static class Rest
    {
        public static async Task<TResponse> Analyze<TResponse>(Stream stream, string url, string key)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/octet-stream");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Prediction-Key", key);

                var content = new MultipartFormDataContent();
                content.Add(new StreamContent(stream), "arquivo", "arquivo.jpg");

                var response = await client.PostAsync(url, content);
                if (!response.IsSuccessStatusCode)
                    return default(TResponse);

                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(json);
            }
        }
    }
}
