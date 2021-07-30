using System.Collections;
using System.Collections.Generic;
using Library.Domain.AbstractClasses;
using Microsoft.AspNetCore.Identity;

namespace Library.Domain.Entities
{
    public class User : IdentityUser, IBaseEntity<string>
    {
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Book> Books { get; set; }
        public ICollection<Rating> Ratings { get; set; }

    }
}