using AFS.Domain.Models.Dtos.Pageable;
using System;
using System.Collections.Generic;

namespace AFS.Web.Models.DataTable {
    public class DataTableBaseAjaxPostViewModel<T>
           where T : PageableBaseRequestDto, new() {
        public int Draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public List<DataTableColumnViewModel> Columns { get; set; }
        public DataTableSearchViewModel Search { get; set; }
        public List<DataTableOrderViewModel> Order { get; set; }

        public virtual T ConvertToPageableRequestDto() {
            T request = new T {
                Skip = Start,
                Take = Length
            };

            if (Order != null) {
                request.OrderBy = Columns[Order[0].Column].Data;
                request.DescOrder = Order[0].Dir.ToLower() == "desc";
            }
            if (Search != null && !String.IsNullOrEmpty(Search.Value)) {
                request.SearchText = Search.Value.Trim();
            }

            return request;
        }
    }

    public class DataTableBaseAjaxPostViewModel : DataTableBaseAjaxPostViewModel<PageableBaseRequestDto> {
    }
}