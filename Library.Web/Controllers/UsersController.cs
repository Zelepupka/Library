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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Library.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : CrudController<UserViewModel,UserDTO,User,UserFilterDto,string,DataTableUserPostViewModel>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserService _userService;
        private readonly IMapper _mapper;
        public UsersController(RoleManager<IdentityRole> roleManager, UserService userService, IMapper mapper) : base(userService,mapper)
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

            var roles = new List<RoleViewModel>();

            var userDto = _mapper.Map<UserDTO>(user);
             
            foreach (var role in _roleManager.Roles.ToList())
            {
                var userRolesViewModel = new RoleViewModel
                {
                    Id = role.Id,
                    Name = role.Name
                };
                if (await _userService.IsInRoleAsync(userDto, role.Name))
                {
                    userRolesViewModel.IsSelected = true;
                }
                else
                {
                    userRolesViewModel.IsSelected = false;
                }
                roles.Add(userRolesViewModel);
            }

            user.Roles = roles;

            return PartialView("Partials/Edit", user);
        }

        [HttpPost]
        public override async Task Edit(UserViewModel user)
        {
            var userDto = _mapper.Map<UserDTO>(user);
            foreach (var role in user.Roles)
            {
                if (role.IsSelected && !await _userService.IsInRoleAsync(userDto, role.Name))
                {
                    await _userService.AddUserToRoleAsync(userDto,role.Name);
                }
                else if (!role.IsSelected && await _userService.IsInRoleAsync(userDto, role.Name))
                {
                    await _userService.RemoveFromRoleAsync(userDto,role.Name);
                }
            }
            await _userService.UpdateAsync(userDto);
        }
    }
}
