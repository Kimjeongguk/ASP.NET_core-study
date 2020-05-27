using ASP_Study.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASP_Study.Data
{
    public class ASPStudyContext : IdentityDbContext<ApplicationUser>
    {
        public ASPStudyContext(DbContextOptions<ASPStudyContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySql("Server = localhost; Database = aspstudy; Uid = sa; Pwd = 1234;");
        //}
    }
}
