namespace Service.DTOs.BasicRes
{
    public class ListResponse<T> where T : class
    {
        public int Count { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public List<T> Data { get; set; }
    }
}
