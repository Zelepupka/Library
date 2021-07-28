using Microsoft.AspNetCore.Mvc;
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
using Microsoft.AspNetCore.Authorization;

namespace Library.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PublishersController : CrudController<PublisherViewModel,PublisherDTO,Publisher,PublisherFilterDto,Guid,DataTablePublisherViewModel>
    {
        public PublishersController(PublisherService service,IMapper mapper) : base(service,mapper) {}
        public IActionResult Index()
        {
            return View();
        }
    }
}
