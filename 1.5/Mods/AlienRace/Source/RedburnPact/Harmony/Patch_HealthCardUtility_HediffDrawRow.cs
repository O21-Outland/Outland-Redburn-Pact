using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

using HarmonyLib;

namespace RedburnPact
{
    [HarmonyPatch(typeof(HealthCardUtility), "DrawHediffRow")]
    public class Patch_HealthCardUtility_HediffDrawRow
    {
        [HarmonyPostfix]
        public static void Postfix(Rect rect, Pawn pawn, IEnumerable<Hediff> diffs, ref float curY)
        {
            Hediff_EvolvingRace hediff = (Hediff_EvolvingRace)diffs.ToList().Find(h => h is Hediff_EvolvingRace);

            if(hediff != null)
            {
                Rect card = new Rect(0f, curY, rect.width, 0f);

                float textHeight = 20f;
                card.height = 8f + textHeight + 18f + ((Prefs.DevMode && DebugSettings.godMode) ? textHeight : 0f);

                Widgets.DrawMenuSection(card);

                GUI.BeginGroup(card);
                EvolvingRaceUtil.DrawHediffCard(card, pawn, hediff, textHeight);
                GUI.EndGroup();
                curY += card.height;
            }
        }
    }
}
