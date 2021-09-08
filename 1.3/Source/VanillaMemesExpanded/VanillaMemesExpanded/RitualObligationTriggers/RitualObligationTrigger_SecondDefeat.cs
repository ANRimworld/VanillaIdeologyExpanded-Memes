﻿using System;
using Verse;
using RimWorld;
using System.Collections.Generic;


namespace VanillaMemesExpanded
{
	public class RitualObligationTrigger_SecondDefeat : RitualObligationTrigger
	{

        public int tickCounter = 0;
        public int tickInterval = 6000;
		private static List<Pawn> existingObligations = new List<Pawn>();

		public override void Tick()
        {
            tickCounter++;
            if ((tickCounter > tickInterval))
            {


				if (this.ritual.activeObligations != null) {
					foreach (RitualObligation ritualObligation in this.ritual.activeObligations)
					{
						existingObligations.Add(ritualObligation.targetA.Thing as Pawn);
					}

				} 
				
				foreach (Pawn pawn in PawnsFinder.AllMapsCaravansAndTravelingTransportPods_Alive_Colonists)
				{
					if (!existingObligations.Contains(pawn) && pawn.Ideo != null)
					{
						if (pawn.Map.GetComponent<MapComponent_PawnsInMapDesiringRitualSuicide>()?.pawnsDesiringSuicide.Contains(pawn)==true)
						{
							this.ritual.AddObligation(new RitualObligation(this.ritual, pawn, false));
						}
					}
				}
				tickCounter = 0;
				existingObligations.Clear();
			}
			

		}
		
	}
}