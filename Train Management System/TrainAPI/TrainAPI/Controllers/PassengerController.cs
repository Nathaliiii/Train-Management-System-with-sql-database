using Microsoft.AspNetCore.Mvc;
using TrainAPI.Data;
using TrainAPI.DTO;
using TrainAPI.Models;
using AutoMapper;
using System.Collections.Generic;

namespace TrainAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly PassengerRepository _repository;

        public PassengerController(PassengerRepository passengerRepository, IMapper mapper)
        {
            _repository = passengerRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult CreatePassenger(PassengerCreateDTO passengerCreate)
        {
            var passenger = _mapper.Map<Passenger>(passengerCreate);
            if (_repository.CreatePassenger(passenger))
                return Ok();
            else
                return BadRequest();
        }

        [HttpGet("{id}", Name = "GetPassengerById")]
        public ActionResult<PassengerReadDTO> GetPassenger(int id)
        {
            var passenger = _repository.GetPassenger(id);
            if (passenger != null)
                return Ok(_mapper.Map<PassengerReadDTO>(passenger));
            else
                return NotFound();
        }

        [HttpGet]
        public ActionResult<IEnumerable<PassengerReadDTO>> GetPassengers()
        {
            var passengers = _repository.GetPassengers();
            return Ok(_mapper.Map<IEnumerable<PassengerReadDTO>>(passengers));
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePassenger(int id)
        {
            var passenger = _repository.GetPassenger(id);
            if (passenger != null)
            {
                _repository.RemovePassenger(passenger);
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePassenger(int id, PassengerCreateDTO createDTO)
        {
            var passenger = _mapper.Map<Passenger>(createDTO);
            passenger.Id = id;
            if (_repository.UpdatePassenger(passenger))
                return Ok();
            else
                return NotFound();
        }
    }
}

