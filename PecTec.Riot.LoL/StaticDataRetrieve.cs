using PecTec.Riot.Core.Interfaces;
using PecTec.Riot.LoL.Interfaces;
using PecTec.Riot.LoL.Models;
using PecTec.Riot.LoL.Models.Champions;
using PecTec.Riot.LoL.Models.Champions.Specifics;
using PecTec.Riot.LoL.Models.Items;
using PecTec.Riot.LoL.Models.Profile;
using PecTec.Riot.LoL.Models.SummonerSpells;
using PecTec.Riot.LoL.Utility;
using System.Collections.Generic;
using System.Linq;

namespace PecTec.Riot.LoL
{
    public class StaticDataRetrieve : IStaticDataRetrieve
    {
        private readonly IPecTecClient _client;
        public StaticDataRetrieve(IPecTecClient client) { _client = client; }
        
        /// <summary>
        /// Gets the champion by their unique identifier stored in the "Key" field
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="patch"></param>
        /// <returns></returns>
        public ChampionSpecificDataModel RetrieveChampionById(int Id, string patch = null)
        {
            Champions champs = RetrieveChampions(patch);

            string champName = champs.Data.Select(d => d.Value).FirstOrDefault(c => c.Key == Id)?.Id;
            if (!string.IsNullOrWhiteSpace(champName))
            {
                return RetrieveChampionByName(champName, patch);
            }
            return default;
        }

        /// <summary>
        /// Search for the champion specifics by champion name
        /// </summary>
        /// <param name="championName"></param>
        /// <param name="patch">Optional. If given null, empty, or blank, will default to the latest version</param>
        /// <returns></returns>
        public ChampionSpecificDataModel RetrieveChampionByName(string championName, string patch = null)
        {
            VerifyPatchGiven(ref patch);
            string requestUrl = DataDragonValues.ChampionSpecific(championName, patch);
            return _client.GetRequestForItem<ChampionSpecificDataModel>(requestUrl);
        }

        /// <summary>
        /// Get a list of all champions with basic information
        /// </summary>
        /// <param name="patch"></param>
        /// <returns></returns>
        public Champions RetrieveChampions(string patch = null)
        {
            VerifyPatchGiven(ref patch);
            string requestUrl = DataDragonValues.ChampionsGeneric(patch);
            return _client.GetRequestForItem<Champions>(requestUrl);
        }

        /// <summary>
        /// Get data on all items in the game
        /// </summary>
        /// <param name="patch"></param>
        /// <returns></returns>
        public ItemData RetrieveItemData(string patch = null)
        {
            VerifyPatchGiven(ref patch);
            string requestUrl = DataDragonValues.Items(patch);
            return _client.GetRequestForItem<ItemData>(requestUrl);
        }

        /// <summary>
        /// Get data on all the profile icons in the game
        /// </summary>
        /// <param name="patch"></param>
        /// <returns></returns>
        public ProfileIconData RetrieveProfileIcons(string patch = null)
        {
            VerifyPatchGiven(ref patch);
            string requestUrl = DataDragonValues.ProfileIcons(patch);
            return _client.GetRequestForItem<ProfileIconData>(requestUrl);
        }

        /// <summary>
        /// Get data on all the summoner spells in the game
        /// </summary>
        /// <param name="patch"></param>
        /// <returns></returns>
        public SummonerSpellData RetrieveSummonerSpells(string patch = null)
        {
            VerifyPatchGiven(ref patch);
            string requestUrl = DataDragonValues.SummonerSpells(patch);
            return _client.GetRequestForItem<SummonerSpellData>(requestUrl);
        }

        /// <summary>
        /// Retrieve all versions of League of Legends and the latest patch on record
        /// </summary>
        /// <returns></returns>
        public VersionsModels RetrieveVersions()
        {
            string requestUrl = DataDragonValues.Versions;
            List<string> responseObject = _client.GetRequestForList<string>(requestUrl);

            VersionsModels versions = new VersionsModels
            {
                Versions = responseObject
            };
            return versions;
        }

        private void VerifyPatchGiven(ref string patch)
        {
            if (string.IsNullOrWhiteSpace(patch))
            {
                patch = RetrieveVersions().LatestVersion;
            }
        }
    }
}
