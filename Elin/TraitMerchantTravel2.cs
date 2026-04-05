public class TraitMerchantTravel2 : TraitMerchantTravel
{
	public override CurrencyType CurrencyType => CurrencyType.Money2;

	public override ShopType ShopType
	{
		get
		{
			if (!base.ShouldOpenShop)
			{
				return ShopType.None;
			}
			return ShopType.TravelMerchant2;
		}
	}
}
