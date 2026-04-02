public class TraitMerchantTravel2 : TraitMerchantTravel
{
	public override CurrencyType CurrencyType => CurrencyType.Money2;

	public override ShopType ShopType => ShopType.TravelMerchant2;

	public override int CostRerollShop => 0;

	public override int RestockDay => -1;
}
