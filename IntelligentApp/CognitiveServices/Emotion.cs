using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Emotion;
using EmotionCollection = Microsoft.ProjectOxford.Common.Contract.Emotion;

namespace IntelligentApp.CognitiveServices
{
    public class Emotion : IService
    {
        public async Task<List<Result>> Analyze(Stream stream)
        {
            var client = new EmotionServiceClient(Constants.EmotionApiKey);

            var result = new List<Result>();
            using (stream)
            {
                var emotionResult = await client.RecognizeAsync(stream);
                if (emotionResult != null && emotionResult.Length > 0)
                {
                    foreach (EmotionCollection emotion in emotionResult)
                    {
                        var score = emotion.Scores.ToRankedList().FirstOrDefault();
                        result.Add(new Result(score.Key, score.Value));
                    }
                }
            }
            return result;
        }
    }
}
