using System;

namespace Library.Domain.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public virtual Book Book { get; set; }
        public virtual int BookId { get; set; }
        public virtual User User { get; set; }
        public virtual int UserId { get; set; }
    }
}