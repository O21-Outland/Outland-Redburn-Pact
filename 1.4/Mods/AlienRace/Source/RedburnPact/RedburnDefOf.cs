using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

using VFECore.Abilities;
using AbilityDef = VFECore.Abilities.AbilityDef;

namespace RedburnPact
{
    [DefOf]
    public static class RedburnDefOf
    {
        static RedburnDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(RedburnDefOf));
        }

        public static HediffDef Outland_OrcAbilities;

        public static AbilityDef Outland_Spell_AscendGoblinoid;
    }
}
