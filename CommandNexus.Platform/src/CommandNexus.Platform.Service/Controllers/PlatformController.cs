using AutoMapper;
using CommandNexus.Platform.Service.Dtos;
using CommandNexus.Platform.Service.Models;
using Microsoft.AspNetCore.Mvc;
using CommandNexus.Common;

namespace CommandNexus.Platform.Service.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PlatformController : ControllerBase
    {

        private readonly IRepository<PlatformModel> _repository;
        private readonly IMapper _mapper;

        
        public PlatformController(IRepository<PlatformModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            Console.WriteLine("Reading Platforms....");
            var platformItems = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItems));
        }

        [HttpGet("{id}", Name = "GetPlatform")]
        public ActionResult<PlatformReadDto> GetPlatform(Guid id)
        {
            var platformItem = _repository.GetById(id);

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
            _repository.Create(platform);
            _repository.SaveChanges();

            var platformReadDto = _mapper.Map<PlatformReadDto>(platform);

            return CreatedAtRoute(nameof(GetPlatform), new { platformReadDto.Id }, platformReadDto);
        }

    }
}
    