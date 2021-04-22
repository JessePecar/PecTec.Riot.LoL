﻿namespace PecTec.Riot.LoL.Models.Account.MatchHistory
{
    public class BasicMatchHistory
    {
        public string PlatformId { get; set; }
        public long GameId { get; set; }
        public int Champion { get; set; }
        public int Queue { get; set; }
        public int Season { get; set; }
        public long Timestamp { get; set; }
        public string Role { get; set; }
        public string Lane { get; set; }
    }
}