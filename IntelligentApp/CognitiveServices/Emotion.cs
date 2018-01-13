using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntelligentApp.Models;
using Microsoft.ProjectOxford.Emotion;
using Plugin.Media.Abstractions;
using EmotionCollection = Microsoft.ProjectOxford.Common.Contract.Emotion;

namespace IntelligentApp.CognitiveServices
{
    public class Emotion : IService
    {
        public async Task<List<Result>> Analyze(MediaFile photo)
        {
            var client = new EmotionServiceClient(Constants.EmotionApiKey);

            var result = new List<Result>();
            using (var photoStream = photo.GetStream())
            {
                var emotionResult = await client.RecognizeAsync(photoStream);
                if (emotionResult != null && emotionResult.Length > 0)
                {
                    foreach (EmotionCollection emotion in emotionResult)
                    {
                        var score = emotion.Scores.ToRankedList().FirstOrDefault();
                        result.Add(new Result(score.Key, score.Value.ToString()));
                    }
                }
            }
            return result;
        }
    }
}
