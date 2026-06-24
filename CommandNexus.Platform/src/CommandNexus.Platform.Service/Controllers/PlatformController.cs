using AutoMapper;
using CommandNexus.Platform.Service.Dtos;
using CommandNexus.Platform.Service.Models;
using Microsoft.AspNetCore.Mvc;
using CommandNexus.Common;
using CommandNexus.Platform.Service.SyncDataServices.Http;

namespace CommandNexus.Platform.Service.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PlatformController : ControllerBase
    {
        private readonly ICommandDataClient _commandClient;
        private readonly IRepository<PlatformModel> _repository;
        private readonly IMapper _mapper;

        
        public PlatformController(IRepository<PlatformModel> repository, IMapper mapper,ICommandDataClient commandClient)
        {
            _commandClient = commandClient;
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
        public async Task<ActionResult<PlatformReadDto>> CreatePlatform(PlatformCreatedDto dto)
        {
            var platform = _mapper.Map<PlatformModel>(dto);
            _repository.Create(platform);
            _repository.SaveChanges();

            var platformReadDto = _mapper.Map<PlatformReadDto>(platform);

            try
            {
                await _commandClient.SendPlatformToCommand(platformReadDto);
            }

            catch(Exception e)
            {
                Console.WriteLine($"Could not send data synchronously: {e.Message}");
            }

            return CreatedAtRoute(nameof(GetPlatform), new { platformReadDto.Id }, platformReadDto);
        }

    }
}
    