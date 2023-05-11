using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VotingBackend.Dtos.Members;
using VotingBackend.Models;
using VotingBackend.Repos.PoliticalMemberRepo;
using VotingBackend.Repos.PoliticalPartyRepo;

namespace VotingBackend.Controllers
{
    [ApiController]
    [Route("api/v1/partidos/{partyId}/members")]
    public class MemberController : ControllerBase
    {
        private readonly IPoliticalMemberRepo _repo;
        private readonly IMapper _mapper;
        private readonly IPoliticalRepo _partyRepo;
        private readonly IPoliticalMemberTypeRepo _typeRepo;

        public MemberController(
            IPoliticalMemberRepo repo,
            IMapper mapper, IPoliticalRepo partyRepo,
            IPoliticalMemberTypeRepo typeRepo
        )
        {
            _repo = repo;
            _mapper = mapper;
            _partyRepo = partyRepo;
            _typeRepo = typeRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReadMemberDto>> GetAllMembers(int partyId)
        {
            return Ok(
                _mapper.Map<IEnumerable<ReadMemberDto>>(
                    _repo.GetAllMembers(partyId)
                )
            );
        }

        [HttpGet("{memberId}", Name = "GetSingleMember")]
        public ActionResult<ReadMemberDto> GetSingleMember(int memberId)
        {
            var member = _repo.GetMemberById(memberId);
            return member == null
                ? NotFound()
                : Ok(_mapper.Map<ReadMemberDto>(member));

        }

        [HttpPost]
        public ActionResult AddMemberToParty(AddMemberDto addMember)
        {
            var NewMember = _mapper.Map<PoliticalMember>(addMember);
            var Party = _partyRepo.GetPoliticalPartyById(addMember.PoliticalPartyId);

            NewMember.PoliticalParty = _partyRepo.GetPoliticalPartyById(addMember.PoliticalPartyId);

            NewMember.Type = _typeRepo.GetTypeById(addMember.Type);
            NewMember.PoliticalParty = Party;

            Party.Members.Add(NewMember);
            _repo.CreateMember(NewMember);

            ReadMemberDto readMember = _mapper.Map<ReadMemberDto>(NewMember);
            return CreatedAtRoute(
                nameof(GetSingleMember),
                new { Id = readMember.Id },
                readMember
            );
        }
    }
}
