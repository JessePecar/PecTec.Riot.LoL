using System.Collections.Generic;

namespace PecTec.Riot.LoL.Models.Champions
{
    public class Champions
    {
        public string Type { get; set; }
        public string Format { get; set; }
        public string Version { get; set; }
        public Dictionary<string, Champion> Data { get; set; }
    }
}
