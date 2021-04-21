using System.Collections.Generic;

namespace PecTec.Riot.LoL.Models.Champions.Specifics
{
    public class Block
    {
        public string Type { get; set; }
        public bool RecMath { get; set; }
        public bool RecSteps { get; set; }
        public int MinSummonerLevel { get; set; }
        public int MaxSummonerLevel { get; set; }
        public string ShowIfSummonerSpell { get; set; }
        public string HideIfSummonerSpell { get; set; }
        public string AppendAfterSection { get; set; }
        public List<string> VisibleWithAllOf { get; set; }
        public List<string> HiddenWithAnyOf { get; set; }
        public List<Item> Items { get; set; }
    }
}
