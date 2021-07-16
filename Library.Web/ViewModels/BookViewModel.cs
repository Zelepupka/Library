using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Web.ViewModels
{
    public class BookViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
