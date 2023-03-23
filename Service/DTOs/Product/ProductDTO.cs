namespace Service.DTOs.Product
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductImageUrl { get; set; }
        public string? ProductDescription { get; set; }
        public string? CategoryName { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
    }

    public class ProductInListDTO
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductImageUrl { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
    }
}
