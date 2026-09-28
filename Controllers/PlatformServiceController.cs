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

            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItems));

        }
    }

}