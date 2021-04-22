﻿using System.Collections.Generic;

namespace PecTec.Riot.LoL.Models.Champions.Specifics
{
    public class Spell
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Tooltip { get; set; }
        public Leveltip Leveltip { get; set; }
        public int Maxrank { get; set; }
        public List<decimal> Cooldown { get; set; }
        public string CooldownBurn { get; set; }
        public List<int> Cost { get; set; }
        public string CostBurn { get; set; }
        public Datavalues Datavalues { get; set; }
        public List<List<decimal>> Effect { get; set; }
        public List<string> EffectBurn { get; set; }
        public List<object> Vars { get; set; }
        public string CostType { get; set; }
        public string Maxammo { get; set; }
        public List<int> Range { get; set; }
        public string RangeBurn { get; set; }
        public Image Image { get; set; }
        public string Resource { get; set; }
    }
}
