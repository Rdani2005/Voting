using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VotingBackend.Dtos.Parties;
using VotingBackend.Models;
using VotingBackend.Repos.PoliticalPartyRepo;


namespace VotingBackend.Controllers
{
    [ApiController]
    [Route("api/v1/partidos/")]
    public class PoliticalControlller : ControllerBase
    {
        private readonly IPoliticalRepo _repo;
        private readonly IMapper _mapper;

        public PoliticalControlller(IPoliticalRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<PartyReadDto>> GetAllParties()
        {
            return Ok(
                _mapper.Map<IEnumerable<PartyReadDto>>(
                    _repo.GetPoliticalParties()
                )
            );
        }

        [HttpGet("{id}", Name = "GetSingleParty")]
        public ActionResult<PartyReadDto> GetSingleParty(int id)
        {
            var Party = _repo.GetPoliticalPartyById(id);
            return
                Party == null
                    ? NotFound()
                    : Ok(
                        _mapper.Map<PartyReadDto>(Party)
                    );
        }

        [HttpPost]
        public ActionResult AddParty(AddPartyDto dto)
        {
            var Party = _mapper.Map<PoliticalParty>(dto);
            Party.Votes = new List<Vote>();
            _repo.CreatePoliticalParty(Party);
            var readDto = _mapper.Map<PartyReadDto>(Party);
            return CreatedAtRoute(
                nameof(GetSingleParty),
                new { Id = readDto.Id },
                readDto

            );

        }


    }
}