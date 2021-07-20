using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Web.ViewModels
{
    public class GenreViewModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}