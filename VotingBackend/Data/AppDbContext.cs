using Microsoft.EntityFrameworkCore;
using VotingBackend.Models;

namespace VotingBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<PoliticalMember> PoliticalMembers { get; set; }
        public DbSet<PoliticalMemberType> PoliticalMemberTypes { get; set; }

        public DbSet<PoliticalParty> PoliticalParties { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Voter> Voters { get; set; }
        public DbSet<Year> Years { get; set; }
        public DbSet<SupportUser> SupportUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigurePoliticalPartyRelations(modelBuilder);
            ConfigureVoterRelations(modelBuilder);
            ConfigureVoteRelation(modelBuilder);
            base.OnModelCreating(modelBuilder);

        }

        private void ConfigurePoliticalPartyRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PoliticalParty>()
                .HasMany(p => p.Members)
                .WithOne(m => m.PoliticalParty)
                .HasForeignKey(m => m.PoliticalPartyId);

            modelBuilder.Entity<PoliticalMember>()
                .HasOne(m => m.PoliticalParty)
                .WithMany(p => p.Members)
                .HasForeignKey(m => m.PoliticalPartyId);
        }

        private void ConfigureVoterRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Voter>()
                .HasOne(v => v.Specialty)
                .WithMany(s => s.Voters)
                .HasForeignKey(v => v.SpecialtyId);

            modelBuilder.Entity<Voter>()
                .HasOne(v => v.year)
                .WithMany(y => y.Voters)
                .HasForeignKey(v => v.YearId);

            modelBuilder.Entity<Year>()
                .HasMany(y => y.Voters)
                .WithOne(v => v.year)
                .HasForeignKey(v => v.YearId);

            modelBuilder.Entity<Specialty>()
                .HasMany(s => s.Voters)
                .WithOne(v => v.Specialty)
                .HasForeignKey(v => v.SpecialtyId);

        }



        private void ConfigureVoteRelation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vote>()
                .HasOne(v => v.Voter)
                .WithOne(vr => vr.Vote);

            modelBuilder.Entity<Vote>()
                .HasOne(v => v.PoliticalParty)
                .WithMany(p => p.Votes)
                .HasForeignKey(v => v.PoliticalId);
        }
    }
}