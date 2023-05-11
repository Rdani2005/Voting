using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VotingBackend.Dtos.Voter;
using VotingBackend.Models;
using VotingBackend.Repos.SpecialtyRepo;
using VotingBackend.Repos.VoterRepo;
using VotingBackend.Repos.YearRepo;

namespace VotingBackend.Controllers
{
    [ApiController]
    [Route("api/v1/votantes/")]
    public class VoterController : ControllerBase
    {
        private readonly IVoterRepo _repo;
        private readonly IYearRepo _yearRepo;
        private readonly ISpecialtyRepo _specialRepo;
        private readonly IMapper _mapper;

        public VoterController(
            IVoterRepo repo,
            IYearRepo yearRepo,
            ISpecialtyRepo specialtyRepo,
            IMapper mapper
        )
        {
            _repo = repo;
            _yearRepo = yearRepo;
            _specialRepo = specialtyRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReadVoter>> GetAll()
        {
            return Ok(
                _mapper.Map<IEnumerable<ReadVoter>>(
                    _repo.GetAllVoters()
                )
            );
        }

        [HttpGet("{voterId}", Name = "GetSingleVoterById")]
        public ActionResult<ReadVoter> GetSingleVoterById(int voterId)
        {
            var voter = _repo.GetVoterById(voterId);
            return (voter == null)
                ? NotFound("Votante no fue encontrado")
                : Ok(_mapper.Map<ReadVoter>(voter));

        }

        [HttpGet("id/{voterIdentification}", Name = "GetVoterByIdentification")]
        public ActionResult<ReadVoter> GetVoterByIdentification(String voterIdentification)
        {
            var voter = _repo.GetVoterByIdentification(voterIdentification);
            return (voter == null)
                ? NotFound("Votante no fue encontrado")
                : Ok(_mapper.Map<ReadVoter>(voter));
        }

        [HttpPost]
        public ActionResult<ReadVoter> AddVoter(AddVoter voterDto)
        {
            var newVoter = _mapper.Map<Voter>(voterDto);
            newVoter.Specialty = _specialRepo.GetSpecialty(voterDto.SpecialtyId);
            newVoter.year = _yearRepo.GetYear(voterDto.YearId);
            _repo.CreateVoter(newVoter);
            ReadVoter voter = _mapper.Map<ReadVoter>(newVoter);

            return CreatedAtRoute(
                nameof(GetSingleVoterById),
                new { Id = voter.Id },
                voter
            );
        }
    }
}