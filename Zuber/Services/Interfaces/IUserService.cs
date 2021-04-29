﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zuber.Models;

namespace Zuber.Services.Interfaces
{
    public interface IUserService
    {
        public void AddZuberUser(ZuberUser user);
        public void DeleteZuberUser(string email);
        public List<ZuberUser> GetAllUsers();
        public ZuberUser GetZuberUser(string email);
    }
}