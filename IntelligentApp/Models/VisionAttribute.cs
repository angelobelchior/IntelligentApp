namespace IntelligentApp.Models
{
    public class VisionAttribute
    {
        public string ElementeName { get; set; }
        public string Text { get; set; }
        public string Detail { get; set; }

        public VisionAttribute() { }

        public VisionAttribute(string text) 
            : this(string.Empty, text)
        {
        }

        public VisionAttribute(string elementName, string text)
        {
            this.ElementeName = elementName;
            this.Text = text;
        }


        public VisionAttribute(string elementName, string text, string detail)
            : this(elementName, text)
            => this.Detail = detail;

        public VisionAttribute(string elementName, string text, float score)
            : this(elementName, text)
            => this.Detail = score.ToString("0.##");

        public VisionAttribute(string elementName, string text, double score)
            : this(elementName, text)
            => this.Detail = score.ToString("0.##");
    }
}
