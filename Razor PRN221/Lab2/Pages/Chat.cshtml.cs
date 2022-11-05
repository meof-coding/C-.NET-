using Lab2.Data;
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
        public List<IdentityUser> _users { get; set; }
       
        public void OnGet()
        {
            //get all user except this login user 
            _users = _applicationDbContext.Users.Where(u => u.UserName != User.Identity.Name).ToList();
        }
    }
}
