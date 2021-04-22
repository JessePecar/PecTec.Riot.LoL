namespace PecTec.Riot.LoL.Models
{
    public class Regions
    {
        public static Regions NA1 => new Regions()
        {
            PlatformRoutingValue = "na1.api.riotgames.com",
            RegionalRoutingValue = "americas.api.riotgames.com",
            RegionalHeaderValue = "NA1_"
        };

        public static Regions BR1 => new Regions()
        {
            PlatformRoutingValue = "br1.api.riotgames.com",
            RegionalRoutingValue = "americas.api.riotgames.com",
            RegionalHeaderValue = "BR1_"
        };

        public static Regions EUN1 => new Regions()
        {
            PlatformRoutingValue = "eun1.api.riotgames.com",
            RegionalRoutingValue = "europe.api.riotgames.com",
            RegionalHeaderValue = "EUN1_"
        };

        public static Regions EUW1 => new Regions()
        {
            PlatformRoutingValue = "na1.api.riotgames.com",
            RegionalRoutingValue = "europe.api.riotgames.com",
            RegionalHeaderValue = "EUW1_"
        };

        public static Regions JP1 => new Regions()
        {
            PlatformRoutingValue = "jp1.api.riotgames.com",
            RegionalRoutingValue = "asia.api.riotgames.com",
            RegionalHeaderValue = "JP1_"
        };

        public static Regions KR => new Regions()
        {
            PlatformRoutingValue = "kr.api.riotgames.com",
            RegionalRoutingValue = "asia.api.riotgames.com",
            RegionalHeaderValue = "KR_"
        };

        public static Regions OC1 => new Regions()
        {
            PlatformRoutingValue = "oc1.api.riotgames.com",
            RegionalRoutingValue = "americas.api.riotgames.com",
            RegionalHeaderValue = "OC1_"
        };

        public static Regions LA1 => new Regions()
        {
            PlatformRoutingValue = "la1.api.riotgames.com",
            RegionalRoutingValue = "americas.api.riotgames.com",
            RegionalHeaderValue = "LA1_"
        };

        public static Regions LA2 => new Regions()
        {
            PlatformRoutingValue = "la2.api.riotgames.com",
            RegionalRoutingValue = "americas.api.riotgames.com",
            RegionalHeaderValue = "LA2_"
        };

        public static Regions TR1 => new Regions()
        {
            PlatformRoutingValue = "tr1.api.riotgames.com",
            RegionalRoutingValue = "europe.api.riotgames.com",
            RegionalHeaderValue = "TR1_"
        };

        public static Regions RU => new Regions()
        {
            PlatformRoutingValue = "asia.api.riotgames.com",
            RegionalRoutingValue = "europe.api.riotgames.com",
            RegionalHeaderValue = "RU_"
        };

        public string PlatformRoutingValue { get; set; }
        public string RegionalRoutingValue { get; set; }
        public string RegionalHeaderValue { get; set; }
    }
}
