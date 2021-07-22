using AFS.Web.Models.DataTable;

namespace Library.BLL.Filters
{
    public class AuthorFilterDto : BaseFilterDto
    {
        public DataTableSearchViewModel Search { get; set; }
    }
}