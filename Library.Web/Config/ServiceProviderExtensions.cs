using AutoMapper;
using Library.BLL.Interfaces;
using Library.BLL.Services;
using Library.DAL.Repositories;
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Web.AutoMapperProfiles;
using Microsoft.Extensions.DependencyInjection;
namespace Library.Web.Config
{
    public static class ServiceProviderExtensions
    {
        public static void ConfigDependencies(this IServiceCollection services)
        {
            //services.AddScoped<IUnitOfWork,EFUnitOfWork>();
            //services.AddScoped<IGenreService, GenreService>();
            //services.AddScoped<IPublisherService,PublisherService>();
            //services.AddScoped<IAuthorService,AuthorService>();
            //services.AddScoped<IBookService,BookService>();
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
            services.AddScoped<GenreService>();
            services.AddScoped<PublisherService>();
            services.AddScoped<AuthorService>();
            services.AddScoped<BookService>();
        }


    }
}