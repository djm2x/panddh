using Microsoft.EntityFrameworkCore;
using seed;

namespace Models
{
    public partial class AdminContext : DbContext
    {
        public AdminContext()
        {
            // dotnet tool install -g dotnet-aspnet-codegenerator
            // dotnet tool update -g dotnet-aspnet-codegenerator
            // dotnet aspnet-codegenerator --project . controller -name HelloController -m Author -dc WebAPIDataContext
            // dotnet tool install --global dotnet-ef --version 3.0.0
            // scafolding to db
            // dotnet ef migrations add Initial --context MyContext
            // dotnet ef database update
            // dotnet ef migrations remove
            // dotnet ef database update LastGoodMigration
            // dotnet ef migrations script
        }

        public AdminContext(DbContextOptions<AdminContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Organisme> Organismes { get; set; }
        public virtual DbSet<Mesure> Mesures { get; set; }
        public virtual DbSet<Profil> Profils { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Axe> Axes { get; set; }
        public virtual DbSet<SousAxe> SousAxes { get; set; }
        public virtual DbSet<Cycle> Cycles { get; set; }
        public virtual DbSet<Nature> Natures { get; set; }
        public virtual DbSet<Realisation> Realisations { get; set; }
        public virtual DbSet<Activite> Activites { get; set; }
        public virtual DbSet<Indicateur> Indicateurs { get; set; }
        public virtual DbSet<Partenariat> Partenariats { get; set; }
        public virtual DbSet<IndicateurMesure> IndicateurMesures { get; set; }
        public virtual DbSet<IndicateurMesureValue> IndicateurMesureValues { get; set; }
        public virtual DbSet<Commission> Commissions { get; set; }
        public virtual DbSet<MembreCommission> MembreCommissions { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        // public virtual DbSet<IndicateurRealisation> IndicateurRealisations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organisme>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Adresse);
                entity.Property(e => e.Label);
                entity.Property(e => e.Type);
                entity.Property(e => e.Tel);
                entity.HasMany(d => d.Partenariats).WithOne(p => p.Organisme).HasForeignKey(d => d.IdOrganisme);
            });

            modelBuilder.Entity<Profil>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Label);
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IdProfil);
                entity.Property(e => e.Action);
                entity.Property(e => e.RouteScreen);
                entity.Property(e => e.RouteScreenAr);

                entity.HasOne(e => e.Profil).WithMany(e => e.Permissions).HasForeignKey(e => e.IdProfil);
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.IdConcerner).IsRequired();
                entity.Property(e => e.TableConcerner).IsRequired();
                entity.Property(e => e.Message).IsRequired();
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.Destinataire).IsRequired();
                entity.Property(e => e.Vu).IsRequired();
                entity.Property(e => e.Priorite).IsRequired();
            });

            modelBuilder.Entity<Cycle>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Label);
                entity.HasMany(d => d.Mesures).WithOne(p => p.Cycle).HasForeignKey(d => d.IdCycle)
                // .OnDelete(DeleteBehavior.Cascade)
                ;
            });

            modelBuilder.Entity<Nature>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Label);
                entity.HasMany(d => d.Mesures).WithOne(p => p.Nature).HasForeignKey(d => d.IdNature)
                // .OnDelete(DeleteBehavior.Cascade)
                ;
            });

            modelBuilder.Entity<Axe>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Label);
                entity.HasMany(d => d.Mesures).WithOne(p => p.Axe).HasForeignKey(d => d.IdAxe)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(d => d.SousAxes).WithOne(p => p.Axe).HasForeignKey(d => d.IdAxe)
                // .OnDelete(DeleteBehavior.Cascade)
                ;
            });

            modelBuilder.Entity<SousAxe>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Label);
                entity.Property(e => e.IdAxe);
                entity.HasOne(d => d.Axe).WithMany(p => p.SousAxes).HasForeignKey(d => d.IdAxe);
                entity.HasMany(d => d.Mesures).WithOne(p => p.SousAxe).HasForeignKey(d => d.IdSousAxe)
                ;
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Actif);
                entity.Property(e => e.Adresse).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.Fix).IsRequired();
                entity.Property(e => e.Nom).IsRequired();
                entity.Property(e => e.IdOrganisme).IsRequired();
                entity.Property(e => e.Password).IsRequired();
                entity.Property(e => e.Prenom).IsRequired();
                entity.Property(e => e.IdProfil).IsRequired();
                entity.Property(e => e.Tel).IsRequired();
                entity.Property(e => e.Username).IsRequired();
                entity.HasOne(d => d.Organisme).WithMany(p => p.Users).HasForeignKey(d => d.IdOrganisme);
                entity.HasOne(d => d.Profil).WithMany(p => p.Users).HasForeignKey(d => d.IdProfil);
                entity.HasMany(d => d.Mesures).WithOne(p => p.Responsable).HasForeignKey(d => d.IdResponsable)
                .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Mesure>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Code);
                entity.Property(e => e.Nom);
                entity.Property(e => e.IdType);
                entity.Property(e => e.IdResponsable);
                entity.Property(e => e.IdAxe);
                entity.Property(e => e.IdSousAxe);
                entity.Property(e => e.IdCycle);
                entity.Property(e => e.ResultatsAttendu);
                entity.Property(e => e.ObjectifGlobal);
                entity.Property(e => e.ObjectifSpeciaux);
                entity.HasOne(d => d.SousAxe).WithMany(p => p.Mesures).HasForeignKey(d => d.IdSousAxe)
               .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Indicateur>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Nom);
                entity.Property(e => e.Source);
            });

            modelBuilder.Entity<Partenariat>(entity =>
            {
                entity.HasKey(e => new { e.IdMesure, e.IdOrganisme });


                entity.HasOne(d => d.Mesure).WithMany(p => p.Partenariats).HasForeignKey(d => d.IdMesure);
                entity.HasOne(d => d.Organisme).WithMany(p => p.Partenariats).HasForeignKey(d => d.IdOrganisme);
            });

            modelBuilder.Entity<IndicateurMesure>(entity =>
            {
                entity.HasKey(e => new { e.IdMesure, e.IdIndicateur });

                entity.HasOne(d => d.Mesure).WithMany(p => p.IndicateurMesures).HasForeignKey(d => d.IdMesure);
                entity.HasOne(d => d.Indicateur).WithMany(p => p.IndicateurMesures).HasForeignKey(d => d.IdIndicateur);
            });

            modelBuilder.Entity<IndicateurMesureValue>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IdMesure);
                entity.Property(e => e.IdIndicateur);
                entity.Property(e => e.Value);
                entity.Property(e => e.Date);
                entity.HasOne(d => d.Mesure).WithMany(p => p.IndicateurMesureValues).HasForeignKey(d => d.IdMesure);
                entity.HasOne(d => d.Indicateur).WithMany(p => p.IndicateurMesureValues).HasForeignKey(d => d.IdIndicateur);
            });

            // modelBuilder.Entity<IndicateurRealisation>(entity =>
            // {
            //     entity.HasKey(e => new { e.IdRealisation, e.IdIndicateur });


            //     entity.Property(e => e.Date);
            //     entity.HasOne(d => d.Realisation).WithMany(p => p.IndicateurRealisations).HasForeignKey(d => d.IdRealisation);
            //     entity.HasOne(d => d.Indicateur).WithMany(p => p.IndicateurRealisations).HasForeignKey(d => d.IdIndicateur);
            // });

            modelBuilder.Entity<Realisation>(entity =>
           {
               entity.HasKey(e => e.Id);
               entity.Property(e => e.Id).ValueGeneratedOnAdd();

               entity.Property(e => e.Nom);
               entity.Property(e => e.Situation);
               entity.Property(e => e.Annee);
               entity.Property(e => e.Taux);
               entity.Property(e => e.Effet);
               entity.Property(e => e.IdActivite);

               entity.HasOne(d => d.Activite).WithMany(p => p.Realisations).HasForeignKey(d => d.IdActivite);
           });

            modelBuilder.Entity<Activite>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Nom);
                entity.Property(e => e.Duree);
                entity.Property(e => e.IdMesure);

                entity.HasOne(d => d.Mesure).WithMany(p => p.Activites).HasForeignKey(d => d.IdMesure);
            });

            modelBuilder.Entity<Commission>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Type);
                entity.Property(e => e.Pv);
                entity.Property(e => e.DateEvenement);
            });

            modelBuilder.Entity<MembreCommission>(entity =>
           {
               entity.HasKey(e => e.Id);
               entity.Property(e => e.Id).ValueGeneratedOnAdd();

               entity.Property(e => e.NomComplete);
               entity.Property(e => e.Email);
               entity.HasOne(d => d.Commission).WithMany(p => p.MembreCommissions).HasForeignKey(d => d.IdCommission);
           });

            OnModelCreatingPartial(modelBuilder);

            modelBuilder
                .Profils()
            .Permissions()
            .Organismes()
            .Users()
            .Axes()
            .SousAxes()
            .Cycles()
            .Natures()
            .Indicateurs()
            .Mesures()
            .Activites()
            .Realisations()
            .Commissions()
            .MembreCommissions()
            .IndicateurMesureValues()
            .IndicateurMesures()
            ;



        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
