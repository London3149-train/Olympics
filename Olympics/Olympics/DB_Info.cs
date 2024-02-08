using Microsoft.EntityFrameworkCore;

namespace Olympics
{
    public class DB_Info : DbContext
    {
        public DbSet<InfoOlympiad> InfoOlympiad { get; set; } = null!;
        public DbSet<KindOfSport> KindOfSport { get; set; } = null!;
        public DbSet<Participant> Participant { get; set; } = null!;
        public DbSet<ParticipantsResult> ParticipantsResult { get; set; } = null!;

        public DB_Info ( )
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring ( DbContextOptionsBuilder optionsBuilder )
        {
            optionsBuilder.UseSqlServer( @"Server=localhost,5000;Database=Olympiad;Trusted_Connection=False;User ID=sa;Password=Fackuy2l;TrustServerCertificate=true;" );
        }
    }
}
