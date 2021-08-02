using System;
using Library.BLL.Interfaces;
using Library.Domain.Entities;

namespace Library.BLL.DTO
{
    public class RatingDTO: IBaseDto<Guid>
    {
        public Guid Id { get; set; }
        public int Value { get; set; }
        public string UserId { get; set; } 
        public Guid BookId { get; set; }
    }
}