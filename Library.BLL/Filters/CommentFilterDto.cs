using System;

namespace Library.BLL.Filters
{
    public class CommentFilterDto : BaseFilterDto
    {
        public Guid BookId { get; set; }
    }
}