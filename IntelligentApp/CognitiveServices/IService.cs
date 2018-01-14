using System.Collections.Generic;
using System.IO;
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

        public Result(string text, string detail)
            : this(text)
            => this.Detail = detail;

        public Result(string text, float score)
            : this(text)
            => this.Detail = score.ToString("0.##");

        public Result(string text, double score)
            : this(text)
            => this.Detail = score.ToString("0.##");
    }
}
