using System;
using System.Collections.Generic;
using System.Text;

namespace PecTec.Riot.LoL.Utility
{
    public static class DataDragonValues
    {
        public static string Versions => "https://ddragon.leagueoflegends.com/api/versions.json";
        public static string Regions => "https://ddragon.leagueoflegends.com/realms/na.json";
        public static string Languages => "https://ddragon.leagueoflegends.com/cdn/languages.json";
        public static string ChampionsGeneric => "http://ddragon.leagueoflegends.com/cdn/{patch}/data/en_US/champion.json";
        public static string ChampionSpecific(string patch, string championName) => $"http://ddragon.leagueoflegends.com/cdn/{patch}/data/en_US/champion/{championName}.json";
        public static string ChampionSplashArt(string championName, string skinId = "0") => $"http://ddragon.leagueoflegends.com/cdn/img/champion/splash/{championName}_{skinId}.jpg";
        public static string ChampionLoadingArt(string championName, string skinId = "0") => $"http://ddragon.leagueoflegends.com/cdn/img/champion/loading/{championName}_{skinId}.jpg";
        public static string ChampionSquareArt(string championName) => $"http://ddragon.leagueoflegends.com/cdn/11.7.1/img/champion/{championName}.png";
        public static string ChampionPassiveArt(string championName) => $"http://ddragon.leagueoflegends.com/cdn/img/champion/passive/{championName}_P.jpg";
        public static string SpellArt(string patch, string spellName) => $"http://ddragon.leagueoflegends.com/cdn/{patch}/img/spell/{spellName}.png";
        public static string Items => "http://ddragon.leagueoflegends.com/cdn/11.7.1/data/en_US/item.json";
        public static string ItemArt(string itemId) => $"http://ddragon.leagueoflegends.com/cdn/11.7.1/img/item/{itemId}.png";
        public static string SummonerSpells => "http://ddragon.leagueoflegends.com/cdn/11.7.1/data/en_US/summoner.json";
        public static string SummonerSpellArt(string summonerName) => $"http://ddragon.leagueoflegends.com/cdn/11.7.1/img/spell/Summoner{summonerName}.png";
        public static string ProfileIcons => "http://ddragon.leagueoflegends.com/cdn/11.7.1/data/en_US/profileicon.json";
        public static string ProfileIconsArt(string iconId) => $"http://ddragon.leagueoflegends.com/cdn/11.7.1/img/profileicon/{iconId}.png";
        public static string ScoreboardChampion => "http://ddragon.leagueoflegends.com/cdn/5.5.1/img/ui/champion.png";
        public static string ScoreboardItems => "http://ddragon.leagueoflegends.com/cdn/5.5.1/img/ui/items.png";
        public static string ScoreboardMinion => "http://ddragon.leagueoflegends.com/cdn/5.5.1/img/ui/minion.png";
        public static string ScoreboardScore => "http://ddragon.leagueoflegends.com/cdn/5.5.1/img/ui/score.png";
        public static string ScoreboardSpells => "http://ddragon.leagueoflegends.com/cdn/5.5.1/img/ui/spells.png";
    }
}
