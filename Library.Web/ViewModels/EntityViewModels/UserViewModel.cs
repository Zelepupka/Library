﻿using System;
using System.Collections.Generic;

namespace Library.Web.ViewModels.EntityViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}