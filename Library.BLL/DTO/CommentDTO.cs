using System;
using Library.BLL.Interfaces;

namespace Library.BLL.DTO
{
    public class CommentDTO : IBaseDto<Guid>
    { 
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}