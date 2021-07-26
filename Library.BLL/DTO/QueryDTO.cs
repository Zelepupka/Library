using System.Collections.Generic;

namespace Library.BLL.DTO
{
    public class QueryDTO<TDto> 
        where TDto : class
    {
        public ICollection<TDto> Items { get; set; }
        public int Count { get; set; }
    }
}