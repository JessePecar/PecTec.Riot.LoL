using System.Collections.Generic;

namespace PecTec.Riot.LoL.Models.Champions.Specifics
{
    public class Recommended
    {
        public string Champion { get; set; }
        public string Title { get; set; }
        public string Map { get; set; }
        public string Mode { get; set; }
        public string Type { get; set; }
        public string CustomTag { get; set; }
        public int Sortrank { get; set; }
        public bool ExtensionPage { get; set; }
        public bool UseObviousCheckmark { get; set; }
        public object CustomPanel { get; set; }
        public List<Block> Blocks { get; set; }
    }
}
