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
                Name = "Face API",
                Icon = "face.png",
                Detail = "Detecte, Identifique, Analise, Organize e Marque rostos em fotos",
                Type = typeof(CognitiveServices.Face)
            });
            cognitiveServices.Add(new CognitiveService
            {
                Name = "Emotion API",
                Icon = "emotion.png",
                Detail = "Personalize a experiência do usuário com o reconhecimento de Emoções",
                Type = typeof(CognitiveServices.Emotion)
            });
            cognitiveServices.Add(new CognitiveService
            {
                Name = "Computer Vision API",
                Icon = "visions.png",
                Detail = "Extraia informações de imagens",
                Type = typeof(CognitiveServices.Vision)
            });
            cognitiveServices.Add(new CognitiveService
            {
                Name = "OCR",
                Icon = "visions.png",
                Detail = "Extraia textos de imagens",
                Type = typeof(CognitiveServices.OCR)
            });
            cognitiveServices.Add(new CognitiveService
            {
                Name = "Custom Vision",
                Icon = "visions.png",
                Detail = "Inteligência Visual de uma forma fácil",
                Type = typeof(CognitiveServices.CustomVision)
            });

            return cognitiveServices;
        }
    }
}
