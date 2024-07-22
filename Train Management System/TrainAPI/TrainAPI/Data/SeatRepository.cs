using System.Collections.Generic;
using System.Linq;
using TrainAPI.Models;

namespace TrainAPI.Data
{
    public class SeatRepository
    {
        private readonly List<Seat> _seats;

        public SeatRepository()
        {
            // Initialize the seats list (you can load from a database here if needed)
            _seats = new List<Seat>();
        }

        public bool CreateSeat(Seat seat)
        {
            try
            {
                seat.Id = _seats.Count + 1; // Generate unique id
                _seats.Add(seat);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Seat GetSeat(int id)
        {
            return _seats.FirstOrDefault(seat => seat.Id == id);
        }

        public IEnumerable<Seat> GetSeats()
        {
            return _seats.ToList();
        }

        public bool RemoveSeat(Seat seat)
        {
            try
            {
                _seats.Remove(seat);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateSeat(Seat updatedSeat)
        {
            try
            {
                var index = _seats.FindIndex(seat => seat.Id == updatedSeat.Id);
                if (index != -1)
                {
                    _seats[index] = updatedSeat;
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

