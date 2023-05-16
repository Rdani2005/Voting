using Microsoft.AspNetCore.Mvc;
using VotingBackend.Dtos.Vote;
using VotingBackend.Repos.PoliticalPartyRepo;

namespace VotingBackend.Controllers
{

    [ApiController]
    [Route("api/v1/counter")]
    public class CounterController : ControllerBase
    {
        private readonly IPoliticalRepo _repo;

        public CounterController(IPoliticalRepo repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public ActionResult<IEnumerable<VoteCounterReadDto>> GetAllVotesCounter()
        {
            var parties = _repo.GetPoliticalParties();
            var voteCounters = new List<VoteCounterReadDto>();
            foreach (var party in parties)
            {
                voteCounters.Add(
                    new VoteCounterReadDto()
                    {
                        PoliticalPartyName = party.Name,
                        VoteAmount = _repo.GetPoliticalPartyVotesCount(party.Id)
                    }
                );
            }

            return Ok(voteCounters);
        }
    }
}