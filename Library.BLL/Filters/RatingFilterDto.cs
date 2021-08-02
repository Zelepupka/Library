using System;

namespace Library.BLL.Filters
{
    public class RatingFilterDto : BaseFilterDto
    {
        public Guid BookId { get; set; }
        public string UserId { get; set; }
    }
}