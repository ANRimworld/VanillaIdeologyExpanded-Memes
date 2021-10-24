﻿using System;
using Verse;
using System.Collections.Generic;
using RimWorld;

namespace VanillaMemesExpanded
{
	public class ThoughtWorker_Precept_HasNonNaturalProsthetic : ThoughtWorker_Precept
	{
		protected override ThoughtState ShouldHaveThought(Pawn p)
		{
			return CountAddedAndImplantedParts(p.health.hediffSet) > 0;
		}

		public int CountAddedAndImplantedParts(HediffSet hs)
		{
			int num = 0;
			List<Hediff> hediffs = hs.hediffs;
			for (int i = 0; i < hediffs.Count; i++)
			{
                if (hediffs[i].def.countsAsAddedPartOrImplant)
                {
					if(DefDatabase<ThingCategoryDef>.GetNamedSilentFail("VFEI_BodyPartsInsect") is null){

						if (!hediffs[i].def.spawnThingOnRemoved.thingCategories.Contains(ThingCategoryDef.Named("BodyPartsNatural")))
						{
							num++;
						}

                    }
                    else
                    {
						if (!hediffs[i].def.spawnThingOnRemoved.thingCategories.Contains(ThingCategoryDef.Named("BodyPartsNatural"))&& !hediffs[i].def.spawnThingOnRemoved.thingCategories.Contains(ThingCategoryDef.Named("VFEI_BodyPartsInsect")))
						{
							num++;
						}

					}

					
					

				}



			}
			return num;
		}

	}
}
