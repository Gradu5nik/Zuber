using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zuber.Models;

namespace Zuber.Services.Interfaces
{
    public interface IInviteService
    {
        public void AddInvite(Invite Invite);
        public void UpdateInvite(Invite Invite);
        public void DeleteInvite(int id);
        public List<Invite> GetAllInvites();

        public List<Invite> GetAllInvitesForUser(int id);

        public List<Invite> GetAllInvitesForRide(int id);
        public Invite GetInviteById(int id);
    }
}
