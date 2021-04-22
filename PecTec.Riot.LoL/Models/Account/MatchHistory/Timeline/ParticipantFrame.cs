namespace PecTec.Riot.LoL.Models.Account.MatchHistory.Timeline
{
    public class ParticipantFrame
    {
        public ChampionStats ChampionStats { get; set; }
        public int CurrentGold { get; set; }
        public DamageStats DamageStats { get; set; }
        public int GoldPerSecond { get; set; }
        public int JungleMinionsKilled { get; set; }
        public int Level { get; set; }
        public int MinionsKilled { get; set; }
        public int ParticipantId { get; set; }
        public Position Position { get; set; }
        public int TimeEnemySpentControlled { get; set; }
        public int TotalGold { get; set; }
        public int Xp { get; set; }
    }

}
