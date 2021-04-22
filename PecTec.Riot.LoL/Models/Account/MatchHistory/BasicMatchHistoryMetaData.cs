using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PecTec.Riot.LoL.Models.Account.MatchHistory
{
    public class BasicMatchHistoryMetaData
    {
        public List<BasicMatchHistory> Matches { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public int TotalGames { get; set; }
    }
}
