using AFS.Web.Models.DataTable;

namespace Library.BLL.Filters
{
    public class BaseFilterDto
    {
        public int Draw { get; set; }
        public int Skip { get; set; }
        public int Length { get; set; }
        public int Start { get; set; }
        public string OrderBy { get; set; }
        public DataTableSearchViewModel Search { get; set; }
    }
}