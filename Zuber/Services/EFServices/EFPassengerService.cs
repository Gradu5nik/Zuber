using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Zuber.Models;
using Zuber.Services.Interfaces;

namespace Zuber.Services.EFServices
{
    public class EFPassengerService:IPassengerService
    {
        ZuberDBContext service;
        public EFPassengerService(ZuberDBContext s)
        {
            service = s;
        }
        public void AddPassenger(Passenger passenger)
        {

            service.Passengers.Add(passenger);
            service.SaveChanges();
        }

        public void DeletePassenger(int id)
        {
            service.Passengers.Remove(GetPassengerById(id));
            service.SaveChanges();
        }
        public void UpdatePassenger(Passenger passenger)
        {
            service.Passengers.Update(passenger);
            service.SaveChanges();
        }

        public List<Passenger> GetAllPassengers()
        {
            return service.Passengers.ToList<Passenger>();
        }

        public List<Passenger> GetAllPassengersOfRide(int id)
        {
            return service.Passengers.Where(x => x.RideID == id).ToList<Passenger>();
        }

        public Passenger GetPassengerById(int id)
        {
            return service.Passengers.Where(x => x.Id == id).FirstOrDefault();
        }
        public Passenger GetPassengerByUserId(int id)
        {
            return service.Passengers.Where(x => x.ZuberUserID == id).FirstOrDefault();
        }
    }
}
