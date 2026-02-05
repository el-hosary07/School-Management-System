using School_Management_System.Data;
using School_Management_System.Models;
using School_Management_System.Utilites;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using School_Management_System.Utilites.DBSeeder;

namespace School_Management_System.Utilites.DBSeeder
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DbInitializer> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public DbInitializer(ApplicationDbContext context, ILogger<DbInitializer> logger, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _logger = logger;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public void Initialize()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Any())
                {
                    _context.Database.Migrate();
                }

                if (!_roleManager.Roles.Any())
                {
                    _roleManager.CreateAsync(new IdentityRole(SD.SUPER_ADMIN_ROLE)).GetAwaiter().GetResult();
                    _roleManager.CreateAsync(new IdentityRole(SD.TEACHER_ROLE)).GetAwaiter().GetResult();
                    _roleManager.CreateAsync(new IdentityRole(SD.USER_ROLE)).GetAwaiter().GetResult();

                    _userManager.CreateAsync(new ApplicationUser
                    {
                        Email = "superadmin@eraasoft.com",
                        UserName = "SuperAdmin",
                         EmailConfirmed = true,
                    }, "Admin123#").GetAwaiter().GetResult();

                    var user = _userManager.FindByNameAsync("SuperAdmin").GetAwaiter().GetResult();
                    _userManager.AddToRoleAsync(user!, SD.SUPER_ADMIN_ROLE).GetAwaiter().GetResult();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error {ex.Message}");
            }
        }

    }
}
