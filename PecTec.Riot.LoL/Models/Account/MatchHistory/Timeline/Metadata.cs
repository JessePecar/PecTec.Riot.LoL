using System.Collections.Generic;

namespace PecTec.Riot.LoL.Models.Account.MatchHistory.Timeline
{
    public class Metadata
    {
        public string DataVersion { get; set; }
        public string MatchId { get; set; }
        public List<string> Participants { get; set; }
    }

}
