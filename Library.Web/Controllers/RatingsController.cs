using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Hangfire;
using Library.BLL.DTO;
using Library.BLL.Filters;
using Library.BLL.Services;
using Library.Domain.Entities;
using Library.Web.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Library.Web.Controllers
{
    public class RatingsController : Controller
    {
        private readonly RatingService _ratingsService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
  

        public RatingsController(UserManager<User> userManager,IMapper mapper,RatingService ratingsService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _ratingsService = ratingsService;
        }

        public async Task Add(RatingViewModel viewModel)
        {
            var filter = new RatingFilterDto();
            ClaimsPrincipal currentUser = User;
            var user = await _userManager.GetUserAsync(currentUser);
            var dto = _mapper.Map<RatingDTO>(viewModel);
            dto.UserId = user.Id;
            filter.BookId = viewModel.BookId;
            filter.UserId = user.Id;
            var rating = await _ratingsService.SearchFor(filter);
            if (rating.Count == 0)
            {
                await _ratingsService.AddAsync(dto);
            }
            else
            {
                var needRating = rating.Items.FirstOrDefault();
                needRating.Value = viewModel.Value;
                await _ratingsService.UpdateAsync(needRating);
            }

        }

        
    }
}
