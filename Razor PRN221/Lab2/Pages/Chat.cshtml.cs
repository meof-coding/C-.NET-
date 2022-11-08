using Lab2.Data;
using Lab2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Policy;

namespace Lab2.Pages
{
    [Authorize]
    public class ChatModel : PageModel
    {
        private ApplicationDbContext _applicationDbContext;

        public ChatModel(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [BindProperty]
        public List<ApplicationUser> _users { get; set; }
        public ApplicationUser CurrentUser { get; set; }
        public void OnGet()
        {
            CurrentUser = _applicationDbContext.Users.FirstOrDefault(u => u.UserName.Equals(User.Identity.Name));
            //get all user except this login user 
            _users = _applicationDbContext.Users.Where(u => u.UserName.Equals(User.Identity.Name)==false).ToList();
        }
    }
}
