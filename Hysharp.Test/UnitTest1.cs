using System;
using Xunit;
using HySharp.Key;
using HySharp.Player;

namespace HySharp.Test
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("a3633308-5ab0-43f4-9443-d80d022b908e")]
        public async void KeyObject(string apiKey)
        {
            HypixelClient client = new HypixelClient(apiKey);
            ApiKeyInfo key = await client.ApiKeyInfoAsync();
            Assert.Equal(apiKey, key.Record.Key);
            Assert.NotNull(key.Record.Owner);
        }

        [Theory]
        [InlineData("a3633308-5ab0-43f4-9443-d80d022b908e", "feafe0cd25fd4b78aaf1bda6a67d7d2b")]
        [InlineData("a3633308-5ab0-43f4-9443-d80d022b908e", "bf3672ca6eb640aea469ef6549128865")]
        public async void PlayerInfoMapping(string apiKey, string playerUuid)
        {
            HypixelClient client = new HypixelClient(apiKey);
            PlayerInfo playerInfo = await client.Player.GetPlayerData(playerUuid);
            Assert.Equal(playerUuid, playerInfo.Player.uuid);
            Assert.NotNull(playerInfo.Player.Displayname);
            Assert.NotEqual(0, playerInfo.Player.FirstLogin);
        }


    }
}
