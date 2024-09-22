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
        }
    }
}
