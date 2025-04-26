namespace PlaformService.Controllers
{
    using System.Collections.Generic;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using PlatformService.Data;
    using PlatformService.Dtos;
    using PlatformService.Models;
    using PlatformService.Repository;

    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepository _repository;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDTO>> GetPlatforms()
        {
            var platforms = _repository.GetAllPlatforms();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDTO>>(platforms));
        }
        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<PlatformReadDTO> GetPlatformById(int id)
        {
            var platform = _repository.GetPlatformById(id);
            if (platform != null)
            {
                return Ok(_mapper.Map<PlatformReadDTO>(platform));
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult<PlatformReadDTO> CreatePlatform(PlatformCreateDTO platformCreateDTO)
        {
            var platformModel = _mapper.Map<Platform>(platformCreateDTO);
            _repository.CreatePlatform(platformModel);
            _repository.SaveChanges();
            var platformReadDTO = _mapper.Map<PlatformReadDTO>(platformModel);
            return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformReadDTO.Id }, platformReadDTO);
        }
        [HttpPut("{id}")]
        public ActionResult UpdatePlatform(int id, PlatformCreateDTO platformCreateDTO)
        {
            var platformModelFromRepo = _repository.GetPlatformById(id);
            if (platformModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(platformCreateDTO, platformModelFromRepo);
            _repository.UpdatePlatform(platformModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeletePlatform(int id)
        {
            var platformModelFromRepo = _repository.GetPlatformById(id);
            if (platformModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeletePlatform(id);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}