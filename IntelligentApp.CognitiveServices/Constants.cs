namespace IntelligentApp.CognitiveServices
{
    public class Constants
    {
        public const string EmotionApiKey = "9b1ef9f13b4842918bd384b1024fa33e";
        public const string EmotionApiEndpoint = "https://westus.api.cognitive.microsoft.com/emotion/v1.0/recognize";


        public const string FaceApiKey = "1f4d75f4d90642049290b930c3a5b423";
        public const string FaceApiEndpoint = "https://westus.api.cognitive.microsoft.com/face/v1.0/detect?returnFaceId=true&returnFaceLandmarks=false&returnFaceAttributes=age,gender,glasses";


        public const string VisionApiKey = "f01fc766f94a4dc09139fd3e7aa9a795";

        public const string CustomVisionsApiKey = "ffd05bc4de1a46e38e0f080eed8f8dd3";
        public const string CustomVisionsApiEndpoint = "https://southcentralus.api.cognitive.microsoft.com/customvision/v1.1/Prediction/cfa11979-236e-4b63-b866-b581daec8d18/image";
    }
}
