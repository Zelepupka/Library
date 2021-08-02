using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library.BLL.DTO;
using Library.BLL.Filters;
using Library.DAL.Context;
using Library.DAL.Repositories;
using Library.Domain.Entities;
using Library.Domain.Interfaces;

namespace Library.BLL.Services
{
    public class RatingsService : BaseService<RatingDTO,Rating,RatingFilterDto,Guid>
    {
        private readonly BookService _bookService;

        public RatingsService(BookService bookService, IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        { 
            _bookService = bookService;
        }
        protected override IQueryable<Rating> GetFiltered(IQueryable<Rating> query, RatingFilterDto filter)
        {
            if (filter.BookId!=Guid.Empty)
            {
                query = query.Where(r => r.BookId == filter.BookId);
            }

            if (!String.IsNullOrWhiteSpace(filter.UserId))
            {
                query = query.Where(r=>r.UserId==filter.UserId);
            }
            return query;
        }
        public async Task ComputeRating()
        {
            var filter = new RatingFilterDto();
            var books = await _bookService.SearchFor(null);
            foreach (var book in books.Items)
            {
                filter.BookId = book.Id;
                var ratings = await this.SearchFor(filter);
                var avgRating = ratings.Items.Average(r => r.Value);
                book.AvgRating = (int)avgRating;
                await _bookService.UpdateAsync(book);
            }
        }
    }
}