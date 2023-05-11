using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VotingBackend.Dtos.Support;
using VotingBackend.Models;
using VotingBackend.Repos.SupportUserRepo;

namespace VotingBackend.Controllers
{
    [ApiController]
    [Route("api/v1/support")]
    public class SupportController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISupportUserRepo _repo;

        public SupportController(
            IMapper mapper,
            ISupportUserRepo repo
        )
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReadSupportDto>> GetAllSupports()
        {
            return Ok(
                _mapper.Map<IEnumerable<ReadSupportDto>>(_repo.GetAllUsers())
            );
        }

        [HttpPost("login")]
        public ActionResult<ReadSupportDto> LoginUser(LoginDto loginDto)
        {
            var supportUser = _repo.GetSupportUser(loginDto.identification, loginDto.Password);
            return supportUser == null
                ? NotFound("Bad Credentials")
                : Ok(_mapper.Map<ReadSupportDto>(supportUser));
        }
        [HttpPost("{id}", Name = "GetSupportId")]
        public ActionResult<ReadSupportDto> GetSupportId(int id)
        {
            var Support = _repo.GetSupportUserById(id);
            return Support == null
                ? NotFound()
                : Ok(_mapper.Map<ReadSupportDto>(Support));
        }

        [HttpPost("add")]
        public ActionResult<ReadSupportDto> AddUser(AddSupportDto addSupportDto)
        {
            var Support = _mapper.Map<SupportUser>(addSupportDto);
            _repo.CreateSupportUser(Support);
            var ReadSupportDto = _mapper.Map<ReadSupportDto>(Support);

            return CreatedAtRoute(
                nameof(GetSupportId),
                new { Id = ReadSupportDto.Id },
                ReadSupportDto
            );
        }
    }
}