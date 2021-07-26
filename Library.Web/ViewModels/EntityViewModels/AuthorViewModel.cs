using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Web.ViewModels
{
    public class AuthorViewModel
    { 
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
    }
}
