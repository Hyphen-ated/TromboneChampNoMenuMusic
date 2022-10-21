using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace NoMenuMusic
{
    [HarmonyPatch]
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private static Plugin Instance;
        
        private const string PLUGIN_GUID = "hyphenated.nomenumusic";
        private const string PLUGIN_NAME = "No Menu Music";
        private const string PLUGIN_VERSION = "0.0.1";


        private void Awake()
        {
            Instance = this;
            Logger.LogInfo($"Loaded {PLUGIN_NAME} version {PLUGIN_VERSION}");
            var harmony = new Harmony(PLUGIN_GUID);
            harmony.PatchAll();

        }

        [HarmonyPatch(typeof(HomeController), "Start")]
        internal class HomeControllerStartPatch
        {
            static void Postfix(HomeController __instance)
            {
                Plugin.Instance.Logger.LogInfo("Muting main menu music");
                __instance.musobj.Stop();
            }
        }

        [HarmonyPatch(typeof(LevelSelectController), "Start")]
        internal class LevelSelectControllerStartPatch
        {
            static void Postfix(LevelSelectController __instance)
            {
                Plugin.Instance.Logger.LogInfo("Muting song select menu music");
                __instance.bgmus.Stop();
            }
        }

        [HarmonyPatch(typeof(CharSelectController), "Start")]
        internal class CharSelectControllerStartPatch
        {
            static void Postfix(CharSelectController __instance)
            {
                Plugin.Instance.Logger.LogInfo("Muting char select menu music");
                AudioSource mus_obj = __instance.GetFieldValue<AudioSource>("mus_obj");
                mus_obj.Stop();
            }
        }

        
    }
}
