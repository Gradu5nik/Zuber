using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zuber.Models;
using Zuber.Services.Interfaces;

namespace Zuber.Services.EFServices
{
    public class EFInviteService : IInviteService
    {
        ZuberDBContext service;
        public EFInviteService(ZuberDBContext db)
        {
            service = db;
        }
        public void AddInvite(Invite invite)
        {
            service.Invites.Add(invite);
            service.SaveChanges();
        }

        public void DeleteInvite(int id)
        {
            service.Invites.Remove(GetInviteById(id));
            service.SaveChanges();
        }

        public List<Invite> GetAllInvites()
        {
            return service.Invites.ToList<Invite>();
        }

        public List<Invite> GetAllInvitesForUser(int id)
        {
            return service.Invites.Where(x => x.ZuberUserID == id).Include(d => d.Ride).Include(d => d.Ride.Driver).ToList<Invite>();
        }
        public List<Invite> GetAllInvitesForRide(int id)
        {
            return service.Invites.Where(x => x.RideID == id).ToList<Invite>();
        }

        public Invite GetInviteById(int id)
        {
            return service.Invites.Where(x => x.Id == id).FirstOrDefault();
        }

        public void UpdateInvite(Invite invite)
        {
            service.Invites.Update(invite);
            service.SaveChanges();
        }
    }
}
