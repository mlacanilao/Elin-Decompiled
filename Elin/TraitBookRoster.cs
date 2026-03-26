public class TraitBookRoster : TraitItem
{
	public override string LangUse => "actRead";

	public override bool IsHomeItem => true;

	public override bool OnUse(Chara c)
	{
		if (!EClass._zone.IsPCFaction)
		{
			Msg.SayNothingHappen();
			return false;
		}
		LayerPeople.CreateParty();
		return false;
	}
}
