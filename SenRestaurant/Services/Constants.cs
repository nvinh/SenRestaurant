namespace Todo
{
    public static class Constants
    {
        public static readonly string AuthenticationTokenEndpoint = "https://api.cognitive.microsoft.com/sts/v1.0";

        public static readonly string BingSpeechApiKey = "<INSERT_API_KEY_HERE>";
        public static readonly string SpeechRecognitionEndpoint = "https://speech.platform.bing.com/recognize";
        public static readonly string AudioContentType = @"audio/wav; codec=""audio/pcm""; samplerate=16000";

        public static readonly string BingSpellCheckApiKey = "<You need an API key for testing>";
        public static readonly string BingSpellCheckEndpoint = "https://api.cognitive.microsoft.com/bing/v5.0/spellcheck/";

        public static readonly string TextTranslatorApiKey = "<You need an API key for testing>";
        public static readonly string TextTranslatorEndpoint = "https://api.microsofttranslator.com/v2/http.svc/Translate";

        public static readonly string TextAnalyticApiKey = "<You need an API key for testing>";
        public static readonly string TextAnalyticEndpoint = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/sentiment";

        public static readonly string EmotionApiKey = "<You need an API key for testing>";

        public static readonly string TestQueryApiKey = "<You need an API key for testing>";
        public static readonly string TestQueryEndpoint = "http://fitmein.azurewebsites.net/phos.asp";

        public static readonly string AudioFilename = "Todo.wav";
    }
}
