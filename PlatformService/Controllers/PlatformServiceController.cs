using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using platformService.Data;
using PlatformService.Models;

namespace platformService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlatformServiceController : ControllerBase
    {
        private IPlatformRepo _repo;
        private IMapper _mapper;

        public PlatformServiceController(IPlatformRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            Console.WriteLine("Getting platforms..");

            var platformItems=_repo.GetAllPlatforms();

            if(platformItems!=null)
            {

            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItems));
            }

            return NotFound();
        }


        [HttpGet("{id}",Name="GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById(int id)
        {
            Console.WriteLine("Getting platform..");

            var platformItems=_repo.GetPlatformById(id);

            if(platformItems!=null)
            {
                return Ok(_mapper.Map<PlatformReadDto>(platformItems));
            }

            return NotFound();


        }

        [HttpPost]
        public ActionResult<PlatformReadDto> CreatePlatform(PlatformWriteDto platformWriteDto)
        {
            Console.WriteLine("Creating platform...");

            if(platformWriteDto!=null)
            {
                var platform=_mapper.Map<Platform>(platformWriteDto);
                 _repo.CreatePlatform(platform);
                 _repo.SaveChanges();

                 var platformReadDto=_mapper.Map<PlatformReadDto>(platform);

                 return CreatedAtRoute(nameof(GetPlatformById),new{id=platformReadDto.Id},platformReadDto);

            }

            return NotFound();

        }


    }

}