using Microsoft.AspNetCore.Mvc;
using VotingBackend.Dtos.Vote;
using VotingBackend.Models;
using VotingBackend.Repos.PoliticalPartyRepo;
using VotingBackend.Repos.VoteRepo;
using VotingBackend.Repos.VoterRepo;

namespace VotingBackend.Controllers
{
    [ApiController]
    [Route("api/v1/voter/{voterId}/vote")]
    public class VoteController : ControllerBase
    {
        private readonly IVoteRepo _repo;
        private readonly IVoterRepo _voterRepo;
        private readonly IPoliticalRepo _partyRepo;

        public VoteController(
            IVoteRepo repo,
            IVoterRepo voterRepo,
            IPoliticalRepo partyRepo
        )
        {
            _repo = repo;
            _voterRepo = voterRepo;
            _partyRepo = partyRepo;
        }

        [HttpPost]
        public ActionResult HasUserVote(int voterId)
        {
            return _repo.UserHasVote(voterId)
                ? Forbid("El estudiante ya ha emitido su voto")
                : Ok("El estudiante puede emitir su voto");
        }


        [HttpPost("confirm")]
        public ActionResult EmitVote(int voterId, AddVoteDto addVote)
        {
            var Voter = _voterRepo.GetVoterById(voterId);

            var PoliticalParty = _partyRepo.GetPoliticalPartyById(addVote.PartyId);

            if (PoliticalParty == null) return NotFound("No se encuentra el partido");

            var vote = new Vote()
            {
                PoliticalId = addVote.PartyId,
                PoliticalParty = PoliticalParty,
                Voter = Voter,
                VoterId = voterId
            };

            _repo.UseVote(vote);

            Voter.Vote = vote;
            PoliticalParty.Votes.Add(vote);
            return Ok("Estudiante ha votado con exito!");
        }
    }
}