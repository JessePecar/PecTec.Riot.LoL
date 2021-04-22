using System.Collections.Generic;

namespace PecTec.Riot.LoL.Models.Account.MatchHistory
{
    public class Team
    {
        public List<object> Bans { get; set; }
        public Dictionary<string, MapObjective> Objectives { get; set; }
        public int TeamId { get; set; }
        public bool Win { get; set; }
    }
}
