using AutoMapper;
using CommandNexus.Platform.Service.Data;
using CommandNexus.Platform.Service.Dtos;
using CommandNexus.Platform.Service.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop.Infrastructure;

namespace CommandNexus.Platform.Service.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PlatformController : ControllerBase
    {

        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;

        
        public PlatformController(IPlatformRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            Console.WriteLine("Reading Platforms....");
            var platformItems = _repository.GetAllPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItems));
        }

        [HttpGet("{id}", Name = "GetPlatform")]
        public ActionResult<PlatformReadDto> GetPlatform(Guid id)
        {
            var platformItem = _repository.GetPlatformById(id);

            if(platformItem != null)
            {
                return Ok(_mapper.Map<PlatformReadDto>(platformItem));
            }

            return NotFound("Platform Not found");
        }

        [HttpPost]
        public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreatedDto dto)
        {
            var platform = _mapper.Map<PlatformModel>(dto);
            _repository.CreatePlatform(platform);
            _repository.SaveChanges();

            var platformReadDto = _mapper.Map<PlatformReadDto>(platform);

            return CreatedAtRoute(nameof(GetPlatform), new { platformReadDto.Id }, platformReadDto);
        }

    }
}
    