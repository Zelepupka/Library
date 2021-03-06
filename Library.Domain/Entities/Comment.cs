using System;
using Library.Domain.AbstractClasses;

namespace Library.Domain.Entities
{
    public class Comment : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public virtual Book Book { get; set; }
        public virtual Guid BookId { get; set; }
        public virtual User User { get; set; }
        public virtual string UserId { get; set; }
    }
}