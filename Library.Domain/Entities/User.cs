using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Library.Domain.Entities
{
    public class User : IdentityUser
    {
        public ICollection<Comment> Comments;
        public ICollection<Book> Books;
    }

}