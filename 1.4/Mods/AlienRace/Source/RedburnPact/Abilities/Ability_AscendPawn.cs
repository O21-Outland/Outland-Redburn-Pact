using RimWorld;
using RimWorld.Planet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;
using VFECore.Abilities;
using Ability = VFECore.Abilities.Ability;

namespace RedburnPact
{
    public class Ability_AscendPawn : Ability
    {
        public Hediff_EvolvingRace raceHediff;

        public override bool ValidateTarget(LocalTargetInfo target, bool showMessages = true)
        {
            raceHediff = (Hediff_EvolvingRace)target.Pawn?.health?.hediffSet?.hediffs?.Find(h => h is Hediff_EvolvingRace) ?? null;
            return base.ValidateTarget(target, showMessages) && raceHediff != null && raceHediff.CanAscend;
        }

        public override void Cast(params GlobalTargetInfo[] targets)
        {
            raceHediff.Ascend(raceHediff.ModExt.raceDef);
            base.Cast(targets);
        }
    }
}
