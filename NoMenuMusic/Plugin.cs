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
    }
}
