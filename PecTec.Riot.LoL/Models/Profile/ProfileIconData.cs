using System.Collections.Generic;

namespace PecTec.Riot.LoL.Models.Profile
{
    public class ProfileIconData
    {
        public string Type { get; set; }
        public string Version { get; set; }
        public Dictionary<string, ProfileIcon> Data { get; set; }
    }
}
