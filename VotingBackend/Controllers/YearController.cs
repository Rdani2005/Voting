using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VotingBackend.Dtos.Specialty;
using VotingBackend.Models;
using VotingBackend.Repos.YearRepo;

namespace VotingBackend.Controllers
{
    [ApiController]
    [Route("api/v1/years")]
    public class YearController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IYearRepo _repo;

        public YearController(IMapper mapper, IYearRepo repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpPost]
        public ActionResult<YearReadDto> AddYear(AddYearDto dto)
        {
            var NewYear = _mapper.Map<Year>(dto);
            NewYear.Voters = new List<Voter>();
            _repo.AddYear(NewYear);
            return CreatedAtRoute(
                nameof(GetYearById),
                new { Id = NewYear.Id },
                _mapper.Map<YearReadDto>(NewYear)
            );

        }


        [HttpGet("{id}", Name = "GetYearById")]
        public ActionResult<YearReadDto> GetYearById(int id)
        {
            var year = _repo.GetYear(id);
            return (year == null)
                ? NotFound()
                : Ok(_mapper.Map<YearReadDto>(year));
        }

        [HttpGet]
        public ActionResult<IEnumerable<YearReadDto>> GetAllYears()
        {
            return Ok(
                _mapper.Map<IEnumerable<YearReadDto>>(
                    _repo.AllYears
                )
            );
        }
    }
}