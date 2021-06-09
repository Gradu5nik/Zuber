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
    public class MyInvitesModel : PageModel
    {
        public SingletonUser User;
        public IInviteService inviteService;
        public IRideService rideService;
        [BindProperty]
        public List<Invite> MyInvites { get; set; }
        public MyInvitesModel(SingletonUser s, IInviteService i, IRideService r)
        {
            User = s;
            inviteService = i;
            rideService = r;
            
        }
        public IActionResult OnGet()
        {
            if (!User.SignedIn)
            {
                return RedirectToPage("Login");
            }
            MyInvites = inviteService.GetAllInvitesForUser(User.User.Id);
            return Page();
        }
        public IActionResult OnPostAccept(int id)
        {
            Invite toAccept = inviteService.GetInviteById(id);
            Ride luckyRide = rideService.GetRideById(toAccept.RideID);
            luckyRide.PlacesRemaining -= 1;
            //add some more for including user in the ride
            rideService.UpdateRide(luckyRide);
            if (luckyRide.PlacesRemaining <= 0)
            {
                List<Invite> obsInvites = inviteService.GetAllInvitesForRide(luckyRide.Id);
                foreach (var item in obsInvites)
                {
                    inviteService.DeleteInvite(item.Id);
                }
            }

            return Page();
        }
        public IActionResult OnPostDecline(int id)
        {
            inviteService.DeleteInvite(id);
            //maybe add some messages
            return Page();
        }
    }
}
