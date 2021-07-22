using System.Collections.Generic;

namespace AFS.Domain.Models.Dtos.Pageable {
    public class PageableBaseResponseDto<T> {
        public int TotalItems { get; set; }
        public List<T> Items { get; set; }
    }
}