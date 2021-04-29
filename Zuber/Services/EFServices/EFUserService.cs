using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zuber.Models;
using Zuber.Services.Interfaces;

namespace Zuber.Services.EFServices
{
    public class EFUserService:IUserService
    {
        ZuberDBContext service;
        public EFUserService(ZuberDBContext s)
        {
            service = s;
        }
        public void AddZuberUser(ZuberUser user)
        {
            service.Users.Add(user);
            service.SaveChanges();
        }

        public void DeleteZuberUser(string email)
        {
            service.Users.Remove(GetZuberUser(email));
            service.SaveChanges();
        }

        public List<ZuberUser> GetAllUsers()
        {
            return service.Users.ToList<ZuberUser>();
        }

        public ZuberUser GetZuberUser(string email)
        {
            return service.Users.Where(x => x.Email == email).FirstOrDefault();
        }
    }
}
