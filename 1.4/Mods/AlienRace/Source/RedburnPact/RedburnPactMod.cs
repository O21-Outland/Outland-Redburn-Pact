using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace RedburnPact
{
    public class RedburnPactMod : Mod
    {
        public static RedburnPactMod mod;
        public static RedburnPactSettings settings;

        internal static string VersionDir => Path.Combine(ModLister.GetActiveModWithIdentifier("Neronix17.Outland.RedburnPact").RootDir.FullName, "Version.txt");
        public static string CurrentVersion { get; private set; }

        public RedburnPactMod(ModContentPack content) : base(content)
        {
            mod = this;
            settings = GetSettings<RedburnPactSettings>();

            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            CurrentVersion = $"{version.Major}.{version.Minor}.{version.Build}";

            LogUtil.LogMessage($"{CurrentVersion} ::");

            File.WriteAllText(VersionDir, CurrentVersion);

            Harmony OuterRimHarmony = new Harmony("Neronix17.Outland.RedburnPact");
            OuterRimHarmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        //public override string SettingsCategory() => "Outland - Redburn Pact";

        //public override void DoSettingsWindowContents(Rect inRect)
        //{
        //    base.DoSettingsWindowContents(inRect);
        //}
    }
}
