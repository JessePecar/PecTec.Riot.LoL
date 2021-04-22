using System.Collections.Generic;

namespace PecTec.Riot.LoL.Models.Account.MatchHistory.Timeline
{
    public class Frame
    {
        public List<Event> Events { get; set; }
        public Dictionary<string, ParticipantFrame> ParticipantFrames { get; set; }
        public int Timestamp { get; set; }
    }

}
