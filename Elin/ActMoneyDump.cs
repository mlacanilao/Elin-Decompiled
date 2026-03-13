using System.Collections.Generic;
using UnityEngine;

public class ActMoneyDump : Ability
{
	public override bool CanPressRepeat => true;

	public override bool CanPerform()
	{
		return Act.CC.GetCurrency() >= 100;
	}

	public override bool Perform()
	{
		List<Point> points = new List<Point>();
		Act.TP.ForeachNeighbor(delegate(Point _p)
		{
			if (!_p.Equals(Act.TP) && EClass.rnd(3) != 0 && !_p.IsBlocked)
			{
				points.Add(_p.Copy());
			}
		});
		Act.CC.Talk("insane");
		Act.CC.PlaySound("money_dump");
		foreach (Point item in points)
		{
			int num = EClass.rndHalf(Mathf.Clamp(Act.CC.GetCurrency() / 50, 1, 20000000)) + EClass.rndHalf(10);
			if (Act.CC.GetCurrency() >= num)
			{
				Thing t = ThingGen.Create("money").SetNum(num);
				Act.CC.ModCurrency(-num * 3 / 2);
				ActThrow.Throw(Act.CC, item, null, t, ThrowMethod.Reward);
			}
		}
		Act.TP.TalkWitnesses(Act.CC, new string[4] { "rumor_good", "callGuards", "disgust", "wow" }.RandomItem(), 4, WitnessType.everyone, (Chara c) => true);
		foreach (Chara item2 in Act.TP.ListWitnesses(Act.CC, 4, WitnessType.everyone))
		{
			ActMoneySlap.MoneyEffect(Act.CC, item2, GetPower(Act.CC));
		}
		return true;
	}
}
