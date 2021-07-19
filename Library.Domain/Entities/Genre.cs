using System;
using System.Collections;
using System.Collections.Generic;
using Library.Domain.AbstractClasses;

namespace Library.Domain.Entities
{
   
    public class Genre : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}