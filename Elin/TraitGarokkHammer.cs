public class TraitGarokkHammer : TraitItem
{
	public override bool CanUse(Chara c)
	{
		if (base.CanUse(c))
		{
			return !owner.isNPCProperty;
		}
		return false;
	}

	public override bool OnUse(Chara c)
	{
		ActEffect.Proc(EffectId.ChangeRarity, EClass.pc, null, 100, new ActRef
		{
			n1 = owner.material.alias,
			refThing = owner.Thing
		});
		return true;
	}
}
