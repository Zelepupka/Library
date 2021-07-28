using AFS.Web.Models.DataTable;
using AutoMapper;
using Library.BLL.Filters;


namespace Library.Web.AutoMapperProfiles
{
    public class FiltersProfile : Profile
    {
        public FiltersProfile()
        {
            CreateMap<DataTableGenreAjaxPostViewModel, GenreFilterDto>();
            CreateMap<GenreFilterDto, DataTableGenreAjaxPostViewModel>();

            CreateMap<DataTablePublisherViewModel, PublisherFilterDto>();
            CreateMap<PublisherFilterDto, DataTablePublisherViewModel>();

            CreateMap<DataTableAuthorAjaxPostViewModel, AuthorFilterDto>();
            CreateMap<AuthorFilterDto, DataTableAuthorAjaxPostViewModel>();

            CreateMap<DataTableBookAjaxPostViewModel, BookFilterDto>();
            CreateMap<BookFilterDto, DataTableBookAjaxPostViewModel>();

            CreateMap<DataTableUserPostViewModel, UserFilterDto>();
            CreateMap<UserFilterDto, DataTableUserPostViewModel>();
        }
    }
}
