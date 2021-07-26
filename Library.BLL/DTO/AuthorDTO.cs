using System;
using Library.BLL.Interfaces;

namespace Library.BLL.DTO
{
    public class AuthorDTO : IBaseDto<Guid>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
    }
}