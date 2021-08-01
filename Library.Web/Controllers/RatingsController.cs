using System.Threading.Tasks;
using AutoMapper;
using Library.BLL.DTO;
using Library.BLL.Services;
using Library.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace Library.Web.Controllers
{
    public class RatingsController : Controller
    {
        private readonly RatingsService _ratingsService;
        private readonly IMapper _mapper;
        public RatingsController(IMapper mapper,RatingsService ratingsService)
        {
            _mapper = mapper;
            _ratingsService = ratingsService;
        }
        public async Task Add(RatingViewModel viewModel)
        {
            var dto = _mapper.Map<RatingDTO>(viewModel);
            await _ratingsService.AddAsync(dto);
        }
    }
}
