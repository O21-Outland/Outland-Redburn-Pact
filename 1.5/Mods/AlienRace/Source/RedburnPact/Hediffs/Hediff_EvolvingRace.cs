using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace RedburnPact
{
    public class Hediff_EvolvingRace : HediffWithComps
    {
        public float currentExp = 0f;

        public bool CanAscend => currentExp >= 1f;

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref currentExp, "currentExp", 0f);
        }

        public DefModExt_EvolvingRace ModExt => def.GetModExtension<DefModExt_EvolvingRace>();

        public void GiveExp(float exp)
        {
            if (currentExp + exp > 1f)
            {
                currentExp = 1f;
            }
            else
            {
                currentExp += exp;
            }
        }

        public void Ascend(ThingDef ascensionDef)
        {
            IntVec3 position = pawn.Position;
            Map map = pawn.Map;
            pawn.DeSpawn();
            RegionListersUpdater.DeregisterInRegions(pawn, map);
            ThingDef newDef = ascensionDef;

            HediffSet hediffSet = pawn.health.hediffSet;
            pawn.def = newDef;
            pawn.health = new Pawn_HealthTracker(pawn);
            pawn.health.hediffSet.DirtyCache();
            pawn.health.hediffSet = hediffSet;

            RegionListersUpdater.RegisterInRegions(pawn, map);
            map.mapPawns.UpdateRegistryForPawn(pawn);
            pawn.Drawer.renderer.graphics.ResolveAllGraphics();
            pawn.ExposeData();
            GenSpawn.Spawn(pawn, position, map);
            pawn.health.RemoveHediff(this);
        }

        public List<FloatMenuOption> GetFloatMenuOptions()
        {
            List<FloatMenuOption> options = new List<FloatMenuOption>();

            FloatMenuOption option = new FloatMenuOption(ModExt.raceDef.LabelCap, delegate ()
            {
                Ascend(ModExt.raceDef);
            });
            options.Add(option);

            return options;
        }

        public bool HasAllRequiredSkills(List<SkillRange> skillRanges)
        {
            foreach(SkillRange skillRange in skillRanges)
            {
                if (!skillRange.Range.Includes(pawn.skills.GetSkill(skillRange.Skill).Level))
                {
                    return false;
                }
            }
            return true;
        }

        public bool HasAnyRequiredTrait(List<TraitDef> traits)
        {
            foreach(TraitDef trait in traits)
            {
                if (pawn.story.traits.HasTrait(trait))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
