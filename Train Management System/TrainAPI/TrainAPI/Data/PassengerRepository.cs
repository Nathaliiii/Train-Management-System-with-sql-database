using System.Collections.Generic;
using System.Linq;
using TrainAPI.Models;

namespace TrainAPI.Data
{
    public class PassengerRepository
    {
        private readonly List<Passenger> _passengers;

        public PassengerRepository()
        {
            // Initialize the passengers list (you can load from a database here if needed)
            _passengers = new List<Passenger>();
        }

        public bool CreatePassenger(Passenger passenger)
        {
            try
            {
                passenger.Id = _passengers.Count + 1; // Generate unique id
                _passengers.Add(passenger);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Passenger GetPassenger(int id)
        {
            return _passengers.FirstOrDefault(passenger => passenger.Id == id);
        }

        public IEnumerable<Passenger> GetPassengers()
        {
            return _passengers.ToList();
        }

        public bool RemovePassenger(Passenger passenger)
        {
            try
            {
                _passengers.Remove(passenger);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdatePassenger(Passenger updatedPassenger)
        {
            try
            {
                var index = _passengers.FindIndex(passenger => passenger.Id == updatedPassenger.Id);
                if (index != -1)
                {
                    _passengers[index] = updatedPassenger;
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}

