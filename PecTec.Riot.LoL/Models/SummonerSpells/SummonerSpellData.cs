using System.Collections.Generic;

namespace PecTec.Riot.LoL.Models.SummonerSpells
{
    public class SummonerSpellData
    {
        public string Type { get; set; }
        public string Version { get; set; }
        public Dictionary<string, SummonerSpell>  Data { get; set; }
    }
}
