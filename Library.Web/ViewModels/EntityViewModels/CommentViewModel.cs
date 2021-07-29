using System;
using Library.Domain.Entities;

namespace Library.Web.ViewModels
{
    public class CommentViewModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }

        public User User { get; set; }
    }
}