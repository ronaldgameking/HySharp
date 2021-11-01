using Newtonsoft.Json;

namespace HySharp.Key
{
    public class ApiKeyInfo
    {
        [JsonProperty("success")]        
        public bool WasSuccessful { get; private set; }
        [JsonProperty("cause")]        
        public string Cause { get; private set; }
        [JsonProperty("record")]        
        public Record Record { get; private set; }
    }
}
