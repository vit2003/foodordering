using Repository.RequestObj.Basic;

namespace Repository.RequestObj.Product
{
    public class GetProductParam : PagingRequest
    {
        public int CategoryId { get; set; }
    }
}
