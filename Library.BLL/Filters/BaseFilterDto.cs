namespace Library.BLL.Filters
{
    public class BaseFilterDto
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public string OrderBy { get; set; }
    }
}