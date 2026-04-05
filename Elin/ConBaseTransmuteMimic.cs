public class ConBaseTransmuteMimic : ConTransmute
{
	public virtual Card Card => null;

	public override bool HasDuration => false;

	public virtual bool ShouldRevealOnContact => true;

	public virtual bool ShouldRevealOnPush => true;

	public virtual bool ShouldRevealOnDamage => true;

	public virtual bool IsThing => Card.isThing;

	public virtual bool IsChara => Card.isChara;

	public override void SetOwner(Chara _owner, bool onDeserialize = false)
	{
		base.SetOwner(_owner);
		owner.mimicry = this;
	}

	public override void OnRemoved()
	{
		owner.mimicry = null;
		base.OnRemoved();
	}

	public virtual void RevealMimicry(Card c, bool surprise)
	{
		if (c != null && owner.IsHostile(c.Chara))
		{
			owner.DoHostileAction(c, immediate: true);
		}
		if (surprise)
		{
			owner.AddCondition<ConAmbush>();
		}
		Kill();
	}

	public virtual string GetName(NameStyle style, int num = -1)
	{
		return Card.GetName(style, num);
	}

	public virtual string GetHoverText()
	{
		return Card.GetHoverText();
	}

	public virtual string GetHoverText2()
	{
		return Card.GetHoverText2();
	}

	public virtual void TrySetAct(ActPlan p)
	{
	}

	public virtual bool ShouldEndMimicry(Act act)
	{
		return true;
	}
}
