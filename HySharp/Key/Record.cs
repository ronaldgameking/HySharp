using Newtonsoft.Json;

namespace HySharp.Key
{
    public class Record
    {
        [JsonProperty("key")]
        public string Key { get; private set; }
        [JsonProperty("owner")]
        public string Owner { get; private set; }
        [JsonProperty("limit")]
        public int Limit { get; private set; }
        [JsonProperty("queriesInPastMin")]
        public int QueriesInPastMin { get; private set; }
        [JsonProperty("totalQueries")]
        public int TotalQueries { get; private set; }
    }
}
