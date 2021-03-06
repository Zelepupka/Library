using System;
using System.Collections;
using System.Collections.Generic;
using Library.Domain.AbstractClasses;

namespace Library.Domain.Entities
{
    public class Book : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int AvgRating { get; set; }
        public DateTime PublicationDate { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual Guid PublisherId { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}