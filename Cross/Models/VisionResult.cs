using System.Collections.Generic;

namespace IntelligentApp.Models
{
    public class VisionResult
    {
        public List<Rectangle> Rectangles { get; set; }
        public List<VisionAttribute> Attributes { get; set; }
    }
}
