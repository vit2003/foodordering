namespace Repository.RequestObj.Order
{
    public class UpdateOrderParameter
    {
        public DateTime? DeliveryTime { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? Address { get; set; }
    }
}
