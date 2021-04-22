using System.Collections.Generic;

namespace PecTec.Riot.LoL.Models.Account.MatchHistory.Timeline
{
    public class Info
    {
        public int FrameInterval { get; set; }
        public List<Frame> Frames { get; set; }
        public long GameId { get; set; }
        public List<Participant> Participants { get; set; }
    }

}
