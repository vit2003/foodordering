namespace Service.DTOs.Cart
{
    public class CartInListDTO
    {
        public int CartId { get; set; }
        public string? Total { get; set; }
        public List<ProductInCartList>? Products { get; set; }
    }

    public class ProductInCartList
    {
        public int? ProductId { get; set; }
        public string? Name { get; set; }
        public string? Price { get; set; }
        public int? Quantity { get; set; }
    }
}
