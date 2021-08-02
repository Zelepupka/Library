using System;

namespace Library.Web.ViewModels
{
    public class RatingViewModel
    {
        public Guid Id { get; set; }
        public int Value { get; set; }
        public Guid BookId { get; set; }
    }
}