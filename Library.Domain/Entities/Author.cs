using System;
using System.Collections.Generic;
using Library.Domain.AbstractClasses;

namespace Library.Domain.Entities
{
    public class Author : BaseEntity<Guid>
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}