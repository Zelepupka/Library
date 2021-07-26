﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFS.Web.Models.DataTable;
using AutoMapper;
using Library.BLL.DTO;
using Library.BLL.Filters;
using Library.BLL.Services;
using Library.Domain.Entities;
using Library.Web.ViewModels;

namespace Library.Web.Controllers
{
    public class PublishersController : CrudController<PublisherViewModel,PublisherDTO,Publisher,PublisherFilterDto,Guid,DataTableBookAjaxPostViewModel>
    {
        public PublishersController(PublisherService service,IMapper mapper) : base(service,mapper) {}
        public IActionResult Index()
        {
            return View();
        }
    }
}
