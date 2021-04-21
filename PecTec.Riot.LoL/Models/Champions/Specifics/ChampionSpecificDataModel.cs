using System;
using System.Collections.Generic;
using System.Text;

namespace PecTec.Riot.LoL.Models.Champions.Specifics
{
    public class ChampionSpecificDataModel
    {
        public class Root
        {
            public string Type { get; set; }
            public string Format { get; set; }
            public string Version { get; set; }
            public Dictionary<string, ChampionSpecificModel> Data { get; set; }
        }
    }
}
