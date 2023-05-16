using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VotingBackend.Dtos.Specialty;
using VotingBackend.Models;
using VotingBackend.Repos.SpecialtyRepo;

namespace VotingBackend.Controllers
{
    [ApiController]
    [Route("api/v1/specialties")]
    public class SpecialtyController : ControllerBase
    {
        private IMapper _mapper;
        private ISpecialtyRepo _repo;

        public SpecialtyController(
            IMapper mapper,
            ISpecialtyRepo repo
        )
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReadSpecialtyDto>> GetAll()
        {
            return Ok(
                _mapper.Map<IEnumerable<ReadSpecialtyDto>>(
                    _repo.GetAllSpecialties()
                )
            );
        }


        [HttpGet("{id}", Name = "GetSpecialtyId")]
        public ActionResult<ReadSpecialtyDto> GetSpecialtyId(int id)
        {
            Specialty Specialty = _repo.GetSpecialty(id);
            return (Specialty == null)
                ? NotFound()
                : Ok(_mapper.Map<ReadSpecialtyDto>(Specialty));
        }

        [HttpPost]
        public ActionResult<ReadSpecialtyDto> AddSpecialty(AddSpecialtyDto dto)
        {
            Specialty specialty = _mapper.Map<Specialty>(dto);
            specialty.Voters = new List<Voter>();
            _repo.CreateSpecialty(specialty);
            return CreatedAtRoute(
                nameof(GetSpecialtyId),
                new { Id = specialty.Id },
                _mapper.Map<ReadSpecialtyDto>(specialty)
            );
        }
    }
}