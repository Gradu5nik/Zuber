using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zuber.Models;
using Zuber.Services.EFServices;
using Zuber.Services.Interfaces;

namespace Zuber.Pages
{
    public class ProfileModel : PageModel
    {
        IUserService service;
        public SingletonUser User;
        [BindProperty]
        public ZuberUser editableUser { get; set; }
        public ProfileModel(SingletonUser s,IUserService i)
        {
            User = s;
            service = i;
            
        }
        public IActionResult OnGet()
        {
            if (User.SignedIn)
            {
                editableUser = User.User;
                return Page();
            }
            else
            {
                return RedirectToPage("Login");
            }
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            service.UpdateZuberUser(editableUser);
            User.Login(editableUser);
            return RedirectToPage("Index");
        }
    }
}
