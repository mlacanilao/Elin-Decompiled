using UnityEngine;

public class ActMoneySlap : Ability
{
	public override bool CanPressRepeat => true;

	public override bool CanPerform()
	{
		if (Act.TC != null)
		{
			return Act.CC.GetCurrency() > 0;
		}
		return false;
	}

	public override bool Perform()
	{
		bool num = this is ActMoneyThrow;
		int num2 = Mathf.Clamp(Act.CC.GetCurrency() / 100, 1, 20000000);
		Thing thing = ThingGen.Create("money").SetNum(num2);
		long dmg = (long)Mathf.Sqrt(num2) * GetPower(Act.CC) / 100;
		Act.CC.ModCurrency(-num2);
		if (!num)
		{
			Act.CC.PlaySound("whip");
		}
		Act.CC.PlaySound("money_dump");
		Act.CC.LookAt(Act.TP);
		if (num)
		{
			Act.CC.Say("throw", Act.CC, thing.GetName(NameStyle.Full));
			Chara chara = Act.CC.host ?? Act.CC;
			Effect.Get<EffectIRenderer>("throw").Play(chara, thing, chara.pos, Act.TP, 0.2f);
			thing.renderer.SetFirst(first: false, chara.renderer.position);
		}
		else
		{
			Act.CC.renderer.PlayAnime(AnimeID.Attack, Act.TC);
			Act.CC.Say("use_whip", Act.CC, Act.TC, thing.Name);
		}
		Act.TC.PlayAnime(AnimeID.Shiver);
		Act.TC.DamageHP(dmg, 926, 100, AttackSource.Throw, Act.CC);
		Act.TC.PlayEffect("hit_blunt").SetScale(1f);
		Act.CC.PlaySound("hit_blunt");
		if (Act.TC.isChara && Act.TC.ExistsOnMap)
		{
			Act.TC.Chara.OnInsulted();
			MoneyEffect(Act.CC, Act.TC.Chara, GetPower(Act.CC), 1);
		}
		return true;
	}

	public static void MoneyEffect(Chara owner, Chara c, int power, int chance = 5)
	{
		if (c != owner && EClass.rnd(chance) == 0)
		{
			if (EClass.rnd(2) == 0)
			{
				c.AddCondition<ConConfuse>(power);
			}
			if (EClass.rnd(2) == 0)
			{
				c.AddCondition<ConDim>(power);
			}
			if (EClass.rnd(4) == 0)
			{
				c.AddCondition<ConFear>(power);
			}
			if (EClass.rnd(1) == 0)
			{
				c.AddCondition<ConEuphoric>(power);
			}
		}
	}
}
