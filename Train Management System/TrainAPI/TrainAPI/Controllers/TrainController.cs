using Microsoft.AspNetCore.Mvc;
using TrainAPI.Data;
using TrainAPI.DTO;
using TrainAPI.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Diagnostics;

namespace TrainAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly TrainRepository _repository;

        public TrainController(TrainRepository trainRepository, IMapper mapper)
        {
            _repository = trainRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult CreateTrain(TrainCreateDTO trainCreate)
        {
            var train = _mapper.Map<Train>(trainCreate);
            if (_repository.CreateTrain(train))
                return Ok();
            else
                return BadRequest();
        }

        [HttpGet("{id}", Name = "GetTrainById")]
        public ActionResult<TrainReadDTO> GetTrain(int id)
        {
            var train = _repository.GetTrain(id);
            if (train != null)
                return Ok(_mapper.Map<TrainReadDTO>(train));
            else
                return NotFound();
        }

        [HttpGet]
        public ActionResult<IEnumerable<TrainReadDTO>> GetTrains()
        {
            var trains = _repository.GetTrains();
            return Ok(_mapper.Map<IEnumerable<TrainReadDTO>>(trains));
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTrain(int id)
        {
            var train = _repository.GetTrain(id);
            if (train != null)
            {
                _repository.RemoveTrain(train);
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTrain(int id, TrainCreateDTO createDTO)
        {
            var train = _mapper.Map<Train>(createDTO);
            train.Id = id;
            if (_repository.UpdateTrain(train))
                return Ok();
            else
                return NotFound();
        }
    }
}

