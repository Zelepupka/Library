using Library.Domain.Entities;

namespace Library.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Author> Authors { get; }
        IRepository<Book> Books { get; }
        IRepository<Comment> Comments { get; }
        IRepository<Genre> Genres { get; }
        IRepository<Publisher> Publishers { get; }
    }
}