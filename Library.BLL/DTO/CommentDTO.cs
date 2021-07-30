using System;
using Library.BLL.Interfaces;
using Library.Domain.Entities;

namespace Library.BLL.DTO
{
    public class CommentDTO : IBaseDto<Guid>
    { 
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
        public Guid bookId { get; set; }
    }
}