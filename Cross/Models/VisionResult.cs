using System.Collections.Generic;

namespace IntelligentApp.Models
{
    public class VisionResult
    {
        public List<Rectangle> Rectangles { get; set; }
        public List<VisionAttribute> Attributes { get; set; }

        public IDictionary<string, string> ToProperties()
        {
            if (this.Attributes == null) return null;

            var properties = new Dictionary<string, string>();
            foreach (var attribute in this.Attributes)
            {
                if (!string.IsNullOrEmpty(attribute.Detail))
                    properties.Add(attribute.Text, attribute.Detail);
                else
                    properties.Add(attribute.ElementeName, attribute.Text);
            }

            return properties;
        }
    }
}
