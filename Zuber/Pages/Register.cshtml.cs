using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zuber.Models;
using Zuber.Services.EFServices;
using Zuber.Services.Interfaces;

namespace Zuber.Pages
{
    public class RegisterModel : PageModel
    {
        public class InputModel
        {
            [Required]
            public string Name { get; set; }
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }
            
            [Required]
            [Phone]
            public string PhoneNo { get; set; }
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }
        IUserService service;
        SingletonUser User;
        [BindProperty]
        public InputModel newUser { get; set; }
        public RegisterModel(IUserService i, SingletonUser u)
        {
            service = i;
            User = u;
        }
        public void OnGet()
        {
            
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            ZuberUser NewToDatabase = new ZuberUser();
            NewToDatabase.Name = newUser.Name;
            NewToDatabase.Email = newUser.Email;
            NewToDatabase.PhoneNo = newUser.PhoneNo;
            NewToDatabase.Password = newUser.Password;
            service.AddZuberUser(NewToDatabase);
            User.Login(service.GetZuberUser(NewToDatabase.Email));
            return RedirectToPage("Index");
        }
    }
}