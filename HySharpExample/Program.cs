using System;
using HySharp;
using HySharp.Key;
using HySharp.Player;

namespace HySharpExample
{
    class Program
    {
        private static HypixelClient hypixelClient;
        private static string yourApiKey = "a3633308-5ab0-43f4-9443-d80d022b908e";

        static void Main(string[] args)
        {
            hypixelClient = new HypixelClient(yourApiKey);
            DoStuff();
            Console.ReadKey();
        }

        static async void DoStuff()
        {
            ApiKeyInfo key = await hypixelClient.ApiKeyInfoAsync();
            Console.WriteLine(key.Record.Owner);
            //Takes long time
            //Console.WriteLine(await hypixelClient.Other.GetActiveBoostersAsync());
            //Console.WriteLine(await hypixelClient.Other.GetPlayerCountAsync());
            PlayerInfo playerInfo = await hypixelClient.Player.GetPlayerData("bf3672ca-6eb6-40ae-a469-ef6549128865");
            //PlayerInfo playerInfo = await hypixelClient.Player.GetPlayerData("0fca9377-7562-483a-bd4b-cbc98a3dc445");
            Console.WriteLine(playerInfo.Success);
            Console.WriteLine(playerInfo.Displayname);
            Console.WriteLine(playerInfo.Player.Rank);
            Console.WriteLine($"{playerInfo.Player.PackageRank} - {(int)playerInfo.Player.PackageRank}");
            Console.WriteLine($"{playerInfo.Player.NewPackageRank} - {(int)playerInfo.Player.NewPackageRank}");
            //Console.WriteLine(playerInfo);
        }
    }
}
