using Newtonsoft.Json;
namespace HySharp.Player
{
    public class HyPlayer
    {
        [JsonProperty("uuid")]
        public string uuid { get; private set; }
        [JsonProperty("displayname")]
        public string Displayname { get; private set; }
        [JsonProperty("rank")]
        public RankEnum Rank { get; private set; }
        [JsonProperty("packageRank")]
        public PackageRankEnum PackageRank { get; private set; }
        [JsonProperty("newPackageRank")]
        public NewPackageRankEnum NewPackageRank { get; private set; }
        [JsonProperty("monthlyPackageRank")]
        public MonthlyPackageRankEnum MonthlyPackageRank { get; private set; }
        [JsonProperty("firstLogin")]
        public long FirstLogin { get; private set; }
        [JsonProperty("lastLogin")]
        public long LastLogin { get; private set; }
        [JsonProperty("lastLogout")]
        public long LastLogout { get; private set; }
        [JsonProperty("stats")]
        public object Stats { get; private set; }
    }
}
