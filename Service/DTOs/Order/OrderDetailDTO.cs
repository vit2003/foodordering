using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Order
{
    public class OrderDetailDTO
    {
        public int Id { get; set; } 
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Phone { get; set; }
        public DateTime? DeliveryTime { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? Address { get; set; }
    }
}
