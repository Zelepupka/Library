using System.Data.Entity;
using WindowsService.Entities;

namespace WindowsService.DbContext
{
    public class ServiceDbContext : System.Data.Entity.DbContext
    {
        public ServiceDbContext() : base(@"Data Source=DESKTOP-BPC41OM\SQLEXPRESS;Initial Catalog=WindowsService;Integrated Security=True")
        {
        }
        
        public DbSet<Book> Books { get; set; }
    }
}