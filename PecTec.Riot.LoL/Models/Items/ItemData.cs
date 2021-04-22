using System.Collections.Generic;

namespace PecTec.Riot.LoL.Models.Items
{
    public class ItemData
    {
        public string Type { get; set; }
        public string Version { get; set; }
        public Item Basic { get; set; }
        public Dictionary<string, Item> Data { get; set; }
        public List<Group> Groups { get; set; }
        public List<Tree> Tree { get; set; }
    }
}
