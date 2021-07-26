using AFS.Web.Models.DataTable;
using AutoMapper;
using Library.BLL.Filters;


namespace Library.Web.AutoMapperProfiles
{
    public class FiltersProfile : Profile
    {
        public FiltersProfile()
        {
            CreateMap<DataTableBookAjaxPostViewModel, GenreFilterDto>();
            CreateMap<GenreFilterDto, DataTableBookAjaxPostViewModel>();

            CreateMap<DataTableBookAjaxPostViewModel, PublisherFilterDto>();
            CreateMap<PublisherFilterDto, DataTableBookAjaxPostViewModel>();

            CreateMap<DataTableBookAjaxPostViewModel, AuthorFilterDto>();
            CreateMap<AuthorFilterDto, DataTableBookAjaxPostViewModel>();

            CreateMap<DataTableBookAjaxPostViewModel, BookFilterDto>();
            CreateMap<BookFilterDto, DataTableBookAjaxPostViewModel>();
        }
    }
}
