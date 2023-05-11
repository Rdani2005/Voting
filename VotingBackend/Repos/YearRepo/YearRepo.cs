using VotingBackend.Data;
using VotingBackend.Models;

namespace VotingBackend.Repos.YearRepo
{
    public class YearRepo : IYearRepo
    {
        private readonly AppDbContext _context;

        public YearRepo(AppDbContext context)
        {
            _context = context;
        }

        public void AddYear(Year year)
        {
            if (year == null) throw new ArgumentNullException(nameof(year));
            _context.Years.Add(year);
            _context.SaveChanges();
        }

        public IEnumerable<Year> AllYears =>
            _context.Years.ToList();

        public Year GetYear(int id) =>
            _context.Years.FirstOrDefault(
                y => y.Id == id
            );
    }
}
