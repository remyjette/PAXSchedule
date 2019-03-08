using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PAXScheduler.Models.Gudebook
{
    public partial class GuidebookContext : DbContext
    {
        public GuidebookContext()
        {
        }

        public GuidebookContext(DbContextOptions<GuidebookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GuidebookEvent> GuidebookEvent { get; set; }
        public virtual DbSet<GuidebookEventLocation> GuidebookEventLocation { get; set; }
        public virtual DbSet<GuidebookEventOccurrences> GuidebookEventOccurrences { get; set; }
        public virtual DbSet<GuidebookEventScheduleTrack> GuidebookEventScheduleTrack { get; set; }
        public virtual DbSet<GuidebookExternalapp> GuidebookExternalapp { get; set; }
        public virtual DbSet<GuidebookGuide> GuidebookGuide { get; set; }
        public virtual DbSet<GuidebookLocation> GuidebookLocation { get; set; }
        public virtual DbSet<GuidebookLocationMapInfo> GuidebookLocationMapInfo { get; set; }
        public virtual DbSet<GuidebookLocationMetadata> GuidebookLocationMetadata { get; set; }
        public virtual DbSet<GuidebookMap> GuidebookMap { get; set; }
        public virtual DbSet<GuidebookMapregion> GuidebookMapregion { get; set; }
        public virtual DbSet<GuidebookMenuitem> GuidebookMenuitem { get; set; }
        public virtual DbSet<GuidebookOccurrence> GuidebookOccurrence { get; set; }
        public virtual DbSet<GuidebookOptions> GuidebookOptions { get; set; }
        public virtual DbSet<GuidebookPoi> GuidebookPoi { get; set; }
        public virtual DbSet<GuidebookPoiCategory> GuidebookPoiCategory { get; set; }
        public virtual DbSet<GuidebookPoiLocation> GuidebookPoiLocation { get; set; }
        public virtual DbSet<GuidebookPoicategory1> GuidebookPoicategory1 { get; set; }
        public virtual DbSet<GuidebookSchedule> GuidebookSchedule { get; set; }
        public virtual DbSet<GuidebookSponsor> GuidebookSponsor { get; set; }
        public virtual DbSet<GuidebookTour> GuidebookTour { get; set; }
        public virtual DbSet<GuidebookTourMedia> GuidebookTourMedia { get; set; }
        public virtual DbSet<GuidebookTourMediatrack> GuidebookTourMediatrack { get; set; }
        public virtual DbSet<GuidebookTourstop> GuidebookTourstop { get; set; }
        public virtual DbSet<GuidebookTourstopPoint> GuidebookTourstopPoint { get; set; }
        public virtual DbSet<GuidebookTourstopimage> GuidebookTourstopimage { get; set; }
        public virtual DbSet<GuidebookVenue> GuidebookVenue { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "3.0.0-preview3.19153.1");

            modelBuilder.Entity<GuidebookEvent>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<GuidebookEventLocation>(entity =>
            {
                entity.HasIndex(e => new { e.EventId, e.LocationId })
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<GuidebookEventOccurrences>(entity =>
            {
                entity.HasIndex(e => new { e.EventId, e.OccurrenceId })
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<GuidebookEventScheduleTrack>(entity =>
            {
                entity.HasIndex(e => new { e.EventId, e.ScheduleId })
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<GuidebookExternalapp>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<GuidebookGuide>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<GuidebookLocation>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<GuidebookLocationMapInfo>(entity =>
            {
                entity.HasIndex(e => new { e.LocationId, e.MapId })
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<GuidebookLocationMetadata>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<GuidebookMap>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<GuidebookMapregion>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<GuidebookMenuitem>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<GuidebookOccurrence>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<GuidebookOptions>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<GuidebookPoi>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<GuidebookPoiCategory>(entity =>
            {
                entity.HasIndex(e => new { e.PoiId, e.PoicategoryId })
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<GuidebookPoiLocation>(entity =>
            {
                entity.HasIndex(e => new { e.PoiId, e.LocationId })
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<GuidebookPoicategory1>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<GuidebookSchedule>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<GuidebookSponsor>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<GuidebookTour>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.GpsDisabled).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<GuidebookTourMedia>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.TourStop)
                    .WithMany(p => p.GuidebookTourMedia)
                    .HasForeignKey(d => d.TourStopId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Track)
                    .WithMany(p => p.GuidebookTourMedia)
                    .HasForeignKey(d => d.TrackId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<GuidebookTourMediatrack>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.GuidebookTourMediatrack)
                    .HasForeignKey(d => d.TourId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<GuidebookTourstop>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<GuidebookTourstopPoint>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<GuidebookTourstopimage>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<GuidebookVenue>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });
        }
    }
}
