using AFS.Web.Models.DataTable;

namespace Library.BLL.Filters
{
    public class BookFilterDto : BaseFilterDto
    {
        public DataTableSearchViewModel Search { get; set; }
    }
}