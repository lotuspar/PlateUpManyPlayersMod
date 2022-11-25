using System.Reflection;
using BepInEx;
using HarmonyLib;
using HarmonyLib.Tools;

namespace PlateUpManyPlayersMod;

[HarmonyPatch(typeof(Kitchen.PlayerManager), MethodType.Constructor)]
public static class MaxPlayersPatch
{
    private static void Postfix(ref int ___MaxPlayers) => ___MaxPlayers = 256;
}

[BepInPlugin("lotuspar.plugins.manyplayers", "PlateUpManyPlayersMod", "1.0.0.0")]
public class Plugin : BaseUnityPlugin
{
    private void Awake()
    {
        Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), "lotuspar.plugins.manyplayers");
        HarmonyFileLog.Enabled = true;
    }
}