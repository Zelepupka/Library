using System;
using AFS.Domain.Models.Dtos.Pageable;

namespace AFS.Web.Models.DataTable {
    public class DataTableBookAjaxPostViewModel : DataTableBaseAjaxPostViewModel<PageableApplicationRequestDto>
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid PublisherId { get; set; }
    }
}