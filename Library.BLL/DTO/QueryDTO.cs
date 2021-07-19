using System.Collections.Generic;

namespace Library.BLL.DTO
{
    public class QueryDTO<TDto> 
        where TDto : class
    {
        public IEnumerable<TDto> Items { get; set; }
        public int Count { get; set; }
    }
}