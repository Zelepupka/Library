using System;
using System.ComponentModel.DataAnnotations;

namespace WindowsService.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid SourceId { get; set; }
    }
}