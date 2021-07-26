using System.Collections;
using System.Collections.Generic;
using Library.Domain.AbstractClasses;
using Microsoft.AspNetCore.Identity;

namespace Library.Domain.Entities
{
    public class User : IdentityUser, IBaseEntity<string>
    {
        public ICollection<Comment> Comments;
        public ICollection<Book> Books;
    }

}