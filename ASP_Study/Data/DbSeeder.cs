using ASP_Study.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Study.Data
{
    public class DbSeeder
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public DbSeeder(UserManager<ApplicationUser> userManager,
                        RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ASPStudyContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ASPStudyContext>>()))
            {
                // Look for any movies.
                if (context.Teachers.Any())
                {
                    return;   // DB has been seeded
                }

                context.Teachers.AddRange(
                    new Teacher() { Name = "아", Class = "a" },
                    new Teacher() { Name = "야", Class = "b" },
                    new Teacher() { Name = "어", Class = "c" },
                    new Teacher() { Name = "여", Class = "d" }
                );
                context.SaveChanges();
            }
            //var adminaccount = await _userManager.FindByNameAsync("master@gmail.com");
            //var adminrole = new IdentityRole("admin");
            //await _roleManager.CreateAsync(adminrole);
            //await _userManager.AddToRoleAsync(adminaccount, adminrole.Name);
        }
        //private ASPStudyContext _context;

        //public DbSeeder(ASPStudyContext context)
        //{
        //    _context = context;
        //}

        //public async Task SeedDatabase()
        //{
        //    if (!_context.Teachers.Any())
        //    {
        //        List<Teacher> teachers = new List<Teacher>()
        //        {
        //            new Teacher() { Name="A", Class="a"},
        //            new Teacher() { Name="B", Class="b"},
        //            new Teacher() { Name="C", Class="c"},
        //            new Teacher() { Name="D", Class="d"}
        //         };

        //        await _context.AddRangeAsync(teachers);
        //        await _context.SaveChangesAsync();
        //    }
        //}
    }
}
