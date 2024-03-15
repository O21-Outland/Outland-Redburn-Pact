using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;
using VFECore.Abilities;

namespace RedburnPact
{
    public class Hediff_OrcAbilities : Hediff_Abilities
    {
        public new bool giveRandomAbilities = false;

        public override void PostAdd(DamageInfo? dinfo)
        {
            base.PostAdd(dinfo);
            AddAbility();
        }

        public void AddAbility()
        {
            CompAbilities comp = pawn.GetComp<CompAbilities>();
            if (!comp.HasAbility(RedburnDefOf.Outland_Spell_AscendGoblinoid))
            {
                comp.GiveAbility(RedburnDefOf.Outland_Spell_AscendGoblinoid);
            }
        }
    }
}
