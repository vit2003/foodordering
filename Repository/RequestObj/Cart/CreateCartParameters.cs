using System.ComponentModel.DataAnnotations;

namespace Repository.RequestObj.Cart
{
    public class CreateCartParameters
    {
        [Required]
        public int? UserId { get; set; }
    }
}
