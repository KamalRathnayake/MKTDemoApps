using Microsoft.EntityFrameworkCore;
using UsersApp.Controllers;

namespace CountriesApp.Data
{
    public class UsersContext: DbContext
    {
        public UsersContext(DbContextOptions options):base (options)
        {

        }
        public DbSet<User> Users { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=tcp:fogroup1.database.windows.net,1433;Initial Catalog=mydatabase;Persist Security Info=False;User ID=kamal;Password=Hello@12345#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
