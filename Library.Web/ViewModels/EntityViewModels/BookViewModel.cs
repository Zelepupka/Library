using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Domain.Entities;

namespace Library.Web.ViewModels
{
    public class BookViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime PublicationDate { get; set; }
        public Guid PublisherId { get; set; }
        public string PublisherName { get; set; }
    }
}
