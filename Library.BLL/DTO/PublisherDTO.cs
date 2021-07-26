using System;
using Library.BLL.Interfaces;

namespace Library.BLL.DTO
{
    public class PublisherDTO : IBaseDto<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}