using System;
using Library.Domain.Entities;
using Library.Web.ViewModels.EntityViewModels;

namespace Library.Web.ViewModels
{
    public class CommentViewModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public CommentUserViewModel User { get; set; }
        public Guid BookId { get; set; }
    }
}