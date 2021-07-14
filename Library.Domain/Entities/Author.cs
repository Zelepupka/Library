using System;
using System.Collections.Generic;

namespace Library.Domain.Entities
{
    public class Author
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}