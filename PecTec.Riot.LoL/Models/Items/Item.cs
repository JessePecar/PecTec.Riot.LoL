using System.Collections.Generic;

namespace PecTec.Riot.LoL.Models.Items
{
    public class Item
    {
        public string Name { get; set; }
        public Rune Rune { get; set; }
        public string Description { get; set; }
        public string Colloq { get; set; }
        public string Plaintext { get; set; }
        public List<string> From { get; set; }
        public Image Image { get; set; }
        public Gold Gold { get; set; }
        public List<string> Tags { get; set; }
        public Dictionary<string, bool> Maps { get; set; }
        public Stats Stats { get; set; }
        public int Depth { get; set; }
    }
}
