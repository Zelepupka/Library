﻿using System;

namespace Library.BLL.DTO
{
    public class BookDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}