public class Zone_Town : Zone_Civilized
{
	public override bool IsTown => true;

	public override bool IsExplorable => false;

	public override bool CanDigUnderground => false;

	public override bool CanSpawnAdv => base.lv == 0;

	public override bool AllowCriminal => false;

	public override void OnRegenerate()
	{
		if (EClass.rnd(5) == 0)
		{
			Chara chara = CharaGen.Create("mad_rich");
			chara.isSubsetCard = true;
			EClass._zone.AddCard(chara, GetSpawnPos(chara));
		}
	}
}
