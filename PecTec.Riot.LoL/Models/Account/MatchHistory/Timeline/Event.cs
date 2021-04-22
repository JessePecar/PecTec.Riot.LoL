using System.Collections.Generic;

namespace PecTec.Riot.LoL.Models.Account.MatchHistory.Timeline
{
    public class Event
    {
        public object RealTimestamp { get; set; }
        public int Timestamp { get; set; }
        public string Type { get; set; }
        public int? Level { get; set; }
        public int? ParticipantId { get; set; }
        public int? ItemId { get; set; }
        public string LevelUpType { get; set; }
        public int? SkillSlot { get; set; }
        public int? AfterId { get; set; }
        public int? BeforeId { get; set; }
        public int? GoldGain { get; set; }
        public List<int> AssistingParticipantIds { get; set; }
        public int? Bounty { get; set; }
        public int? KillStreakLength { get; set; }
        public int? KillerId { get; set; }
        public Position Position { get; set; }
        public List<VictimDamageDealt> VictimDamageDealt { get; set; }
        public List<VictimDamageReceived> VictimDamageReceived { get; set; }
        public int? VictimId { get; set; }
        public string KillType { get; set; }
        public int? MultiKillLength { get; set; }
        public string BuildingType { get; set; }
        public string LaneType { get; set; }
        public int? TeamId { get; set; }
        public string TowerType { get; set; }
        public long? GameId { get; set; }
        public int? WinningTeam { get; set; }
    }

}
