using System;
using Library.Domain.AbstractClasses;

namespace Library.Domain.Entities
{
    public class Rating : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public int Value { get; set; }
        public virtual User User { get; set; }
        public virtual string UserId { get; set; }
        public virtual Book Book { get; set; }
        public virtual Guid BookId { get; set; }
    }
}