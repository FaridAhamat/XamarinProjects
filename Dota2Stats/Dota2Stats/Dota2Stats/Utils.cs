﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Dota2Stats
{
    /// <summary>
    /// Utility class
    /// </summary>
    internal class Utils
    {
        /// <summary>
        /// Execute the web API call
        /// </summary>
        /// <param name="requestUri"></param>
        /// <returns>String containing the response from the requestUri</returns>
        public static async Task<string> RequestCall(string requestUri)
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync(requestUri);

                if (string.IsNullOrWhiteSpace(result))
                {
                    return null;
                }

                return result;
            }
        }

        /// <summary>
        /// Convert from Steam64 ID to Steam32
        /// </summary>
        /// <param name="steam64"></param>
        /// <returns></returns>
        public static int ConvertSteam64ToSteam32(long steam64)
        {
            return (int)(steam64 - 76561197960265728);
        }

        /// <summary>
        /// Convert from Steam32 ID to Steam64
        /// </summary>
        /// <param name="steam32"></param>
        /// <returns></returns>
        public static long ConvertSteam32ToSteam64(int steam32)
        {
            return steam32 + 76561197960265728;
        }

        /// <summary>
        /// Convert the duration (in seconds) to proper format
        /// </summary>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static string ConvertDurationToString(int duration)
        {
            TimeSpan time = TimeSpan.FromSeconds(duration);
            return time.ToString(@"hh\:mm\:ss");
        }

        /// <summary>
        /// Convert the duration (in seconds) to TimeSpan format
        /// </summary>
        /// <param name="duration"></param>
        /// <returns>TimeSpan object</returns>
        public static TimeSpan ConvertDurationToTimeSpan(int duration)
        {
            return new TimeSpan(0, 0, duration);
        }

        /// <summary>
        /// Get the content SteamPlayer class from GetPlayerSummariesRes
        /// </summary>
        /// <param name="playerSummaries">GetPlayerSummariesRes class</param>
        /// <returns></returns>
        public static SteamPlayer GetSteamPlayer(GetPlayerSummariesRes playerSummaries)
        {
            return (from player in playerSummaries.Response.Players select player).FirstOrDefault();
        }

        // Not used for now
        //internal static Dictionary<int, string> HeroesNameDict = new Dictionary<int, string> {
        //    { 1, "Anti-Mage" },
        //    { 2, "Axe" },
        //    { 3, "Bane" },
        //    { 4, "Bloodseeker" },
        //    { 5, "Crystal Maiden" },
        //    { 6, "Drow Ranger" },
        //    { 7, "Earthshaker" },
        //    { 8, "Juggernaut" },
        //    { 9, "Mirana" },
        //    { 10, "Morphling" },
        //    { 11, "Shadow Fiend" },
        //    { 12, "Phantom Lancer" },
        //    { 13, "Puck" },
        //    { 14, "Pudge" },
        //    { 15, "Razor" },
        //    { 16, "Sand King" },
        //    { 17, "Storm Spirit" },
        //    { 18, "Sven" },
        //    { 19, "Tiny" },
        //    { 20, "Vengeful Spirit" },
        //    { 21, "Windranger" },
        //    { 22, "Zeus" },
        //    { 23, "Kunkka" },
        //    { 25, "Lina" },
        //    { 26, "Lion" },
        //    { 27, "Shadow Shaman" },
        //    { 28, "Slardar" },
        //    { 29, "Tidehunter" },
        //    { 30, "Witch Doctor" },
        //    { 31, "Lich" },
        //    { 32, "Riki" },
        //    { 33, "Enigma" },
        //    { 34, "Tinker" },
        //    { 35, "Sniper" },
        //    { 36, "Necrophos" },
        //    { 37, "Warlock" },
        //    { 38, "Beastmaster" },
        //    { 39, "Queen of Pain" },
        //    { 40, "Venomancer" },
        //    { 41, "Faceless Void" },
        //    { 42, "Wraith King" },
        //    { 43, "Death Prophet" },
        //    { 44, "Phantom Assassin" },
        //    { 45, "Pugna" },
        //    { 46, "Templar Assassin" },
        //    { 47, "Viper" },
        //    { 48, "Luna" },
        //    { 49, "Dragon Knight" },
        //    { 50, "Dazzle" },
        //    { 51, "Clockwerk" },
        //    { 52, "Leshrac" },
        //    { 53, "Nature's Prophet" },
        //    { 54, "Lifestealer" },
        //    { 55, "Dark Seer" },
        //    { 56, "Clinkz" },
        //    { 57, "Omniknight" },
        //    { 58, "Enchantress" },
        //    { 59, "Huskar" },
        //    { 60, "Night Stalker" },
        //    { 61, "Broodmother" },
        //    { 62, "Bounty Hunter" },
        //    { 63, "Weaver" },
        //    { 64, "Jakiro" },
        //    { 65, "Batrider" },
        //    { 66, "Chen" },
        //    { 67, "Spectre" },
        //    { 68, "Ancient Apparition" },
        //    { 69, "Doom" },
        //    { 70, "Ursa" },
        //    { 71, "Spirit Breaker" },
        //    { 72, "Gyrocopter" },
        //    { 73, "Alchemist" },
        //    { 74, "Invoker" },
        //    { 75, "Silencer" },
        //    { 76, "Outworld Devourer" },
        //    { 77, "Lycan" },
        //    { 78, "Brewmaster" },
        //    { 79, "Shadow Demon" },
        //    { 80, "Lone Druid" },
        //    { 81, "Chaos Knight" },
        //    { 82, "Meepo" },
        //    { 83, "Treant Protector" },
        //    { 84, "Ogre Magi" },
        //    { 85, "Undying" },
        //    { 86, "Rubick" },
        //    { 87, "Disruptor" },
        //    { 88, "Nyx Assassin" },
        //    { 89, "Naga Siren" },
        //    { 90, "Keeper of the Light" },
        //    { 91, "Io" },
        //    { 92, "Visage" },
        //    { 93, "Slark" },
        //    { 94, "Medusa" },
        //    { 95, "Troll Warlord" },
        //    { 96, "Centaur Warrunner" },
        //    { 97, "Magnus" },
        //    { 98, "Timbersaw" },
        //    { 99, "Bristleback" },
        //    { 100, "Tusk" },
        //    { 101, "Skywrath Mage" },
        //    { 102, "Abaddon" },
        //    { 103, "Elder Titan" },
        //    { 104, "Legion Commander" },
        //    { 105, "Techies" },
        //    { 106, "Ember Spirit" },
        //    { 107, "Earth Spirit" },
        //    { 108, "Underlord" },
        //    { 109, "Terrorblade" },
        //    { 110, "Phoenix" },
        //    { 111, "Oracle" },
        //    { 112, "Winter Wyvern" },
        //    { 113, "Arc Warden" },
        //    { 114, "Monkey King" },
        //};

        internal static Dictionary<int, string> HeroesImagesDict = new Dictionary<int, string> {
            { 1, "hero_antimage.png" },
            { 2, "hero_axe.png" },
            { 3, "hero_bane.png" },
            { 4, "hero_bloodseeker.png" },
            { 5, "hero_crystalmaiden.png" },
            { 6, "hero_drowranger.png" },
            { 7, "hero_earthshaker.png" },
            { 8, "hero_juggernaut.png" },
            { 9, "hero_mirana.png" },
            { 10, "hero_morphling.png" },
            { 11, "hero_shadowfiend.png" },
            { 12, "hero_phantomlancer.png" },
            { 13, "hero_puck.png" },
            { 14, "hero_pudge.png" },
            { 15, "hero_razor.png" },
            { 16, "hero_sandking.png" },
            { 17, "hero_stormspirit.png" },
            { 18, "hero_sven.png" },
            { 19, "hero_tiny.png" },
            { 20, "hero_vengefulspirit.png" },
            { 21, "hero_windranger.png" },
            { 22, "hero_zeus.png" },
            { 23, "hero_kunkka.png" },
            { 25, "hero_lina.png" },
            { 26, "hero_lion.png" },
            { 27, "hero_shadowshaman.png" },
            { 28, "hero_slardar.png" },
            { 29, "hero_tidehunter.png" },
            { 30, "hero_witchdoctor.png" },
            { 31, "hero_lich.png" },
            { 32, "hero_riki.png" },
            { 33, "hero_enigma.png" },
            { 34, "hero_tinker.png" },
            { 35, "hero_sniper.png" },
            { 36, "hero_necrophos.png" },
            { 37, "hero_warlock.png" },
            { 38, "hero_beastmaster.png" },
            { 39, "hero_queenofpain.png" },
            { 40, "hero_venomancer.png" },
            { 41, "hero_facelessvoid.png" },
            { 42, "hero_wraithking.png" },
            { 43, "hero_deathprophet.png" },
            { 44, "hero_phantomassassin.png" },
            { 45, "hero_pugna.png" },
            { 46, "hero_templarassassin.png" },
            { 47, "hero_viper.png" },
            { 48, "hero_luna.png" },
            { 49, "hero_dragonknight.png" },
            { 50, "hero_dazzle.png" },
            { 51, "hero_clockwerk.png" },
            { 52, "hero_leshrac.png" },
            { 53, "hero_naturesprophet.png" },
            { 54, "hero_lifestealer.png" },
            { 55, "hero_darkseer.png" },
            { 56, "hero_clinkz.png" },
            { 57, "hero_omniknight.png" },
            { 58, "hero_enchantress.png" },
            { 59, "hero_huskar.png" },
            { 60, "hero_nightstalker.png" },
            { 61, "hero_broodmother.png" },
            { 62, "hero_bountyhunter.png" },
            { 63, "hero_weaver.png" },
            { 64, "hero_jakiro.png" },
            { 65, "hero_batrider.png" },
            { 66, "hero_chen.png" },
            { 67, "hero_spectre.png" },
            { 68, "hero_ancientapparition.png" },
            { 69, "hero_doom.png" },
            { 70, "hero_ursa.png" },
            { 71, "hero_spiritbreaker.png" },
            { 72, "hero_gyrocopter.png" },
            { 73, "hero_alchemist.png" },
            { 74, "hero_invoker.png" },
            { 75, "hero_silencer.png" },
            { 76, "hero_outworlddevourer.png" },
            { 77, "hero_lycan.png" },
            { 78, "hero_brewmaster.png" },
            { 79, "hero_shadowdemon.png" },
            { 80, "hero_lonedruid.png" },
            { 81, "hero_chaosknight.png" },
            { 82, "hero_meepo.png" },
            { 83, "hero_treant.png" },
            { 84, "hero_ogremagi.png" },
            { 85, "hero_undying.png" },
            { 86, "hero_rubick.png" },
            { 87, "hero_disruptor.png" },
            { 88, "hero_nyxassassin.png" },
            { 89, "hero_nagasiren.png" },
            { 90, "hero_keeperofthelight.png" },
            { 91, "hero_wisp.png" },
            { 92, "hero_visage.png" },
            { 93, "hero_slark.png" },
            { 94, "hero_medusa.png" },
            { 95, "hero_trollwarlord.png" },
            { 96, "hero_centaurwarrunner.png" },
            { 97, "hero_magnus.png" },
            { 98, "hero_timbersaw.png" },
            { 99, "hero_bristleback.png" },
            { 100, "hero_tusk.png" },
            { 101, "hero_skywrathmage.png" },
            { 102, "hero_abaddon.png" },
            { 103, "hero_eldertitan.png" },
            { 104, "hero_legioncommander.png" },
            { 105, "hero_techies.png" },
            { 106, "hero_emberspirit.png" },
            { 107, "hero_earthspirit.png" },
            { 108, "hero_underlord.png" },
            { 109, "hero_terrorblade.png" },
            { 110, "hero_phoenix.png" },
            { 111, "hero_oracle.png" },
            { 112, "hero_winterwyvern.png" },
            { 113, "hero_arcwarden.png" },
            { 114, "hero_monkeyking.png" },
        };

        internal static Dictionary<int, string> ItemImagesDict = new Dictionary<int, string>
        {
            { 1, "item_blinkdagger.png" },
            { 2, "item_bladesofattack.png" },
            { 3, "item_broadsword.png" },
            { 4, "item_chainmail.png" },
            { 5, "item_claymore.png" },
            { 6, "item_helmofironwill.png" },
            { 7, "item_javelin.png" },
            { 8, "item_mithrilhammer.png" },
            { 9, "item_platemail.png" },
            { 10, "item_quarterstaff.png" },
            { 11, "item_quellingblade.png" },
            { 12, "item_ringofprotection.png" },
            { 13, "item_gauntlets.png" },
            { 14, "item_slippers.png" },
            { 15, "item_mantle.png" },
            { 16, "item_ironbranches.png" },
            { 17, "item_beltofstrength.png" },
            { 18, "item_bootsofelves.png" },
            { 19, "item_robe.png" },
            { 20, "item_circlet.png" },
            { 21, "item_ogreaxe.png" },
            { 22, "item_bladeofalacrity.png" },
            { 23, "item_staffofwizardry.png" },
            { 24, "item_ultimateorb.png" },
            { 25, "item_gloves.png" },
            { 26, "item_morbidmask.png" },
            { 27, "item_ringofregen.png" },
            { 28, "item_sobimask.png" },
            { 29, "item_bootsofspeed.png" },
            { 30, "item_gem.png" },
            { 31, "item_cloak.png" },
            { 32, "item_talismanofevasion.png" },
            //{ 33, "item_cheese.png" },          //Missing
            { 34, "item_magicstick.png" },
            { 36, "item_magicwand.png" },
            { 37, "item_ghostscepter.png" },
            { 38, "item_clarity.png" },
            { 39, "item_flask.png" },
            { 40, "item_dust.png" },
            { 41, "item_bottle.png" },
            { 42, "item_observerward.png" },
            { 43, "item_sentryward.png" },
            { 44, "item_tango.png" },
            { 45, "item_courier.png" },
            { 46, "item_tpscroll.png" },
            { 48, "item_bootsoftravel.png" },
            { 50, "item_phaseboots.png" },
            { 51, "item_demonedge.png" },
            { 52, "item_eaglesong.png" },
            { 53, "item_reaver.png" },
            { 54, "item_sacredrelic.png" },
            { 55, "item_hyperstone.png" },
            { 56, "item_ringofhealth.png" },
            { 57, "item_voidstone.png" },
            { 58, "item_mysticstaff.png" },
            { 59, "item_energybooster.png" },
            { 60, "item_pointbooster.png" },
            { 61, "item_vitalitybooster.png" },
            { 63, "item_powertreads.png" },
            { 65, "item_midas.png" },
            { 67, "item_oblivionstaff.png" },
            { 69, "item_perseverance.png" },
            { 71, "item_poormanshield.png" },
            { 73, "item_bracer.png" },
            { 75, "item_wraithband.png" },
            { 77, "item_nulltalisman.png" },
            { 79, "item_mekansm.png" },
            { 81, "item_vlad.png" },
            { 84, "item_flyingcourier.png" },
            { 86, "item_buckler.png" },
            { 88, "item_ringofbasilius.png" },
            { 90, "item_pipe.png" },
            { 92, "item_urnofshadows.png" },
            { 94, "item_headdress.png" },
            { 96, "item_hex.png" },
            { 98, "item_orchid.png" },
            { 100, "item_eul.png" },
            { 102, "item_forcestaff.png" },
            { 104, "item_dagon.png" },
            { 106, "item_necronomicon.png" },
            { 108, "item_aghanimscepter.png" },
            { 110, "item_refresher.png" },
            { 112, "item_assaultcuirass.png" },
            { 114, "item_heart.png" },
            { 116, "item_blackkingbar.png" },
            { 117, "item_aegis.png" },
            { 119, "item_shivasguard.png" },
            { 121, "item_bloodstone.png" },
            { 123, "item_linkensphere.png" },
            { 125, "item_vanguard.png" },
            { 127, "item_blademail.png" },
            { 129, "item_soulbooster.png" },
            { 131, "item_hoodofdefiance.png" },
            { 133, "item_rapier.png" },
            { 135, "item_monkeykingbar.png" },
            { 137, "item_radiance.png" },
            { 139, "item_butterfly.png" },
            { 141, "item_daedalus.png" },
            { 143, "item_basher.png" },
            { 145, "item_battlefury.png" },
            { 147, "item_manta.png" },
            { 151, "item_armlet.png" },
            { 152, "item_shadowblade.png" },
            { 154, "item_sangeandyasha.png" },
            { 156, "item_satanic.png" },
            { 158, "item_mjollnir.png" },
            { 160, "item_skadi.png" },
            { 162, "item_sange.png" },
            { 164, "item_helmofthedominator.png" },
            { 166, "item_maelstrom.png" },
            { 168, "item_desolator.png" },
            { 170, "item_yasha.png" },
            { 172, "item_maskofmadness.png" },
            { 174, "item_diffusalblade.png" },
            { 176, "item_etherealblade.png" },
            { 178, "item_soulring.png" },
            { 180, "item_arcaneboots.png" },
            { 181, "item_orbofvenom.png" },
            { 182, "item_stoutshield.png" },
            { 185, "item_drumofendurance.png" },
            { 187, "item_medallionofcourage.png" },
            { 188, "item_smoke.png" },
            { 190, "item_veilofdiscord.png" },
            //{ 193, "item_necronomicon2.png" },      //missing
            //{ 194, "item_necronomicon3.png" },      //missing
            //{ 196, "item_diffusalblade2.png" },     //missing
            //{ 201, "item_dagon2.png" },     //missing
            //{ 202, "item_dagon3.png" },     //missing
            //{ 203, "item_dagon4.png" },     //missing
            //{ 204, "item_dagon4.png" },     //missing
            { 206, "item_rodofatos.png" },
            { 208, "item_abyssalblade.png" },
            { 210, "item_heavenshalberd.png" },
            { 212, "item_ringofaquila.png" },
            { 214, "item_tranquilboots.png" },
            { 215, "item_shadowamulet.png" },
            { 216, "item_enchantedmango.png" },
            //{ 218, "item_warddispenser.png" },      //missing
            //{ 220, "item_bootsoftravel2.png" },     //missing
            { 226, "item_lotusorb.png" },
            { 229, "item_solarcrest.png" },
            { 231, "item_guardiangreaves.png" },
            { 232, "item_aetherlens.png" },
            { 235, "item_octarinecore.png" },
            { 237, "item_faeriefire.png" },
            { 239, "item_irontalong.png" },
            { 240, "item_blightstone.png" },
            //{ 241, "item_tangosingle.png" },          //missing
            { 242, "item_crimsonguard.png" },
            { 244, "item_windlace.png" },
            { 247, "item_moonshard.png" },
            { 249, "item_silveredge.png" },
            { 250, "item_bloodthorn.png" },
            { 252, "item_echosabre.png" },
            { 254, "item_glimmercape.png" },
            { 257, "item_tomeofknowledge.png" },
            { 263, "item_hurricanepike.png" },
            //{ 264, "item_banana.png" },                 //missing
            { 265, "item_infusedraindrop.png" },
            //{ 1000, "item_halloweencandycorn.png" },    //missing
            //{ 1, "" },
            //{ 1, "" },
            //{ 1, "" },
            //{ 1, "" },
            //{ 1, "" },
            //{ 1, "" },
            //{ 1, "" },
        };

        internal static Dictionary<int, string> GameModeDict = new Dictionary<int, string>
        {
            { 0, "Unknown" },
            { 1, "All Pick" },
            { 2, "Captains Mode" },
            { 3, "Random Draft" },
            { 4, "Single Draft" },
            { 5, "All Random" },
            { 6, "Intro" },
            { 7, "Diretide" },
            { 8, "Reverse Captains Mode" },
            { 9, "Greeviling" },
            { 10, "Tutorial" },
            { 11, "Mid Only" },
            { 12, "Least Played" },
            { 13, "Limited Heroes" },
            { 14, "Compendium Matchmaking" },
            { 15, "Custom" },
            { 16, "Captains Draft" },
            { 17, "Balanced Draft" },
            { 18, "Ability Draft" },
            { 19, "Event" },
            { 20, "All Random Death Match" },
            { 21, "1v1 Mid" },
            { 22, "Ranked All Pick" },
        };
    }
}
