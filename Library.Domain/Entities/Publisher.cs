using System.Collections.Generic;

namespace Library.Domain.Entities
{
    public class Publisher
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}