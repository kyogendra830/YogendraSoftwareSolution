using Microsoft.EntityFrameworkCore;
using YogendraSoftwareSolution.Model.Models;

namespace YogendraSoftwareSolution.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options)
            :base(options)
        {

        }
        public DbSet<RegistrationModel> Tbl_Registration { get; set; }
    }
}
