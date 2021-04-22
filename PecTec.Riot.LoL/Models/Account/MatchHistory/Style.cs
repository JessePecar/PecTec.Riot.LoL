using System.Collections.Generic;

namespace PecTec.Riot.LoL.Models.Account.MatchHistory
{
    public class Style
    {
        public string Description { get; set; }
        public List<Selection> Selections { get; set; }
        public int StyleId { get; set; }
    }
}
