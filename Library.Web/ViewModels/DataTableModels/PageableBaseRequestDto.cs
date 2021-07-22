namespace AFS.Domain.Models.Dtos.Pageable {
    public class PageableBaseRequestDto {
        public int Skip { get; set; }
        public int Take { get; set; }
        public string OrderBy { get; set; }
        public string ThenBy { get; set; }
        public bool DescOrder { get; set; }
        public string SearchText { get; set; }
    }
}