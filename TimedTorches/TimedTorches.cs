using System.Reflection;
using System.Linq;
using HarmonyLib;
using BepInEx;
using BepInEx.Configuration;
using UnityEngine;

namespace TimedTorches
{
    [BepInPlugin("tastychickenlegs.TimedTorches", "Timed Torches", "0.6.2")]
    [BepInProcess("valheim.exe")]
    public class ValheimMod : BaseUnityPlugin
    {
        /*
         * Special thank you to Gurrlin for the original idea and mod. I've updated the code with fixes for the Valheim Frozen Caves update
         * Gurrlin is credited in the AssemblyInfo.cs file, and here. All credits go to Gurrlin. 
         */
        private readonly Harmony harmony = new Harmony("tastychickenlegs.TimedTorches");

        //private static ConfigEntry<int> _configNexusID;  -Not using this feature
        private static ConfigEntry<bool> _configEnabled;
        private static ConfigEntry<float> _configOnTime;
        private static ConfigEntry<float> _configOffTime;
        private static ConfigEntry<bool> _configAlwaysOnInDarkBiomes;
        private static ConfigEntry<string> _configAffectedSources;
        private static ConfigEntry<bool> _configAllowAddingFuel;
        private static ConfigEntry<float> _configFuelDurationMultiplier;
        private static ConfigEntry<string> _configFuelDurationSources;

        private static string[] affectedSources = new string[]
        {
            "piece_groundtorch_wood",
            "piece_groundtorch",
            "piece_groundtorch_green",
            "piece_groundtorch_blue",
            "piece_walltorch",
            "piece_brazierceiling01",
        };

        private static string[] fuelDurationSources = new string[]
        {
            "piece_groundtorch_wood",
            "piece_groundtorch",
            "piece_groundtorch_green",
            "piece_groundtorch_blue",
            "piece_walltorch",
            "piece_brazierceiling01",
        };

        void Awake()
        {
            _configEnabled = Config.Bind<bool>("General", "Enabled", defaultValue: true, "Sets the mod to be enabled or not.");

            if(_configEnabled.Value)
            {
                // _configNexusID = Config.Bind<int>("General", "NexusID", 962, "Nexus mod ID for 'Nexus Update Check' mod compatibility.");

                _configOnTime = Config.Bind<float>("General", "OnTime", 0.6875f, "Time of day when torches should turn ON. 0.6875f = 4.30pm (0f and 1f is midnight, 0.5f is noon. If onTime == offTime affected fireplaces will burn 24/7)");
                _configOffTime = Config.Bind<float>("General", "OffTime", 0.27f, "Time of day when torches should turn OFF. 0.27f = 6.30am (0f and 1f is midnight, 0.5f is noon. If onTime == offTime affected fireplaces will burn 24/7)");
                _configAlwaysOnInDarkBiomes = Config.Bind<bool>("General", "AlwaysOnInDarkBiomes", defaultValue: true, "If true, torches will always burn in areas that Valheim considers 'always dark'. E.g Mistlands or any biome during a storm");
                _configAffectedSources = Config.Bind<string>("General", "AffectedFireplaceSources", string.Join(",", affectedSources), "List of 'Fireplace' sources to be affected by the mod, including objects such as campfires and torches.");

                _configAllowAddingFuel = Config.Bind<bool>("Fuel", "AllowAddingFuel", defaultValue: false, "If true, enable adding fuel to torches which will make them burn during daytime as well. (Fuel will still be used during nighttime)");
                _configFuelDurationMultiplier = Config.Bind<float>("Fuel", "FuelDurationMultiplier", 1f, "Multiplies the duration of each fuel added to objects listed in the 'FuelDurationSources'. A value of 2 would mean each added fuel burns twice as long)");
                _configFuelDurationSources = Config.Bind<string>("Fuel", "FuelDurationSources", string.Join(",", fuelDurationSources), "List of 'Fireplace' sources to be affected by the 'FuelDurationMultiplier'.");

                affectedSources = _configAffectedSources.Value.Split(',');
                fuelDurationSources = _configFuelDurationSources.Value.Split(',');

                harmony.PatchAll();
            }
        }

        void OnDestroy()
        {
            harmony.UnpatchSelf();
        }

        [HarmonyPatch(typeof(Fireplace), nameof(Fireplace.Awake))]
        class FireplaceAwakePre_Patch
        {
            static void Prefix(Fireplace __instance, ref float ___m_startFuel)
            {
                if(affectedSources.Contains(Utils.GetPrefabName(__instance.gameObject)))
                {
                    ___m_startFuel = 0;
                }
            }
        }

        [HarmonyPatch(typeof(Fireplace), nameof(Fireplace.Awake))]
		class FireplaceAwakePost_Patch
		{
            static void Postfix(Fireplace __instance, ref float ___m_secPerFuel)
			{
                if(fuelDurationSources.Contains(Utils.GetPrefabName(__instance.gameObject)))
                {
                    ___m_secPerFuel *= _configFuelDurationMultiplier.Value;
                }
			}
		}

        
        [HarmonyPatch(typeof(Fireplace), nameof(Fireplace.GetHoverText))]
        class FireplaceGetHoverText_Patch
        {
            static void Postfix(Fireplace __instance, ref string __result, ref ZNetView ___m_nview, ref string ___m_name)
            {
                
                if(affectedSources.Contains(Utils.GetPrefabName(__instance.gameObject)) && !_configAllowAddingFuel.Value)
                {
                    __result = Localization.instance.Localize(___m_name + "\n[<color=yellow><b>1-8</b></color>] Use Item");
                }
            }
        }

        [HarmonyPatch(typeof(Fireplace), nameof(Fireplace.Interact))]
        class FireplaceInteract_Patch
        {
            static bool Prefix(Fireplace __instance, ref bool __result)
            {
                if(affectedSources.Contains(Utils.GetPrefabName(__instance.gameObject)) && !_configAllowAddingFuel.Value)
                {
                    __result = false;
                    return false;
                }
                return true;
            }
        }

        [HarmonyPatch(typeof(Fireplace), nameof(Fireplace.IsBurning))]
        class FireplaceIsBurning_Patch
        {
            static void Postfix(Fireplace __instance, ref bool __result, ref GameObject ___m_enabledObject)
            {
                if(affectedSources.Contains(Utils.GetPrefabName(__instance.gameObject)))
                {
                    // Should never burn if under water
                    //commenented out to fix for Valheim Frost Caves
                    // TastyChickenLegs 03/12/2022

                    //float waterLevel = WaterVolume.GetWaterLevel(___m_enabledObject.transform.position);
                    //if(___m_enabledObject.transform.position.y < waterLevel)
                    //{
                    //    return;
                    //}

                    // Calculate if the torch should currently be lit
                    bool shouldBeLit = false;
                    float dayFraction = (float)typeof(EnvMan).GetField("m_smoothDayFraction", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(EnvMan.instance);
                    if(_configOffTime.Value == _configOnTime.Value)
                    {
                        shouldBeLit = true;
                    }
                    else if(_configOffTime.Value < _configOnTime.Value)
                    {
                        if((dayFraction >= _configOnTime.Value && dayFraction <= 1f) || dayFraction <= _configOffTime.Value)
                        {
                            shouldBeLit = true;
                        }
                    }
                    else if(dayFraction >= _configOnTime.Value && dayFraction <= _configOffTime.Value)
                    {
                        shouldBeLit = true;
                    }

                    EnvSetup currentEnvironment = EnvMan.instance.GetCurrentEnvironment();
                    bool isAlwaysDarkBiome = currentEnvironment != null && currentEnvironment.m_alwaysDark;

                    if(shouldBeLit || (isAlwaysDarkBiome && _configAlwaysOnInDarkBiomes.Value))
                    {
                        __result = true;
                    }
                    else if(!_configAllowAddingFuel.Value)
                    {
                        __result = false;
                    }
                }
			}
		}
    }
}
