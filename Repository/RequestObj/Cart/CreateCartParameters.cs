using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RequestObj.Cart
{
    public class CreateCartParameters
    {
        [Required]
        public int? UserId { get; set; }
    }
}
