public class Zone_LittleGarden : Zone_Civilized
{
	public override ZoneTransition.EnterState RegionEnterState => ZoneTransition.EnterState.Right;

	public override void OnRegenerate()
	{
		base.OnRegenerate();
		base.development = (EClass.player.little_saved * 2 - EClass.player.little_dead * 3) * 10;
	}

	public override void OnActivate()
	{
		base.OnActivate();
		int num = 0;
		foreach (Chara chara in EClass._map.charas)
		{
			if (chara.id == "littleOne" && !chara.IsPCFaction)
			{
				num++;
			}
		}
		if (num > 0)
		{
			Msg.Say("num_little", num.ToString() ?? "");
		}
	}
}
