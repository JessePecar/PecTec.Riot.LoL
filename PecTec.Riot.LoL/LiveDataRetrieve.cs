using Microsoft.Extensions.Caching.Memory;
using PecTec.Riot.Core.Interfaces;
using PecTec.Riot.LoL.Interfaces;
using PecTec.Riot.LoL.Models;
using PecTec.Riot.LoL.Models.Account;
using PecTec.Riot.LoL.Models.Account.MatchHistory;
using PecTec.Riot.LoL.Models.Account.MatchHistory.Timeline;
using System.Collections.Generic;
using System.Timers;

namespace PecTec.Riot.LoL
{
    public class LiveDataRetrieve : ILiveDataRetrieve
    {
        private const string _oneSecondTimer = "one_second_timer";
        private const string _twoMinuteTimer = "two_minute_timer";

        private readonly IPecTecClient _client;
        private readonly IMemoryCache _cache;
        public LiveDataRetrieve(IPecTecClient client, IMemoryCache cache)
        {
            _client = client;
            _cache = cache;
            _cache.Set(_oneSecondTimer, 0);
            _cache.Set(_twoMinuteTimer, 0);

            SetupTimers();
        }

        #region Request Handlers
        private T RequestForItem<T>(string requestUrl)
        {
            if (!CanSubmitRequest())
            {
                return default;
            }

            return _client.GetRequestForItem<T>(requestUrl);
        }

        private List<T> RequestForList<T>(string requestUrl)
        {
            if (!CanSubmitRequest())
            {
                return default;
            }

            return _client.GetRequestForList<T>(requestUrl);
        }

        private void SetupTimers()
        {
            Timer oneSecondTimer = new Timer(1000)
            {
                AutoReset = true,
                Enabled = true
            };
            oneSecondTimer.Elapsed += OneSecondTimer_Elapsed;
            Timer TwoMinuteTimer = new Timer(1000 * 120)
            {
                AutoReset = true,
                Enabled = true
            };
            TwoMinuteTimer.Elapsed += TwoMinuteTimer_Elapsed;
        }

        private void TwoMinuteTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _cache.Set(_twoMinuteTimer, 0);
        }

        private void OneSecondTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _cache.Set(_oneSecondTimer, 0);
        }

        #endregion

        #region Summoner

        public Summoner RetrieveSummonerByAccountId(Regions region, string accountId)
        {
            string requestUrl = GetRequestUrl(region.PlatformRoutingValue, $"/lol/summoner/v4/summoners/by-account/{accountId}");
            return RequestForItem<Summoner>(requestUrl);
        }

        public Summoner RetrieveSummonerByName(Regions region, string summonerName)
        {
            string requestUrl = GetRequestUrl(region.PlatformRoutingValue, $"/lol/summoner/v4/summoners/by-name/{summonerName}");
            return RequestForItem<Summoner>(requestUrl);
        }

        public Summoner RetrieveSummonerByPUUID(Regions region, string puuid)
        {
            string requestUrl = GetRequestUrl(region.PlatformRoutingValue, $"/lol/summoner/v4/summoners/by-puuid/{puuid}");
            return RequestForItem<Summoner>(requestUrl);
        }

        public Summoner RetrieveSummonerBySummonerId(Regions region, string summonerId)
        {
            string requestUrl = GetRequestUrl(region.PlatformRoutingValue, $"/lol/summoner/v4/summoners/{summonerId}");
            return RequestForItem<Summoner>(requestUrl);
        }

        #endregion

        #region Match History

        public BasicMatchHistoryMetaData GetBasicMatchHistoryByAccountId(Regions region, string accountId)
        {
            string requestUrl = GetRequestUrl(region.PlatformRoutingValue, $"/lol/match/v4/matchlists/by-account/{accountId}");
            return RequestForItem<BasicMatchHistoryMetaData>(requestUrl);
        }

        public List<string> GetMatchHistoryListByPuuid(Regions region, string puuid)
        {
            string requestUrl = GetRequestUrl(region.RegionalRoutingValue, $"/lol/match/v5/matches/by-puuid/{puuid}/ids");
            return RequestForList<string>(requestUrl);
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

            return RequestForItem<MatchData>(requestUrl);
        }

        public TimelineData GetTimelineFromGameId(Regions region, string matchId)
        {
            GetReadableMatchId(region, ref matchId);
            string requestUrl = GetRequestUrl(region.RegionalRoutingValue, $"/lol/match/v5/matches/{matchId}/timeline");
            return RequestForItem<TimelineData>(requestUrl);
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

        private bool CanSubmitRequest()
        {
            //TODO: Make the compare values configurable
            if (!_cache.TryGetValue(_oneSecondTimer, out int oneSecondValue) || oneSecondValue >= 20 || !_cache.TryGetValue(_twoMinuteTimer, out int twoMinuteValue) || twoMinuteValue >= 100)
            {
                // If over the limit of calls per second/per 2 minutes, then return default.
                return false;
            }
            _cache.Set(_oneSecondTimer, oneSecondValue++);
            _cache.Set(_twoMinuteTimer, twoMinuteValue++);
            return true;
        }
        #endregion
    }
}
