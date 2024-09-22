namespace CustomGrip
{
    using System.Collections.Generic;
    using UnityEngine;
    using BepInEx;
    using HarmonyLib;
    using System;

    [BepInPlugin(GUID, NAME, VERSION)]
    public class CustomGrip : BaseUnityPlugin
    {
        public const string GUID = "com.ehaugw.customgrip";
        public const string VERSION = "1.0.0";
        public const string NAME = "CustomGrip";

        internal void Awake()
        {
            var harmony = new Harmony(GUID);
            harmony.PatchAll();
        }
        public static void ChangeGrip(Character character, Weapon.WeaponType toMoveset)
        {
            character?.Animator?.SetInteger("WeaponType", (int)toMoveset);
        }

        public static void ResetGrip(Character character)
        {
            if (character?.CurrentWeapon is Weapon weapon)
                character?.Animator?.SetInteger("WeaponType", (int)weapon.Type);
        }
    }

    //TERMINATE CUSTOM MOVESET
    [HarmonyLib.HarmonyPatch(typeof(Character), "HitEnded")]
    public class Character_HitEnded
    {
        [HarmonyPrefix]
        public static void Prefix(Character __instance, ref int _attackID)
        {
            if (_attackID != -2 && !__instance.IsCasting)
            {
                CustomGrip.ResetGrip(__instance);
            }
        }
    }

    //TERMINATE CUSTOM MOVESET
    [HarmonyLib.HarmonyPatch(typeof(Character), "StopLocomotionAction")]
    public class Character_StopLocomotionAction
    {
        [HarmonyPrefix]
        public static void Prefix(Character __instance)
        {
            CustomGrip.ResetGrip(__instance);
        }
    }
}
