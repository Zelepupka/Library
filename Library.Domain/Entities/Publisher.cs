using System;
using System.Collections.Generic;

namespace Library.Domain.Entities
{
    public class Publisher
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}