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
    public class GetProfileModel : PageModel
    {
        public IInviteService InviteService;
        public IRideService RideService;
        public IUserService service;
        public SingletonUser User;
        [BindProperty]
        public ZuberUser GetUser { get; set; }
        public GetProfileModel(SingletonUser s, IUserService i, IInviteService inviteService, IRideService rideService)
        {
            User = s;
            service = i;
            InviteService = inviteService;
            RideService = rideService;
        }
        public IActionResult OnGet(int id)
        {
            if (User.SignedIn)
            {
                GetUser = service.GetZuberUserById(id);
                return Page();
            }
            else
            {
                return RedirectToPage("Login");
            }
        }
        public IActionResult OnPost()
        {
            Invite invite = new Invite();
            invite.Ride = RideService.GetRideByUserId(User.User.Id);
            invite.ZuberUser = service.GetZuberUserById(1);
            invite.ZuberUserID = GetUser.Id;
            invite.RideID = RideService.GetRideByUserId(User.User.Id).Id;
            InviteService.AddInvite(invite);
            return RedirectToPage("MyInvites");
        }

    }
}
