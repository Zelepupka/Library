using Library.DAL.Context;
using Library.Domain.Entities;
using Library.Domain.Interfaces;

namespace Library.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext db;
        private Repository<Author> authorRepository;
        private Repository<Book> bookRepository;
        private Repository<Comment> commentRepository;
        private Repository<Genre> genreRepository;
        private Repository<Publisher> publisherRepository;
        public IRepository<Author> Authors
        {
            get
            {
                if (authorRepository == null)
                {
                    authorRepository = new Repository<Author>(db);
                }
                return authorRepository;
            }
        }

        public IRepository<Book> Books
        {
            get
            {
                if (bookRepository == null)
                {
                    bookRepository = new Repository<Book>(db);
                }
                return bookRepository;
            }
        }
        public IRepository<Comment> Comments {
            get
            {
                if (commentRepository == null)
                {
                    commentRepository = new Repository<Comment>(db);
                }
                return commentRepository;
            }
        }
        public IRepository<Genre> Genres {
            get
            {
                if (genreRepository == null)
                {
                    genreRepository = new Repository<Genre>(db);
                }
                return genreRepository;
            }
        }
        public IRepository<Publisher> Publishers {
            get
            {
                if (publisherRepository == null)
                {
                    publisherRepository = new Repository<Publisher>(db);
                }
                return publisherRepository;
            }
        }
    }
}