using System;
using System.Collections.Generic;

namespace IntelligentApp.Models
{
    public class CognitiveService
    {
        public string Name { get; set; }
        public string Detail { get; set; }
        public string Icon { get; set; }
        public Type Type { get; set; }

        public static IReadOnlyCollection<CognitiveService> ListAll()
        {
            var cognitiveServices = new List<CognitiveService>();
            cognitiveServices.Add(new CognitiveService
            {
                Name = "Face",
                Icon = "emotion.png",
                Detail = "Detect, identify, analyze, organize, and tag faces in photos",
                Type = typeof(CognitiveServices.Face)
            });
            cognitiveServices.Add(new CognitiveService
            {
                Name = "Emotion",
                Icon = "face.png",
                Detail = "Personalize user experiences with emotion recognition",
                Type = typeof(CognitiveServices.Emotion)
            });
            cognitiveServices.Add(new CognitiveService
            {
                Name = "Vision",
                Icon = "visions.png",
                Detail = "Distill actionable information from images",
                Type = typeof(CognitiveServices.Vision)
            });
            cognitiveServices.Add(new CognitiveService
            {
                Name = "OCR",
                Icon = "visions.png",
                Detail = "Read text in images",
                Type = typeof(CognitiveServices.OCR)
            });
            cognitiveServices.Add(new CognitiveService
            {
                Name = "Custom Visions",
                Icon = "visions.png",
                Detail = "Visual Intelligence Made Easy",
                Type = typeof(CognitiveServices.CustomVision)
            });

            return cognitiveServices;
        }
    }
}
