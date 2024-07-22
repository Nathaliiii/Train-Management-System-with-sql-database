using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TrainAPI.Models;

namespace TrainAPI.Data
{
    public class TrainRepository
    {
        private readonly List<Train> _trains;

        public TrainRepository()
        {
            // Initialize the trains list (you can load from a database here if needed)
            _trains = new List<Train>();
        }

        public bool CreateTrain(Train train)
        {
            try
            {
                train.Id = _trains.Count + 1; // Generate unique id
                _trains.Add(train);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Train GetTrain(int id)
        {
            return _trains.FirstOrDefault(train => train.Id == id);
        }

        public IEnumerable<Train> GetTrains()
        {
            return _trains.ToList();
        }

        public bool RemoveTrain(Train train)
        {
            try
            {
                _trains.Remove(train);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateTrain(Train updatedTrain)
        {
            try
            {
                var index = _trains.FindIndex(train => train.Id == updatedTrain.Id);
                if (index != -1)
                {
                    _trains[index] = updatedTrain;
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

