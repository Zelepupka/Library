using AFS.Web.Models.DataTable;
using AutoMapper;
using Library.BLL.Filters;


namespace Library.Web.AutoMapperProfiles
{
    public class FiltersProfile : Profile
    {
        public FiltersProfile()
        {
            CreateMap<DataTableApplicationAjaxPostViewModel, GenreFilterDto>();
            CreateMap<GenreFilterDto, DataTableApplicationAjaxPostViewModel>();

            CreateMap<DataTableApplicationAjaxPostViewModel, PublisherFilterDto>();
            CreateMap<PublisherFilterDto, DataTableApplicationAjaxPostViewModel>();

            CreateMap<DataTableApplicationAjaxPostViewModel, AuthorFilterDto>();
            CreateMap<AuthorFilterDto, DataTableApplicationAjaxPostViewModel>();

            CreateMap<DataTableApplicationAjaxPostViewModel, BookFilterDto>();
            CreateMap<BookFilterDto, DataTableApplicationAjaxPostViewModel>();
        }
    }
}
