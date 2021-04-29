using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zuber.Models;

namespace Zuber.Services.EFServices
{
    public class SingletonUser
    {
        public ZuberUser User { get; set; }

        public SingletonUser()
        {

        }
    }
}
