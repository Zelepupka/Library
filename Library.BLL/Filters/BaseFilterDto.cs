namespace Library.BLL.Filters
{
    public class BaseFilterDto
    {
        public int Skip { get; set; }
        public int Length { get; set; }
        public int Start { get; set; }
        public string OrderBy { get; set; }
    }
}