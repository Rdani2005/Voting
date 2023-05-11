using VotingBackend.Models;

namespace VotingBackend.Repos.YearRepo
{
    public interface IYearRepo
    {
        void AddYear(Year year);
        Year GetYear(int id);
        IEnumerable<Year> AllYears { get; }
    }
}