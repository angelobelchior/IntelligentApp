using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using IntelligentApp.Models;
using Microsoft.ProjectOxford;
using Microsoft.ProjectOxford.Emotion;

namespace IntelligentApp.CognitiveServices
{
    public class Emotion : IVisionService
    {
        public async Task<VisionResult> Analyze(Stream stream)
        {
            var client = new EmotionServiceClient(Constants.EmotionApiKey, Constants.EmotionApiEndpoint);

            var attributes = new List<VisionAttribute>();
            var rectangles = new List<Rectangle>();
            using (stream)
            {
                var emotionResult = await client.RecognizeAsync(stream);
                if (emotionResult != null && emotionResult.Length > 0)
                {
                    for (int i = 0; i < emotionResult.Length; i++)
                    {
                        var emotion = emotionResult[i];
                        rectangles.Add(emotion.FaceRectangle.ToRectangle());
                        foreach (var score in emotion.Scores.ToRankedList())
                        {
                            attributes.Add(new VisionAttribute($"Pessoa {i}", score.Key, score.Value));
                        }
                    }
                }
            }
            return new VisionResult { Attributes = attributes, Rectangles = rectangles };
        }
    }
}
