using System;
using System.Collections.Generic;
using Library.BLL.Interfaces;
using Library.Domain.Entities;

namespace Library.BLL.DTO
{
    public class BookDTO : IBaseDto<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int AvgRating { get; set; }
        public DateTime PublicationDate { get; set; }
        public string PublisherName { get; set; }
        public Guid PublisherId { get; set; }

    }
}