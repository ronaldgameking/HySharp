using Newtonsoft.Json;

namespace HySharp.Player
{
    public class PlayerInfo
    {
        [JsonProperty("success")]
        public bool Success { get; private set; }
        [JsonProperty("cause")]
        public bool Cause { get; private set; }
        /// <summary>
        /// A player as an object
        /// </summary>
        [JsonProperty("player")]
        public HyPlayer Player { get; private set; }
        public string Displayname
        {
            get
            {
                return Player.Displayname;
            }
        }
    }
}
