using BepInEx;
using Bepinject;
using System;
using UnityEngine;

namespace DevItemInterface
{
    /* This attribute tells Utilla to look for [ModdedGameJoin] and [ModdedGameLeave] */
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInDependency("tonimacaroni.computerinterface", "1.4.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public static bool disableParticles;
        public static float instrumentVolume;
        public static bool infoPage = false;
        public void Awake()
        {
            Zenjector.Install<MainInstaller>().OnProject();
            Utilla.Events.GameInitialized += OnGameInitialized;
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
            disableParticles = (PlayerPrefs.GetString("disableParticles", "FALSE") == "TRUE");
            GorillaTagger.Instance.ShowCosmeticParticles(!disableParticles);
            instrumentVolume = PlayerPrefs.GetFloat("instrumentVolume", 0.1f);
        }

        public static void SetVolume(int intValue)
        {
            instrumentVolume = (float)intValue / 50f;
            PlayerPrefs.SetFloat("instrumentVolume", instrumentVolume);
            PlayerPrefs.Save();
        }

        public static void SetParticles(bool boolValue, string stringValue)
        {
            disableParticles = boolValue;
            PlayerPrefs.SetString("disableParticles", stringValue);
            PlayerPrefs.Save();
            GorillaTagger.Instance.ShowCosmeticParticles(!disableParticles);
        }
    }
}
