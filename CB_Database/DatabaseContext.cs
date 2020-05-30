using CB_V1;
using Microsoft.EntityFrameworkCore;


namespace CB_Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Actiune> Actiune { get; set; }
        public DbSet<ParcursRutina> ParcursRutina { get; set; }
        public DbSet<Rutina> Rutina { get; set; }
        public DbSet<Stare> Stare { get; set; }
        public DbSet<Utilizator> Utilizator { get; set; }
        public DbSet<RutinaActiune> RutinaActiune { get; set; }
        public DbSet<GeneratorRutina> GeneratorRutina { get; set; }

        private readonly string _databasePath;

        public DatabaseContext(string databasePath)
        {
            _databasePath = databasePath;

            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(string.Format("Filename={0}", _databasePath));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actiune>()
            .HasMany(s => s.RutinaActiune);

            modelBuilder.Entity<Actiune>()
           .HasMany(s => s.GeneratorRutina);

            modelBuilder.Entity<ParcursRutina>()
           .HasOne(s => s.Rutina)
            .WithMany(c => c.ParcursRutina)
            .HasForeignKey(s => s.IdRutina)
            .HasPrincipalKey(c => c.Id);

            modelBuilder.Entity<Rutina>()
            .HasOne(s => s.Utilizator)
             .WithMany(c => c.Rutina)
             .HasForeignKey(s => s.IdUtilizator)
             .HasPrincipalKey(c => c.Id);

            modelBuilder.Entity<Utilizator>()
           .HasOne(x => x.UltimParcursRutina)
           .WithMany()
           .HasForeignKey(x => x.IdUltimParcursRutina);


            modelBuilder.Entity<GeneratorRutina>()
            .HasOne(s => s.Actiune)
            .WithMany(x => x.GeneratorRutina)
            .HasForeignKey(s => s.IdActiune)
            .HasPrincipalKey(x => x.Id);


            modelBuilder.Entity<GeneratorRutina>()
            .HasOne(s => s.Utilizator)
            .WithMany(x=>x.GeneratorRutina)
            .HasForeignKey(s => s.IdUtilizator)
            .HasPrincipalKey(x => x.Id);


            modelBuilder.Entity<RutinaActiune>()
            .HasOne(s => s.Rutina)
            .WithMany()
            .HasForeignKey(s => s.IdRutina);


            modelBuilder.Entity<RutinaActiune>()
            .HasOne(s => s.Actiune)
            .WithMany()
            .HasForeignKey(s => s.IdActiune);


            modelBuilder.Entity<RutinaActiune>()
            .HasOne(s => s.Stare)
            .WithMany()
            .HasForeignKey(s => s.IdStare);




        }


    }
}
