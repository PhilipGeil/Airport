using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Airport
{
    public partial class AirportContext : DbContext
    {
        public AirportContext()
        {
        }

        public AirportContext(DbContextOptions<AirportContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Airline> Airlines { get; set; }
        public virtual DbSet<Airport> Airports { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Gate> Gates { get; set; }
        public virtual DbSet<Operator> Operators { get; set; }
        public virtual DbSet<Plane> Planes { get; set; }
        public virtual DbSet<Route> Routes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=Airport;Username=entity;Password=Test1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Danish_Denmark.1252");

            modelBuilder.Entity<Airline>(entity =>
            {
                entity.ToTable("airlines");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Airport>(entity =>
            {
                entity.ToTable("airports");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.Iata)
                    .IsRequired()
                    .HasColumnName("iata");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Airports)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("airports_city_id_fkey");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Airports)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("airports_country_id_fkey");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("cities");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cities_country_id_fkey");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("countries");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Shortcode)
                    .IsRequired()
                    .HasColumnName("shortcode");
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.ToTable("flights");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Arrival)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("arrival");

                entity.Property(e => e.Departure)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("departure");

                entity.Property(e => e.GateId).HasColumnName("gate_id");

                entity.Property(e => e.RouteId).HasColumnName("route_id");

                entity.HasOne(d => d.Gate)
                    .WithMany(p => p.Flights)
                    .HasForeignKey(d => d.GateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("flights_gate_id_fkey");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.Flights)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("flights_route_id_fkey");
            });

            modelBuilder.Entity<Gate>(entity =>
            {
                entity.ToTable("gates");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Airport).HasColumnName("airport");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.HasOne(d => d.AirportNavigation)
                    .WithMany(p => p.Gates)
                    .HasForeignKey(d => d.Airport)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("gates_airport_fkey");
            });

            modelBuilder.Entity<Operator>(entity =>
            {
                entity.HasKey(e => new { e.RouteId, e.AirlineId })
                    .HasName("operators_pkey");

                entity.ToTable("operators");

                entity.Property(e => e.RouteId).HasColumnName("route_id");

                entity.Property(e => e.AirlineId).HasColumnName("airline_id");

                entity.HasOne(d => d.Airline)
                    .WithMany(p => p.Operators)
                    .HasForeignKey(d => d.AirlineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("operators_airline_id_fkey");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.Operators)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("operators_route_id_fkey");
            });

            modelBuilder.Entity<Plane>(entity =>
            {
                entity.ToTable("planes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Owner).HasColumnName("owner");

                entity.HasOne(d => d.OwnerNavigation)
                    .WithMany(p => p.Planes)
                    .HasForeignKey(d => d.Owner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("planes_owner_fkey");
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.ToTable("routes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DestinationAirport).HasColumnName("destination_airport");

                entity.Property(e => e.FromAirport).HasColumnName("from_airport");

                entity.Property(e => e.Owner).HasColumnName("owner");

                entity.HasOne(d => d.DestinationAirportNavigation)
                    .WithMany(p => p.RouteDestinationAirportNavigations)
                    .HasForeignKey(d => d.DestinationAirport)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("routes_destination_airport_fkey");

                entity.HasOne(d => d.FromAirportNavigation)
                    .WithMany(p => p.RouteFromAirportNavigations)
                    .HasForeignKey(d => d.FromAirport)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("routes_from_airport_fkey");

                entity.HasOne(d => d.OwnerNavigation)
                    .WithMany(p => p.Routes)
                    .HasForeignKey(d => d.Owner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("routes_owner_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
