using PecTec.Riot.Core.Interfaces;
using PecTec.Riot.LoL.Interfaces;
using PecTec.Riot.LoL.Models;
using PecTec.Riot.LoL.Models.Account;
using PecTec.Riot.LoL.Models.Account.MatchHistory;
using PecTec.Riot.LoL.Models.Account.MatchHistory.Timeline;
using System.Collections.Generic;

namespace PecTec.Riot.LoL
{
    public class LiveDataRetrieve : ILiveDataRetrieve
    {
        private readonly IPecTecClient _client;
        public LiveDataRetrieve(IPecTecClient client)
        {
            _client = client;
        }

        #region Summoner

        public Summoner RetrieveSummonerByAccountId(Regions region, string accountId)
        {
            string requestUrl = GetRequestUrl(region.PlatformRoutingValue, $"/lol/summoner/v4/summoners/by-account/{accountId}");
            return _client.GetRequestForItem<Summoner>(requestUrl);
        }

        public Summoner RetrieveSummonerByName(Regions region, string summonerName)
        {
            string requestUrl = GetRequestUrl(region.PlatformRoutingValue, $"/lol/summoner/v4/summoners/by-name/{summonerName}");
            return _client.GetRequestForItem<Summoner>(requestUrl);
        }

        public Summoner RetrieveSummonerByPUUID(Regions region, string puuid)
        {
            string requestUrl = GetRequestUrl(region.PlatformRoutingValue, $"/lol/summoner/v4/summoners/by-puuid/{puuid}");
            return _client.GetRequestForItem<Summoner>(requestUrl);
        }

        public Summoner RetrieveSummonerBySummonerId(Regions region, string summonerId)
        {
            string requestUrl = GetRequestUrl(region.PlatformRoutingValue, $"/lol/summoner/v4/summoners/{summonerId}");
            return _client.GetRequestForItem<Summoner>(requestUrl);
        }

        #endregion

        #region Match History

        public BasicMatchHistoryMetaData GetBasicMatchHistoryByAccountId(Regions region, string accountId)
        {
            string requestUrl = GetRequestUrl(region.PlatformRoutingValue, $"/lol/match/v4/matchlists/by-account/{accountId}");
            return _client.GetRequestForItem<BasicMatchHistoryMetaData>(requestUrl);
        }

        public List<string> GetMatchHistoryListByPuuid(Regions region, string puuid)
        {
            string requestUrl = GetRequestUrl(region.RegionalRoutingValue, $"/lol/match/v5/matches/by-puuid/{puuid}/ids");
            return _client.GetRequestForList<string>(requestUrl);
        }

        /// <summary>
        /// Takes in a region and a match id and grabs a match history object
        /// </summary>
        /// <param name="region"></param>
        /// <param name="matchId"></param>
        /// <returns></returns>
        public MatchData GetDetailedMatchHistoryFromGameId(Regions region, string matchId)
        {
            GetReadableMatchId(region, ref matchId);
            string requestUrl = GetRequestUrl(region.RegionalRoutingValue, $"/lol/match/v5/matches/{matchId}");

            return _client.GetRequestForItem<MatchData>(requestUrl);
        }

        public TimelineData GetTimelineFromGameId(Regions region, string matchId)
        {
            GetReadableMatchId(region, ref matchId);
            string requestUrl = GetRequestUrl(region.RegionalRoutingValue, $"/lol/match/v5/matches/{matchId}/timeline");
            return _client.GetRequestForItem<TimelineData>(requestUrl);
        }

        #endregion

        #region Helper Functions

        private string GetRequestUrl(params string[] urls)
        {
            return string.Join("", urls);
        }

        private void GetReadableMatchId(Regions region, ref string matchId)
        {
            if (!matchId.Contains(region.RegionalHeaderValue))
            {
                matchId = $"{region.RegionalHeaderValue}{matchId}";
            }
        }

        #endregion
    }
}
