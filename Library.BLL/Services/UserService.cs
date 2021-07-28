using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Library.BLL.DTO;
using Library.BLL.Filters;
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Library.BLL.Services
{
    public class UserService : BaseService<UserDTO, User, UserFilterDto, string>
    {
        public UserService(IUnitOfWork uow, IMapper mapper, UserManager<User> userManager) : base(uow, mapper)
        {
            _userManager = userManager;
        }

        private readonly UserManager<User> _userManager;

        public override async Task<QueryDTO<UserDTO>> SearchFor(UserFilterDto filters)
        {
            var result = new QueryDTO<UserDTO>();
            var query = _userManager.Users;
            if (filters == null)
            {
                result.Count = query.Count();

                result.Items = _mapper.Map<ICollection<UserDTO>>(query.ToList());

                return result;
            }

            query = GetFiltered(query, filters);
            query = GetInclude(query);

            if (filters.Skip >= 0)
                query = query.Skip(filters.Start);
            if (filters.Length >= 0)
                query = query.Take(filters.Length);

            result.Count = query.Count();

            result.Items = new List<UserDTO>();
            foreach (var user in query.ToList())
            {
                var userDto = new UserDTO()
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Email = user.Email,
                    Roles = await _userManager.GetRolesAsync(user)
                };
                result.Items.Add(userDto);
            }

            return result;
        }

        public async Task<bool> IsInRoleAsync(UserDTO userDto, string role)
        {
            if (userDto == null)
                throw new ArgumentNullException(nameof(userDto));

            var user = await _userManager.FindByIdAsync(userDto.Id);
            return await _userManager.IsInRoleAsync(user, role);
        }

        public async Task AddUserToRoleAsync(UserDTO userDto, string roleName)
        {
            if (userDto == null)
                throw new ArgumentNullException(nameof(userDto));

            var user = await _userManager.FindByIdAsync(userDto.Id);
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task RemoveFromRoleAsync(UserDTO userDto, string roleName)
        {
            if (userDto == null)
                throw new ArgumentNullException(nameof(userDto));

            var user = await _userManager.FindByIdAsync(userDto.Id);
            await _userManager.RemoveFromRoleAsync(user, roleName);
        }
    }
}