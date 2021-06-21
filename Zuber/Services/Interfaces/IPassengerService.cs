using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zuber.Models;

namespace Zuber.Services.Interfaces
{
    public interface IPassengerService
    {
        public void AddPassenger(Passenger passenger);
        public void UpdatePassenger(Passenger passenger);
        public void DeletePassenger(int id);
        public List<Passenger> GetAllPassengers();
        public List<Passenger> GetAllPassengersOfRide(int id);
        public Passenger GetPassengerById(int id);
        public Passenger GetPassengerByUserId(int id);
    }
}
