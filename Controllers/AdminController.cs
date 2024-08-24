using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SA_Online_Mart.Data;
using SA_Online_Mart.Models;

namespace SA_Online_Mart.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public AdminController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if(currentUser != null && await _userManager.IsInRoleAsync(currentUser, "admin"))
            {
                return View(currentUser);
            }
            
            return RedirectToAction("Index", "Home");
        }
    }
}
