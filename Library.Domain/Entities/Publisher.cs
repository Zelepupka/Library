using System;
using System.Collections.Generic;
using Library.Domain.AbstractClasses;

namespace Library.Domain.Entities
{
    public class Publisher : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}