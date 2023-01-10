using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Data
{
    public class BooksStoreContext : DbContext

    {
        public BooksStoreContext(DbContextOptions<BooksStoreContext> options)
            : base(options)
        {

        }

        public DbSet<Books> Books { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;DataBase=BookStoreAPI;Integrated Security=true");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
