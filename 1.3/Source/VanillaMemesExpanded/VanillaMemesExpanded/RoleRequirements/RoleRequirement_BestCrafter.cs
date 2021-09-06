﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Verse;
using RimWorld;

namespace VanillaMemesExpanded
{
	public class RoleRequirement_BestCrafter : RoleRequirement
	{
		

		public override bool Met(Pawn p, Precept_Role role)
		{

            if (p.Ideo.HasPrecept(InternalDefOf.VME_Leader_BestCrafter))
            {

				Pawn mostSkilledPawn = null;
				int highestSkillLevel=0;

				foreach (Pawn pawn in Find.CurrentMap.mapPawns.FreeColonistsSpawned)
				{
					if (pawn.skills.GetSkill(SkillDefOf.Crafting).Level > highestSkillLevel)
					{
						highestSkillLevel = pawn.skills.GetSkill(SkillDefOf.Crafting).Level;
						mostSkilledPawn = pawn;
					}
				}
				if (mostSkilledPawn == p)
                {
					return true;
				}else return false;


			} else return true;



			
		}
	}

}
