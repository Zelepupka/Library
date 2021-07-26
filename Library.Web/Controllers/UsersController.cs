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
using Library.Web.ViewModels.EntityViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Library.Web.Controllers
{
    public class UsersController : CrudController<UserViewModel,UserDTO,User,UserFilterDto,string,DataTableUserPostViewModel>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserService _userService;
        private readonly IMapper _mapper;
        public UsersController(RoleManager<IdentityRole> roleManager,UserService userService,IMapper mapper) : base(userService,mapper)
        {
            _roleManager = roleManager;
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public override async Task<IActionResult> Edit(string id)
        {
            var user = _mapper.Map<UserViewModel>(await _userService.GetAsync(u => u.Id == id)); 
            ViewBag.Roles = await _roleManager.Roles.ToListAsync();
            return PartialView("Partials/Edit",user);
        }
    }
}
