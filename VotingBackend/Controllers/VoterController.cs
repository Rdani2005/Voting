using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VotingBackend.Dtos.Specialty;
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
            var voters = _repo.GetAllVoters();
            var response = new List<ReadVoter>();
            foreach (var voter in voters)
            {
                var voterRead = _mapper.Map<ReadVoter>(voter);
                voterRead.Specialty = _mapper.Map<ReadSpecialtyDto>(_repo.GetVoterSpecialty(voter.SpecialtyId));
                voterRead.year = _mapper.Map<YearReadDto>(_repo.GetVoterYear(voter.YearId));

                response.Add(voterRead);
            }


            return Ok(_mapper.Map<IEnumerable<ReadVoter>>(
                    response
                ));
        }

        [HttpGet("{voterId}", Name = "GetSingleVoterById")]
        public ActionResult<ReadVoter> GetSingleVoterById(int voterId)
        {
            var voter = _repo.GetVoterById(voterId);
            if (voter == null) return NotFound();

            var voterRead = _mapper.Map<ReadVoter>(voter);
            voterRead.Specialty = _mapper.Map<ReadSpecialtyDto>(_repo.GetVoterSpecialty(voter.SpecialtyId));
            voterRead.year = _mapper.Map<YearReadDto>(_repo.GetVoterYear(voter.YearId));

            return Ok(_mapper.Map<ReadVoter>(voter));

        }

        [HttpGet("id/{voterIdentification}", Name = "GetVoterByIdentification")]
        public ActionResult<ReadVoter> GetVoterByIdentification(String voterIdentification)
        {
            var voter = _repo.GetVoterByIdentification(voterIdentification);
            if (voter == null) return NotFound();

            var voterRead = _mapper.Map<ReadVoter>(voter);
            voterRead.Specialty = _mapper.Map<ReadSpecialtyDto>(_repo.GetVoterSpecialty(voter.SpecialtyId));
            voterRead.year = _mapper.Map<YearReadDto>(_repo.GetVoterYear(voter.YearId));

            return Ok(_mapper.Map<ReadVoter>(voter));
        }

        [HttpPost]
        public ActionResult<ReadVoter> AddVoter(AddVoter voterDto)
        {
            var newVoter = _mapper.Map<Voter>(voterDto);

            var specialty = _specialRepo.GetSpecialty(voterDto.SpecialtyId);
            if (specialty == null)
            {
                return NotFound($"Specialty with ID {voterDto.SpecialtyId} not found.");
            }

            Console.WriteLine($"--> Especialidad del votante: {specialty.Name}");

            var year = _yearRepo.GetYear(voterDto.YearId);
            if (year == null)
            {
                return NotFound($"Year with ID {voterDto.YearId} not found.");
            }

            Console.WriteLine($"--> Año del votante: {year.Name}");

            newVoter.SpecialtyId = specialty.Id;
            newVoter.YearId = year.Id;

            newVoter.Specialty = specialty;
            newVoter.year = year;


            _repo.CreateVoter(newVoter);

            specialty.Voters.Add(newVoter);
            year.Voters.Add(newVoter);

            ReadVoter voter = _mapper.Map<ReadVoter>(newVoter);
            voter.Specialty = _mapper.Map<ReadSpecialtyDto>(specialty);
            voter.year = _mapper.Map<YearReadDto>(year);

            // return CreatedAtRoute(
            //     nameof(GetSingleVoterById),
            //     new { voterIdentification = voter.Id },
            //     voter
            // );

            return Ok(voter);
        }
    }
}