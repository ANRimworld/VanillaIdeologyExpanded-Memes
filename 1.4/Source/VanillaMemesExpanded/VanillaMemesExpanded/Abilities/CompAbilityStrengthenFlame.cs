using System;
using Verse;
using RimWorld;

namespace VanillaMemesExpanded
{
	public class CompAbilityStrengthenFlame : CompAbilityEffect
	{
		public new CompProperties_AbilityStrengthenFlame Props
		{
			get
			{
				return (CompProperties_AbilityStrengthenFlame)this.props;
			}
		}

		public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
		{

			GenExplosion.DoExplosion(target.Cell, target.Thing.Map, this.parent.def.statBases.GetStatValueFromList(StatDefOf.Ability_EffectRadius,1), DamageDefOf.Flame, null);

			base.Apply(target, dest);
			
		}
	}
}
