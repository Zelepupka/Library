using System;
using AFS.Web.Models.DataTable;

namespace Library.BLL.Filters
{
    public class BookFilterDto : BaseFilterDto
    {
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid PublisherId { get; set; }

    }
}