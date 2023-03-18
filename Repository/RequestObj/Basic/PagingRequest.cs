namespace Repository.RequestObj.Basic
{
    public class PagingRequest
    {
        public int PageCurrent { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
