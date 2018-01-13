namespace IntelligentApp.Models
{
    public class Result
    {
        public string Text { get; set; }
        public string Detail { get; set; }

        public Result()
        {

        }

        public Result(string text)
        {
            this.Text = text;
        }

        public Result(string text, string detail) : this(text)
        {
            this.Detail = detail;
        }
    }
}
