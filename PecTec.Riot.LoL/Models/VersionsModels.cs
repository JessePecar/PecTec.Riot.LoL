using System.Collections.Generic;
using System.Linq;

namespace PecTec.Riot.LoL.Models
{
    public class VersionsModels
    {
        public List<string> Versions { get; set; }
        public string LatestVersion => Versions?.FirstOrDefault();
    } 
    


}
