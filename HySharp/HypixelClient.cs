using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

using HySharp.Key;
using HySharp.Player;

namespace HySharp
{
    public class HypixelClient
    {
        public PlayerDataResources Player;
        public SkyblockResources Skyblock = new SkyblockResources();
        public OtherResources Other;

        private HttpClient m_client = new HttpClient();
        private Uri m_baseEndpoint = new Uri("https://api.hypixel.net/");
        private string m_apiKey;

        public string ApiKey { get { return m_apiKey; } }

        /// <summary>
        /// Create a new instance of a hypixel client
        /// </summary>
        /// <param name="apiKey">The api key used for communicating with the api</param>
        public HypixelClient(string apiKey)
        {
            this.m_apiKey = apiKey;
            m_client.BaseAddress = m_baseEndpoint;
            Player = new PlayerDataResources(this);
            Other = new OtherResources(this);
        }

        /// <summary>
        /// Request information about the supplied API key
        /// </summary>
        /// <returns></returns>
        public async Task<ApiKeyInfo> ApiKeyInfoAsync()
        {
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, $"/key?key={m_apiKey}");
            HttpResponseMessage response = await m_client.SendAsync(message);
            CheckStatus(response);
            ApiKeyInfo keyInfo = JsonConvert.DeserializeObject<ApiKeyInfo>(await response.Content.ReadAsStringAsync());
            return keyInfo;
        }

        internal void CheckStatus(HttpResponseMessage _response)
        {
            if (_response.StatusCode == HttpStatusCode.Forbidden)
                throw new InvalidKeyException("Invalid API key");
            else if (_response.StatusCode == HttpStatusCode.TooManyRequests)
                throw new RequestLimitException();
        }

        public class PlayerDataResources
        {
            private HypixelClient m_hyclient;

            internal PlayerDataResources(HypixelClient hypixel)
            {
                m_hyclient = hypixel;
            }

            public async Task<PlayerInfo> GetPlayerData(string uuidPlayer)
            {
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, $"/player?key={m_hyclient.m_apiKey}&uuid={uuidPlayer}");
                HttpResponseMessage response = await m_hyclient.m_client.SendAsync(message);
                m_hyclient.CheckStatus(response);
                //string aaa = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(aaa);
                PlayerInfo playerInfo = JsonConvert.DeserializeObject<PlayerInfo>(await response.Content.ReadAsStringAsync());
                return playerInfo;
            }

        }
        public class SkyblockResources
        {

        }
        public class OtherResources
        {
            private HypixelClient m_hyclient;

            internal OtherResources(HypixelClient hypixel)
            {
                m_hyclient = hypixel;
            }

            /// <summary>
            /// Gets all active boosters on the network
            /// </summary>
            /// <returns>boosters AS STRING</returns>
            public async Task<string> GetActiveBoostersAsync()
            {
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, $"/boosters?key={m_hyclient.m_apiKey}");
                HttpResponseMessage response = await m_hyclient.m_client.SendAsync(message);
                m_hyclient.CheckStatus(response);
                return await response.Content.ReadAsStringAsync();
            }

            /// <summary>
            /// Gets the amount of online players
            /// </summary>
            /// <returns></returns>
            public async Task<string> GetPlayerCountAsync()
            {
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, $"/counts?key={m_hyclient.m_apiKey}");
                HttpResponseMessage response = await m_hyclient.m_client.SendAsync(message);
                m_hyclient.CheckStatus(response);
                return await response.Content.ReadAsStringAsync();
            }
        }
    }   
}
