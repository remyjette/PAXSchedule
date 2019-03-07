using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PAXScheduler.GuidebookModels
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
        public virtual DbSet<SearchContent> SearchContent { get; set; }
        public virtual DbSet<SearchSegdir> SearchSegdir { get; set; }
        public virtual DbSet<SearchSegments> SearchSegments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuidebookEvent>(entity =>
            {
                entity.ToTable("guidebook_event");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddToSchedule)
                    .HasColumnName("addToSchedule")
                    .HasColumnType("bool");

                entity.Property(e => e.Allday)
                    .HasColumnName("allday")
                    .HasColumnType("bool");

                entity.Property(e => e.AllowRating)
                    .HasColumnName("allowRating")
                    .HasColumnType("bool");

                entity.Property(e => e.CogDetails)
                    .HasColumnName("cog_details")
                    .HasColumnType("longtext");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasColumnType("bool");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.EndTime)
                    .HasColumnName("endTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.GuideId).HasColumnName("guide_id");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ImportId)
                    .HasColumnName("import_id")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("last_updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.Links)
                    .HasColumnName("links")
                    .HasColumnType("longtext");

                entity.Property(e => e.Locations).HasColumnName("locations");

                entity.Property(e => e.MaxCapacity).HasColumnName("max_capacity");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Rank).HasColumnName("rank");

                entity.Property(e => e.RegisteredAttendees).HasColumnName("registered_attendees");

                entity.Property(e => e.RegistrationStartDate)
                    .HasColumnName("registration_start_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RequireLogin)
                    .HasColumnName("require_login")
                    .HasColumnType("bool");

                entity.Property(e => e.StartTime)
                    .HasColumnName("startTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Tracks).HasColumnName("tracks");

                entity.Property(e => e.Waitlist)
                    .HasColumnName("waitlist")
                    .HasColumnType("bool");
            });

            modelBuilder.Entity<GuidebookEventLocation>(entity =>
            {
                entity.ToTable("guidebook_event_location");

                entity.HasIndex(e => new { e.EventId, e.LocationId })
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.LocationId).HasColumnName("location_id");
            });

            modelBuilder.Entity<GuidebookEventOccurrences>(entity =>
            {
                entity.ToTable("guidebook_event_occurrences");

                entity.HasIndex(e => new { e.EventId, e.OccurrenceId })
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("integer AUTO_INCREMENT")
                    .ValueGeneratedNever();

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.OccurrenceId).HasColumnName("occurrence_id");
            });

            modelBuilder.Entity<GuidebookEventScheduleTrack>(entity =>
            {
                entity.ToTable("guidebook_event_scheduleTrack");

                entity.HasIndex(e => new { e.EventId, e.ScheduleId })
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.ScheduleId).HasColumnName("schedule_id");
            });

            modelBuilder.Entity<GuidebookExternalapp>(entity =>
            {
                entity.ToTable("guidebook_externalapp");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AndroidIntentActivityPath)
                    .HasColumnName("android_intent_activity_path")
                    .HasColumnType("CHAR");

                entity.Property(e => e.GuideId).HasColumnName("guide_id");

                entity.Property(e => e.IOsUrl)
                    .HasColumnName("iOS_url")
                    .HasColumnType("CHAR");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("CHAR");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasColumnType("CHAR");
            });

            modelBuilder.Entity<GuidebookGuide>(entity =>
            {
                entity.ToTable("guidebook_guide");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BundleVersion).HasColumnName("bundleVersion");

                entity.Property(e => e.CogDetails)
                    .HasColumnName("cog_details")
                    .HasColumnType("longtext");

                entity.Property(e => e.Cover)
                    .HasColumnName("cover")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.EndDate)
                    .HasColumnName("endDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.GuideVersion).HasColumnName("guideVersion");

                entity.Property(e => e.Icon)
                    .HasColumnName("icon")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.IconRaw)
                    .HasColumnName("iconRaw")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.InviteOnly)
                    .HasColumnName("inviteOnly")
                    .HasColumnType("bool");

                entity.Property(e => e.IsPreview)
                    .HasColumnName("isPreview")
                    .HasColumnType("bool");

                entity.Property(e => e.LoginRequired)
                    .HasColumnName("loginRequired")
                    .HasColumnType("bool");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(58)");

                entity.Property(e => e.OwnerId).HasColumnName("owner_id");

                entity.Property(e => e.ProductIdentifier)
                    .HasColumnName("productIdentifier")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Rank).HasColumnName("rank");

                entity.Property(e => e.ShortName)
                    .HasColumnName("shortName")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.StartDate)
                    .HasColumnName("startDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ThemeId).HasColumnName("theme_id");

                entity.Property(e => e.Timezone)
                    .HasColumnName("timezone")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("updateDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<GuidebookLocation>(entity =>
            {
                entity.ToTable("guidebook_location");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasColumnType("bool");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.GuideId).HasColumnName("guide_id");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ImportId)
                    .HasColumnName("import_id")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("last_updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.LocType)
                    .HasColumnName("locType")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.MapRef).HasColumnName("mapRef");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.VenueId).HasColumnName("venue_id");
            });

            modelBuilder.Entity<GuidebookLocationMapInfo>(entity =>
            {
                entity.ToTable("guidebook_location_mapInfo");

                entity.HasIndex(e => new { e.LocationId, e.MapId })
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.MapId).HasColumnName("map_id");
            });

            modelBuilder.Entity<GuidebookLocationMetadata>(entity =>
            {
                entity.ToTable("guidebook_location_metadata");

                entity.HasIndex(e => e.Id)
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.LocId).HasColumnName("loc_id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.ObjId).HasColumnName("obj_id");

                entity.Property(e => e.ObjType).HasColumnName("obj_type");

                entity.Property(e => e.Url).HasColumnName("url");
            });

            modelBuilder.Entity<GuidebookMap>(entity =>
            {
                entity.ToTable("guidebook_map");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasColumnType("bool");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.GuideId).HasColumnName("guide_id");

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ImportId)
                    .HasColumnName("import_id")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("last_updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.LevelsOfDetails).HasColumnName("levels_of_details");

                entity.Property(e => e.MapType)
                    .HasColumnName("mapType")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Rank).HasColumnName("rank");

                entity.Property(e => e.Source)
                    .HasColumnName("source")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.TileSize).HasColumnName("tile_size");

                entity.Property(e => e.Width).HasColumnName("width");
            });

            modelBuilder.Entity<GuidebookMapregion>(entity =>
            {
                entity.ToTable("guidebook_mapregion");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.GuideId).HasColumnName("guide_id");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.MapId).HasColumnName("map_id");

                entity.Property(e => e.RelativeHeight)
                    .HasColumnName("relative_height")
                    .HasColumnType("double precision");

                entity.Property(e => e.RelativeWidth)
                    .HasColumnName("relative_width")
                    .HasColumnType("double precision");

                entity.Property(e => e.RelativeX)
                    .HasColumnName("relative_x")
                    .HasColumnType("double precision");

                entity.Property(e => e.RelativeY)
                    .HasColumnName("relative_y")
                    .HasColumnType("double precision");
            });

            modelBuilder.Entity<GuidebookMenuitem>(entity =>
            {
                entity.ToTable("guidebook_menuitem");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DisplayOptions).HasColumnName("display_options");

                entity.Property(e => e.GuideId).HasColumnName("guide_id");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("last_updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.Purpose)
                    .HasColumnName("purpose")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Rank).HasColumnName("rank");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasColumnType("varchar(1023)");

                entity.HasOne(d => d.Guide)
                    .WithMany(p => p.GuidebookMenuitem)
                    .HasForeignKey(d => d.GuideId);
            });

            modelBuilder.Entity<GuidebookOccurrence>(entity =>
            {
                entity.ToTable("guidebook_occurrence");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("integer AUTO_INCREMENT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Allday)
                    .IsRequired()
                    .HasColumnName("allday")
                    .HasColumnType("bool");

                entity.Property(e => e.EndTime)
                    .HasColumnName("endTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.StartTime)
                    .HasColumnName("startTime")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<GuidebookOptions>(entity =>
            {
                entity.ToTable("guidebook_options");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Key)
                    .HasColumnName("key")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<GuidebookPoi>(entity =>
            {
                entity.ToTable("guidebook_poi");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddToDo)
                    .HasColumnName("addToDo")
                    .HasColumnType("bool");

                entity.Property(e => e.AllowRating)
                    .HasColumnName("allowRating")
                    .HasColumnType("bool");

                entity.Property(e => e.Categories).HasColumnName("categories");

                entity.Property(e => e.CogDetails)
                    .HasColumnName("cog_details")
                    .HasColumnType("longtext");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasColumnType("bool");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.GuideId).HasColumnName("guide_id");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ImportId)
                    .HasColumnName("import_id")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Label)
                    .HasColumnName("label")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("last_updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.LinkImage)
                    .HasColumnName("link_image")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Links)
                    .HasColumnName("links")
                    .HasColumnType("longtext");

                entity.Property(e => e.Locations).HasColumnName("locations");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Rank).HasColumnName("rank");

                entity.Property(e => e.Subimage)
                    .HasColumnName("subimage")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Thumbnail)
                    .HasColumnName("thumbnail")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<GuidebookPoiCategory>(entity =>
            {
                entity.ToTable("guidebook_poi_category");

                entity.HasIndex(e => new { e.PoiId, e.PoicategoryId })
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.PoiId).HasColumnName("poi_id");

                entity.Property(e => e.PoicategoryId).HasColumnName("poicategory_id");

                entity.Property(e => e.Rank)
                    .HasColumnName("rank")
                    .HasColumnType("double precision");
            });

            modelBuilder.Entity<GuidebookPoiLocation>(entity =>
            {
                entity.ToTable("guidebook_poi_location");

                entity.HasIndex(e => new { e.PoiId, e.LocationId })
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.PoiId).HasColumnName("poi_id");
            });

            modelBuilder.Entity<GuidebookPoicategory1>(entity =>
            {
                entity.ToTable("guidebook_poicategory");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.GuideId).HasColumnName("guide_id");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("last_updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.Guide)
                    .WithMany(p => p.GuidebookPoicategory1)
                    .HasForeignKey(d => d.GuideId);
            });

            modelBuilder.Entity<GuidebookSchedule>(entity =>
            {
                entity.ToTable("guidebook_schedule");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Color)
                    .HasColumnName("color")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasColumnType("bool");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.GuideId).HasColumnName("guide_id");

                entity.Property(e => e.HexValue)
                    .HasColumnName("hexValue")
                    .HasColumnType("varchar(47)");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("last_updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.Guide)
                    .WithMany(p => p.GuidebookSchedule)
                    .HasForeignKey(d => d.GuideId);
            });

            modelBuilder.Entity<GuidebookSponsor>(entity =>
            {
                entity.ToTable("guidebook_sponsor");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasColumnType("bool");

                entity.Property(e => e.GuideId).HasColumnName("guide_id");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ImportId)
                    .HasColumnName("import_id")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("last_updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Weight).HasColumnName("weight");
            });

            modelBuilder.Entity<GuidebookTour>(entity =>
            {
                entity.ToTable("guidebook_tour");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ConcludingMessage).HasColumnName("concluding_message");

                entity.Property(e => e.ConclusionActionMenuitemId1).HasColumnName("conclusion_action_menuitem_id_1");

                entity.Property(e => e.ConclusionActionMenuitemId2).HasColumnName("conclusion_action_menuitem_id_2");

                entity.Property(e => e.Cover)
                    .HasColumnName("cover")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.GpsDisabled)
                    .IsRequired()
                    .HasColumnName("gps_disabled")
                    .HasColumnType("bool")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.GuideId).HasColumnName("guide_id");

                entity.Property(e => e.Headline)
                    .HasColumnName("headline")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.HeadlineDescription).HasColumnName("headline_description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.Guide)
                    .WithMany(p => p.GuidebookTour)
                    .HasForeignKey(d => d.GuideId);
            });

            modelBuilder.Entity<GuidebookTourMedia>(entity =>
            {
                entity.ToTable("guidebook_tour_media");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FileSize).HasColumnName("file_size");

                entity.Property(e => e.Media)
                    .IsRequired()
                    .HasColumnName("media")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.PlaysEnroute)
                    .HasColumnName("plays_enroute")
                    .HasColumnType("bool");

                entity.Property(e => e.TourStopId).HasColumnName("tour_stop_id");

                entity.Property(e => e.TourStopPointId).HasColumnName("tour_stop_point_id");

                entity.Property(e => e.TrackId).HasColumnName("track_id");

                entity.HasOne(d => d.TourStop)
                    .WithMany(p => p.GuidebookTourMedia)
                    .HasForeignKey(d => d.TourStopId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.TourStopPoint)
                    .WithMany(p => p.GuidebookTourMedia)
                    .HasForeignKey(d => d.TourStopPointId);

                entity.HasOne(d => d.Track)
                    .WithMany(p => p.GuidebookTourMedia)
                    .HasForeignKey(d => d.TrackId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<GuidebookTourMediatrack>(entity =>
            {
                entity.ToTable("guidebook_tour_mediatrack");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.TourId).HasColumnName("tour_id");

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.GuidebookTourMediatrack)
                    .HasForeignKey(d => d.TourId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<GuidebookTourstop>(entity =>
            {
                entity.ToTable("guidebook_tourstop");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasColumnType("double precision");

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasColumnType("double precision");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Rank)
                    .HasColumnName("rank")
                    .HasColumnType("double precision");

                entity.Property(e => e.TourId).HasColumnName("tour_id");

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.GuidebookTourstop)
                    .HasForeignKey(d => d.TourId);
            });

            modelBuilder.Entity<GuidebookTourstopPoint>(entity =>
            {
                entity.ToTable("guidebook_tourstop_point");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasColumnType("double precision");

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasColumnType("double precision");

                entity.Property(e => e.Rank)
                    .HasColumnName("rank")
                    .HasColumnType("double precision");

                entity.Property(e => e.StopId).HasColumnName("stop_id");

                entity.HasOne(d => d.Stop)
                    .WithMany(p => p.GuidebookTourstopPoint)
                    .HasForeignKey(d => d.StopId);
            });

            modelBuilder.Entity<GuidebookTourstopimage>(entity =>
            {
                entity.ToTable("guidebook_tourstopimage");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnName("image")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Rank)
                    .HasColumnName("rank")
                    .HasColumnType("double precision");

                entity.Property(e => e.StopId).HasColumnName("stop_id");

                entity.HasOne(d => d.Stop)
                    .WithMany(p => p.GuidebookTourstopimage)
                    .HasForeignKey(d => d.StopId);
            });

            modelBuilder.Entity<GuidebookVenue>(entity =>
            {
                entity.ToTable("guidebook_venue");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.GuideId).HasColumnName("guide_id");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("last_updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Street)
                    .HasColumnName("street")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Zipcode)
                    .HasColumnName("zipcode")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Zoom).HasColumnName("zoom");

                entity.HasOne(d => d.Guide)
                    .WithMany(p => p.GuidebookVenue)
                    .HasForeignKey(d => d.GuideId);
            });

            modelBuilder.Entity<SearchContent>(entity =>
            {
                entity.HasKey(e => e.Docid);

                entity.ToTable("search_content");

                entity.Property(e => e.Docid)
                    .HasColumnName("docid")
                    .ValueGeneratedNever();

                entity.Property(e => e.C0title).HasColumnName("c0title");

                entity.Property(e => e.C1label).HasColumnName("c1label");

                entity.Property(e => e.C2description).HasColumnName("c2description");

                entity.Property(e => e.C3locations).HasColumnName("c3locations");

                entity.Property(e => e.C4category).HasColumnName("c4category");

                entity.Property(e => e.C5track).HasColumnName("c5track");
            });

            modelBuilder.Entity<SearchSegdir>(entity =>
            {
                entity.HasKey(e => new { e.Level, e.Idx });

                entity.ToTable("search_segdir");

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.Idx).HasColumnName("idx");

                entity.Property(e => e.EndBlock).HasColumnName("end_block");

                entity.Property(e => e.LeavesEndBlock).HasColumnName("leaves_end_block");

                entity.Property(e => e.Root).HasColumnName("root");

                entity.Property(e => e.StartBlock).HasColumnName("start_block");
            });

            modelBuilder.Entity<SearchSegments>(entity =>
            {
                entity.HasKey(e => e.Blockid);

                entity.ToTable("search_segments");

                entity.Property(e => e.Blockid)
                    .HasColumnName("blockid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Block).HasColumnName("block");
            });
        }
    }
}
