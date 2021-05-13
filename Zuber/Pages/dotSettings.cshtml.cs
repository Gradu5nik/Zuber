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
    public class dotSettingsModel : PageModel
    {
        public SingletonUser User;
        public IDotService dService;

        public IUserService uService;
        public IRideService rService;
        [BindProperty]
        public Dot userDot{get;set;}
        [BindProperty]
        public Ride userRide { get; set; }

        public dotSettingsModel(SingletonUser s, IDotService d, IRideService r,IUserService u) { 
            User = s;
            dService = d;
            rService = r;
            uService = u;
        }
        public IActionResult OnGet()
        {
            if (!User.SignedIn)
            {
                return RedirectToPage("Login");
            }
            
            if (!User.User.DotId.HasValue)
            {
                userDot = new Dot();
                //userDot.ZuberUserID = User.User.Id;
            }
            else { userDot = dService.GetDotById(User.User.DotId.Value); }
            if (!User.User.RideId.HasValue)
            {
                userRide = new Ride();  
            }
            else { userRide = rService.GetRideById(User.User.RideId.Value); }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            userDot.ZuberUserID = User.User.Id;
            if (User.User.DotId.HasValue)
            {
                dService.UpdateDot(userDot);
            }
            else 
            { 
                dService.AddDot(userDot); 
                Dot d = dService.GetDotByUserId(User.User.Id);
                uService.GiveUserDot(User.User, d.Id);
                User.Login(uService.GetZuberUserById(User.User.Id));
            }
            
            return RedirectToPage("Index");
        }

    }
}