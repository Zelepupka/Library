using System;
using System.Collections.Generic;
using Library.Domain.AbstractClasses;

namespace Library.Domain.Entities
{
    public class Author : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}