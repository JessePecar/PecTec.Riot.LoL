using System;
using System.Collections.Generic;
using System.Text;

namespace PecTec.Riot.LoL.Utility
{
    public static class RiotRequests
    {
        public static string MatchHistory(string accountId, string takeNum, string skipNum) => $"/lol/match/v4/matchlists/by-account/{accountId}?endIndex={takeNum}&beginIndex={skipNum}";
        public static string SummonerInformation(string summonerName) => $"/lol/summoner/v4/summoners/by-name/{summonerName}";
        public static string MatchDetails(string matchId) => $"/lol/match/v4/matches/{matchId}";
    }
}
