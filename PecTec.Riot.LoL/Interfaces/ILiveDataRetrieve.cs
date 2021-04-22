using PecTec.Riot.LoL.Models;
using PecTec.Riot.LoL.Models.Account;
using PecTec.Riot.LoL.Models.Account.MatchHistory;
using PecTec.Riot.LoL.Models.Account.MatchHistory.Timeline;
using System.Collections.Generic;

namespace PecTec.Riot.LoL.Interfaces
{
    public interface ILiveDataRetrieve
    {
        public Summoner RetrieveSummonerByName(Regions region, string summonerName);
        public Summoner RetrieveSummonerByAccountId(Regions region, string accountId);
        public Summoner RetrieveSummonerByPUUID(Regions region, string puuid);
        public Summoner RetrieveSummonerBySummonerId(Regions region, string summonerId);

        public BasicMatchHistoryMetaData GetBasicMatchHistoryByAccountId(Regions region, string accountId);
        public List<string> GetMatchHistoryListByPuuid(Regions region, string puuid);
        public MatchData GetDetailedMatchHistoryFromGameId(Regions region, string matchId);
        public TimelineData GetTimelineFromGameId(Regions region, string matchId);

    }
}
