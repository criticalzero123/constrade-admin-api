namespace ConstradeApi_Admin.VerificationModel.MProductPrices
{
    public class ProductPricesModel
    {
        public int ProductPricesId { get; set; }
        public int AddedBy { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Platform { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string OriginUrl { get; set; } = string.Empty;
        public string ShopName { get; set; } = string.Empty;
    }
}
