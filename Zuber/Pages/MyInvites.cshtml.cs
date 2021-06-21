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
        public IUserService userService;
        public IPassengerService passengerService;
        [BindProperty]
        public List<Invite> MyInvites { get; set; }
        [BindProperty]
        public List<Passenger> RidePassengers { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public MyInvitesModel(SingletonUser s, IInviteService i, IRideService r, IUserService u, IPassengerService p)
        {
            User = s;
            inviteService = i;
            rideService = r;
            userService = u;
            passengerService = p;
        }
        public IActionResult OnGet()
        {
            if (!User.SignedIn)
            {
                return RedirectToPage("Login");
            }
            MyInvites = inviteService.GetAllInvitesForUser(User.User.Id);
            RidePassengers = new List<Passenger>();
            if (User.IsDriver)
            {
                RidePassengers = passengerService.GetAllPassengersOfRide(rideService.GetRideByUserId(User.User.Id).Id);
            }
            foreach (var Invite in MyInvites)
            {
                Invite.Ride = rideService.GetRideById(Invite.RideID);
                Invite.ZuberUser = userService.GetZuberUserById(Invite.ZuberUserID);
                Invite.Ride.Driver = userService.GetZuberUserById(rideService.GetRideById(Invite.RideID).DriverId);
            }
            return Page();
        }
        public IActionResult OnPostAccept(int id)
        {
            Invite toAccept = inviteService.GetInviteById(id);
            Ride luckyRide = rideService.GetRideById(toAccept.RideID);
            Passenger passenger = new Passenger();
            passenger.Ride = luckyRide;
            passenger.ZuberUserID = User.User.Id;
            passengerService.AddPassenger(passenger);
            luckyRide.PlacesRemaining -= 1;
            //add some more for including user in the ride, I think I did
            rideService.UpdateRide(luckyRide);
            inviteService.DeleteInvite(toAccept.Id);
            if (luckyRide.PlacesRemaining <= 0)
            {
                List<Invite> obsInvites = inviteService.GetAllInvitesForRide(luckyRide.Id);
                foreach (var item in obsInvites)
                {
                    inviteService.DeleteInvite(item.Id);
                }
            }

            Message = "You have accepted an invite! The driver will be notified.";
            return Page();
        }
        public IActionResult OnPostDecline(int id)
        {
            inviteService.DeleteInvite(id);
            Message = "You have deleted an invite.";
            return Page();
        }
    }
}
