using System.Collections.Generic;

namespace Library.Domain.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}