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
    public class SeatController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly SeatRepository _repository;

        public SeatController(SeatRepository seatRepository, IMapper mapper)
        {
            _repository = seatRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult CreateSeat(SeatCreateDTO seatCreate)
        {
            var seat = _mapper.Map<Seat>(seatCreate);
            if (_repository.CreateSeat(seat))
                return Ok();
            else
                return BadRequest();
        }

        [HttpGet("{id}", Name = "GetSeatById")]
        public ActionResult<SeatReadDTO> GetSeat(int id)
        {
            var seat = _repository.GetSeat(id);
            if (seat != null)
                return Ok(_mapper.Map<SeatReadDTO>(seat));
            else
                return NotFound();
        }

        [HttpGet]
        public ActionResult<IEnumerable<SeatReadDTO>> GetSeats()
        {
            var seats = _repository.GetSeats();
            return Ok(_mapper.Map<IEnumerable<SeatReadDTO>>(seats));
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteSeat(int id)
        {
            var seat = _repository.GetSeat(id);
            if (seat != null)
            {
                _repository.RemoveSeat(seat);
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateSeat(int id, SeatCreateDTO createDTO)
        {
            var seat = _mapper.Map<Seat>(createDTO);
            seat.Id = id;
            if (_repository.UpdateSeat(seat))
                return Ok();
            else
                return NotFound();
        }
    }
}
