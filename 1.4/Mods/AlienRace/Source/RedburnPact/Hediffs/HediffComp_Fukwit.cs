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
    public class Hediff_Fukwit : HediffWithComps
    {
        public override void Tick()
        {
            base.Tick();

            if (pawn.HostileTo(Faction.OfPlayer))
            {
                FukwitEventFire();
                FukwitFlee();
            }
        }

        public void FukwitFlee()
        {
            List<IntVec3> cells = GenAdj.CellsAdjacent8WayAndInside(pawn).ToList();
            for (int i = 0; i < cells.Count; i++)
            {
                FleckMaker.ThrowSmoke(cells[i].ToVector3(), pawn.Map, 1.5f);
            }
            pawn.DeSpawn();
        }

        public void FukwitEventFire()
        {
            Log.Error(":: Outland - Redburn Pact :: Fukwit Event not implemented yet.");
        }
    }
}
