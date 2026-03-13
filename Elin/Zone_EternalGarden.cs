public class Zone_EternalGarden : Zone_Civilized
{
	public override void OnActivate()
	{
		base.OnActivate();
		if (EClass._map.version.IsBelow(0, 23, 226))
		{
			SetBGM(121, refresh: false);
		}
		int num = 0;
		foreach (Chara chara in EClass._map.charas)
		{
			if (chara.id == "cat_silver" && !chara.IsPCFaction)
			{
				num++;
			}
		}
		if (num > 0)
		{
			Msg.Say("num_silvercat", num.ToString() ?? "");
		}
	}
}
