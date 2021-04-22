using PecTec.Riot.LoL.Models;
using PecTec.Riot.LoL.Models.Champions;
using PecTec.Riot.LoL.Models.Champions.Specifics;
using PecTec.Riot.LoL.Models.Items;
using PecTec.Riot.LoL.Models.Profile;
using PecTec.Riot.LoL.Models.SummonerSpells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PecTec.Riot.LoL.Interfaces
{
    public interface IStaticDataRetrieve
    {
        VersionsModels RetrieveVersions();
        Champions RetrieveChampions(string patch = null);
        ChampionSpecificDataModel RetrieveChampionByName(string championName, string patch = null);
        ChampionSpecificDataModel RetrieveChampionById(int Id, string patch = null );
        ItemData RetrieveItemData(string patch = null);
        SummonerSpellData RetrieveSummonerSpells(string patch = null);
        ProfileIconData RetrieveProfileIcons(string patch = null);
    }
}
