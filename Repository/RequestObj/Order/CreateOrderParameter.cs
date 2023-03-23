namespace Repository.RequestObj.Order
{
    public class CreateOrderParameter
    {
        public int? UserId { get; set; }
        public DateTime? DeliveryTime { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? Address { get; set; }

    }
}
