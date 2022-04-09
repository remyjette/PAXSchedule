using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PAXSchedule.Models.Gudebook
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

        public virtual DbSet<GuidebookEvent> GuidebookEvents { get; set; } = null!;
        public virtual DbSet<GuidebookEventLocation> GuidebookEventLocations { get; set; } = null!;
        public virtual DbSet<GuidebookEventOccurrence> GuidebookEventOccurrences { get; set; } = null!;
        public virtual DbSet<GuidebookEventScheduleTrack> GuidebookEventScheduleTracks { get; set; } = null!;
        public virtual DbSet<GuidebookExternalapp> GuidebookExternalapps { get; set; } = null!;
        public virtual DbSet<GuidebookGuide> GuidebookGuides { get; set; } = null!;
        public virtual DbSet<GuidebookLocation> GuidebookLocations { get; set; } = null!;
        public virtual DbSet<GuidebookLocationMapInfo> GuidebookLocationMapInfos { get; set; } = null!;
        public virtual DbSet<GuidebookLocationMetadatum> GuidebookLocationMetadata { get; set; } = null!;
        public virtual DbSet<GuidebookMap> GuidebookMaps { get; set; } = null!;
        public virtual DbSet<GuidebookMapregion> GuidebookMapregions { get; set; } = null!;
        public virtual DbSet<GuidebookMenuitem> GuidebookMenuitems { get; set; } = null!;
        public virtual DbSet<GuidebookOccurrence> GuidebookOccurrences { get; set; } = null!;
        public virtual DbSet<GuidebookOption> GuidebookOptions { get; set; } = null!;
        public virtual DbSet<GuidebookPoi> GuidebookPois { get; set; } = null!;
        public virtual DbSet<GuidebookPoiCategory> GuidebookPoiCategories { get; set; } = null!;
        public virtual DbSet<GuidebookPoiLocation> GuidebookPoiLocations { get; set; } = null!;
        public virtual DbSet<GuidebookPoicategory1> GuidebookPoicategories1 { get; set; } = null!;
        public virtual DbSet<GuidebookSchedule> GuidebookSchedules { get; set; } = null!;
        public virtual DbSet<GuidebookSponsor> GuidebookSponsors { get; set; } = null!;
        public virtual DbSet<GuidebookTour> GuidebookTours { get; set; } = null!;
        public virtual DbSet<GuidebookTourMediatrack> GuidebookTourMediatracks { get; set; } = null!;
        public virtual DbSet<GuidebookTourMedium> GuidebookTourMedia { get; set; } = null!;
        public virtual DbSet<GuidebookTourstop> GuidebookTourstops { get; set; } = null!;
        public virtual DbSet<GuidebookTourstopPoint> GuidebookTourstopPoints { get; set; } = null!;
        public virtual DbSet<GuidebookTourstopimage> GuidebookTourstopimages { get; set; } = null!;
        public virtual DbSet<GuidebookVenue> GuidebookVenues { get; set; } = null!;
        public virtual DbSet<SchemaInfo> SchemaInfos { get; set; } = null!;
        public virtual DbSet<Search> Searches { get; set; } = null!;
        public virtual DbSet<SearchContent> SearchContents { get; set; } = null!;
        public virtual DbSet<SearchMetum> SearchMeta { get; set; } = null!;
        public virtual DbSet<SearchSegdir> SearchSegdirs { get; set; } = null!;
        public virtual DbSet<SearchSegment> SearchSegments { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuidebookEvent>(entity =>
            {
                entity.ToTable("guidebook_event");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AddToSchedule)
                    .HasColumnType("bool")
                    .HasColumnName("addToSchedule");

                entity.Property(e => e.Allday)
                    .HasColumnType("bool")
                    .HasColumnName("allday");

                entity.Property(e => e.AllowRating)
                    .HasColumnType("bool")
                    .HasColumnName("allowRating");

                entity.Property(e => e.CogDetails)
                    .HasColumnType("longtext")
                    .HasColumnName("cog_details");

                entity.Property(e => e.Deleted)
                    .HasColumnType("bool")
                    .HasColumnName("deleted");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("endTime");

                entity.Property(e => e.GuideId)
                    .HasColumnType("integer")
                    .HasColumnName("guide_id");

                entity.Property(e => e.Image)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("image");

                entity.Property(e => e.ImportId)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("import_id");

                entity.Property(e => e.LastUpdated)
                    .HasColumnType("datetime")
                    .HasColumnName("last_updated");

                entity.Property(e => e.Links)
                    .HasColumnType("longtext")
                    .HasColumnName("links");

                entity.Property(e => e.Locations)
                    .HasColumnType("text")
                    .HasColumnName("locations");

                entity.Property(e => e.MaxCapacity)
                    .HasColumnType("integer")
                    .HasColumnName("max_capacity");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("name");

                entity.Property(e => e.Rank)
                    .HasColumnType("integer")
                    .HasColumnName("rank");

                entity.Property(e => e.RegisteredAttendees)
                    .HasColumnType("integer")
                    .HasColumnName("registered_attendees");

                entity.Property(e => e.RegistrationStartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("registration_start_date");

                entity.Property(e => e.RequireLogin)
                    .HasColumnType("bool")
                    .HasColumnName("require_login");

                entity.Property(e => e.SessionDiscussionPostingDisabled)
                    .HasColumnType("bool")
                    .HasColumnName("session_discussion_posting_disabled");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("startTime");

                entity.Property(e => e.Tracks)
                    .HasColumnType("text")
                    .HasColumnName("tracks");

                entity.Property(e => e.Waitlist)
                    .HasColumnType("bool")
                    .HasColumnName("waitlist");
            });

            modelBuilder.Entity<GuidebookEventLocation>(entity =>
            {
                entity.ToTable("guidebook_event_location");

                entity.HasIndex(e => new { e.EventId, e.LocationId }, "IX_guidebook_event_location_event_id_location_id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.EventId)
                    .HasColumnType("integer")
                    .HasColumnName("event_id");

                entity.Property(e => e.LocationId)
                    .HasColumnType("integer")
                    .HasColumnName("location_id");
            });

            modelBuilder.Entity<GuidebookEventOccurrence>(entity =>
            {
                entity.ToTable("guidebook_event_occurrences");

                entity.HasIndex(e => new { e.EventId, e.OccurrenceId }, "IX_guidebook_event_occurrences_event_id_occurrence_id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("integer AUTO_INCREMENT")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.EventId)
                    .HasColumnType("integer")
                    .HasColumnName("event_id");

                entity.Property(e => e.OccurrenceId)
                    .HasColumnType("integer")
                    .HasColumnName("occurrence_id");
            });

            modelBuilder.Entity<GuidebookEventScheduleTrack>(entity =>
            {
                entity.ToTable("guidebook_event_scheduleTrack");

                entity.HasIndex(e => new { e.EventId, e.ScheduleId }, "IX_guidebook_event_scheduleTrack_event_id_schedule_id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.EventId)
                    .HasColumnType("integer")
                    .HasColumnName("event_id");

                entity.Property(e => e.ScheduleId)
                    .HasColumnType("integer")
                    .HasColumnName("schedule_id");
            });

            modelBuilder.Entity<GuidebookExternalapp>(entity =>
            {
                entity.ToTable("guidebook_externalapp");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AndroidIntentActivityPath)
                    .HasColumnType("CHAR")
                    .HasColumnName("android_intent_activity_path");

                entity.Property(e => e.GuideId).HasColumnName("guide_id");

                entity.Property(e => e.IOsUrl)
                    .HasColumnType("CHAR")
                    .HasColumnName("iOS_url");

                entity.Property(e => e.Name)
                    .HasColumnType("CHAR")
                    .HasColumnName("name");

                entity.Property(e => e.Url)
                    .HasColumnType("CHAR")
                    .HasColumnName("url");
            });

            modelBuilder.Entity<GuidebookGuide>(entity =>
            {
                entity.ToTable("guidebook_guide");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.BundleVersion)
                    .HasColumnType("integer")
                    .HasColumnName("bundleVersion");

                entity.Property(e => e.CogDetails)
                    .HasColumnType("longtext")
                    .HasColumnName("cog_details");

                entity.Property(e => e.Cover)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("cover");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("endDate");

                entity.Property(e => e.GuideVersion)
                    .HasColumnType("integer")
                    .HasColumnName("guideVersion");

                entity.Property(e => e.Icon)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("icon");

                entity.Property(e => e.IconRaw)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("iconRaw");

                entity.Property(e => e.Image)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("image");

                entity.Property(e => e.InviteOnly)
                    .HasColumnType("bool")
                    .HasColumnName("inviteOnly");

                entity.Property(e => e.IsPreview)
                    .HasColumnType("bool")
                    .HasColumnName("isPreview");

                entity.Property(e => e.LoginRequired)
                    .HasColumnType("bool")
                    .HasColumnName("loginRequired");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(58)")
                    .HasColumnName("name");

                entity.Property(e => e.OwnerId)
                    .HasColumnType("integer")
                    .HasColumnName("owner_id");

                entity.Property(e => e.ProductIdentifier)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("productIdentifier");

                entity.Property(e => e.Rank)
                    .HasColumnType("integer")
                    .HasColumnName("rank");

                entity.Property(e => e.ShortName)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("shortName");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("startDate");

                entity.Property(e => e.ThemeId)
                    .HasColumnType("integer")
                    .HasColumnName("theme_id");

                entity.Property(e => e.Timezone)
                    .HasColumnType("varchar(32)")
                    .HasColumnName("timezone");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updateDate");

                entity.Property(e => e.Url)
                    .HasColumnType("varchar(200)")
                    .HasColumnName("url");
            });

            modelBuilder.Entity<GuidebookLocation>(entity =>
            {
                entity.ToTable("guidebook_location");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Deleted)
                    .HasColumnType("bool")
                    .HasColumnName("deleted");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.GuideId)
                    .HasColumnType("integer")
                    .HasColumnName("guide_id");

                entity.Property(e => e.Image)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("image");

                entity.Property(e => e.ImportId)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("import_id");

                entity.Property(e => e.LastUpdated)
                    .HasColumnType("datetime")
                    .HasColumnName("last_updated");

                entity.Property(e => e.Latitude)
                    .HasColumnType("real")
                    .HasColumnName("latitude");

                entity.Property(e => e.LocType)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("locType");

                entity.Property(e => e.Longitude)
                    .HasColumnType("real")
                    .HasColumnName("longitude");

                entity.Property(e => e.MapRef)
                    .HasColumnType("text")
                    .HasColumnName("mapRef");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("name");

                entity.Property(e => e.VenueId)
                    .HasColumnType("integer")
                    .HasColumnName("venue_id");
            });

            modelBuilder.Entity<GuidebookLocationMapInfo>(entity =>
            {
                entity.ToTable("guidebook_location_mapInfo");

                entity.HasIndex(e => new { e.LocationId, e.MapId }, "IX_guidebook_location_mapInfo_location_id_map_id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.LocationId)
                    .HasColumnType("integer")
                    .HasColumnName("location_id");

                entity.Property(e => e.MapId)
                    .HasColumnType("integer")
                    .HasColumnName("map_id");
            });

            modelBuilder.Entity<GuidebookLocationMetadatum>(entity =>
            {
                entity.ToTable("guidebook_location_metadata");

                entity.HasIndex(e => e.Id, "IX_guidebook_location_metadata_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LocId).HasColumnName("loc_id");

                entity.Property(e => e.Name)
                    .HasColumnType("VARCHAR")
                    .HasColumnName("name");

                entity.Property(e => e.ObjId).HasColumnName("obj_id");

                entity.Property(e => e.ObjType).HasColumnName("obj_type");

                entity.Property(e => e.Url).HasColumnName("url");
            });

            modelBuilder.Entity<GuidebookMap>(entity =>
            {
                entity.ToTable("guidebook_map");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Deleted)
                    .HasColumnType("bool")
                    .HasColumnName("deleted");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.GuideId)
                    .HasColumnType("integer")
                    .HasColumnName("guide_id");

                entity.Property(e => e.Height)
                    .HasColumnType("integer")
                    .HasColumnName("height");

                entity.Property(e => e.Image)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("image");

                entity.Property(e => e.ImportId)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("import_id");

                entity.Property(e => e.LastUpdated)
                    .HasColumnType("datetime")
                    .HasColumnName("last_updated");

                entity.Property(e => e.LevelsOfDetails)
                    .HasColumnType("integer")
                    .HasColumnName("levels_of_details");

                entity.Property(e => e.MapType)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("mapType");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("name");

                entity.Property(e => e.Rank)
                    .HasColumnType("integer")
                    .HasColumnName("rank");

                entity.Property(e => e.Source)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("source");

                entity.Property(e => e.TileSize)
                    .HasColumnType("integer")
                    .HasColumnName("tile_size");

                entity.Property(e => e.Width)
                    .HasColumnType("integer")
                    .HasColumnName("width");
            });

            modelBuilder.Entity<GuidebookMapregion>(entity =>
            {
                entity.ToTable("guidebook_mapregion");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.GuideId)
                    .HasColumnType("integer")
                    .HasColumnName("guide_id");

                entity.Property(e => e.LocationId)
                    .HasColumnType("integer")
                    .HasColumnName("location_id");

                entity.Property(e => e.MapId)
                    .HasColumnType("integer")
                    .HasColumnName("map_id");

                entity.Property(e => e.RelativeHeight)
                    .HasColumnType("double precision")
                    .HasColumnName("relative_height");

                entity.Property(e => e.RelativeWidth)
                    .HasColumnType("double precision")
                    .HasColumnName("relative_width");

                entity.Property(e => e.RelativeX)
                    .HasColumnType("double precision")
                    .HasColumnName("relative_x");

                entity.Property(e => e.RelativeY)
                    .HasColumnType("double precision")
                    .HasColumnName("relative_y");
            });

            modelBuilder.Entity<GuidebookMenuitem>(entity =>
            {
                entity.ToTable("guidebook_menuitem");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.DisplayOptions)
                    .HasColumnType("text")
                    .HasColumnName("display_options");

                entity.Property(e => e.GuideId)
                    .HasColumnType("integer")
                    .HasColumnName("guide_id");

                entity.Property(e => e.Image)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("image");

                entity.Property(e => e.LastUpdated)
                    .HasColumnType("datetime")
                    .HasColumnName("last_updated");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("name");

                entity.Property(e => e.ParentId)
                    .HasColumnType("integer")
                    .HasColumnName("parent_id");

                entity.Property(e => e.Purpose)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("purpose");

                entity.Property(e => e.Rank)
                    .HasColumnType("integer")
                    .HasColumnName("rank");

                entity.Property(e => e.Url)
                    .HasColumnType("varchar(1023)")
                    .HasColumnName("url");

                entity.HasOne(d => d.Guide)
                    .WithMany(p => p.GuidebookMenuitems)
                    .HasForeignKey(d => d.GuideId);
            });

            modelBuilder.Entity<GuidebookOccurrence>(entity =>
            {
                entity.ToTable("guidebook_occurrence");

                entity.Property(e => e.Id)
                    .HasColumnType("integer AUTO_INCREMENT")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Allday)
                    .HasColumnType("bool")
                    .HasColumnName("allday");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("endTime");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("startTime");
            });

            modelBuilder.Entity<GuidebookOption>(entity =>
            {
                entity.ToTable("guidebook_options");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Key)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("key");

                entity.Property(e => e.Value)
                    .HasColumnType("text")
                    .HasColumnName("value");
            });

            modelBuilder.Entity<GuidebookPoi>(entity =>
            {
                entity.ToTable("guidebook_poi");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AddToDo)
                    .HasColumnType("bool")
                    .HasColumnName("addToDo");

                entity.Property(e => e.AllowRating)
                    .HasColumnType("bool")
                    .HasColumnName("allowRating");

                entity.Property(e => e.Categories)
                    .HasColumnType("text")
                    .HasColumnName("categories");

                entity.Property(e => e.CogDetails)
                    .HasColumnType("longtext")
                    .HasColumnName("cog_details");

                entity.Property(e => e.ContactEmail)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("contact_email");

                entity.Property(e => e.Deleted)
                    .HasColumnType("bool")
                    .HasColumnName("deleted");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.GuideId)
                    .HasColumnType("integer")
                    .HasColumnName("guide_id");

                entity.Property(e => e.Image)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("image");

                entity.Property(e => e.ImportId)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("import_id");

                entity.Property(e => e.Label)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("label");

                entity.Property(e => e.LastUpdated)
                    .HasColumnType("datetime")
                    .HasColumnName("last_updated");

                entity.Property(e => e.LinkImage)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("link_image");

                entity.Property(e => e.Links)
                    .HasColumnType("longtext")
                    .HasColumnName("links");

                entity.Property(e => e.Locations)
                    .HasColumnType("text")
                    .HasColumnName("locations");

                entity.Property(e => e.MeetingUrl)
                    .HasColumnType("varchar(1023)")
                    .HasColumnName("meeting_url");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("name");

                entity.Property(e => e.Rank)
                    .HasColumnType("integer")
                    .HasColumnName("rank");

                entity.Property(e => e.Subimage)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("subimage");

                entity.Property(e => e.Thumbnail)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("thumbnail");
            });

            modelBuilder.Entity<GuidebookPoiCategory>(entity =>
            {
                entity.ToTable("guidebook_poi_category");

                entity.HasIndex(e => new { e.PoiId, e.PoicategoryId }, "IX_guidebook_poi_category_poi_id_poicategory_id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.PoiId)
                    .HasColumnType("integer")
                    .HasColumnName("poi_id");

                entity.Property(e => e.PoicategoryId)
                    .HasColumnType("integer")
                    .HasColumnName("poicategory_id");

                entity.Property(e => e.Rank)
                    .HasColumnType("double precision")
                    .HasColumnName("rank");
            });

            modelBuilder.Entity<GuidebookPoiLocation>(entity =>
            {
                entity.ToTable("guidebook_poi_location");

                entity.HasIndex(e => new { e.PoiId, e.LocationId }, "IX_guidebook_poi_location_poi_id_location_id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.LocationId)
                    .HasColumnType("integer")
                    .HasColumnName("location_id");

                entity.Property(e => e.PoiId)
                    .HasColumnType("integer")
                    .HasColumnName("poi_id");
            });

            modelBuilder.Entity<GuidebookPoicategory1>(entity =>
            {
                entity.ToTable("guidebook_poicategory");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.GuideId)
                    .HasColumnType("integer")
                    .HasColumnName("guide_id");

                entity.Property(e => e.Image)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("image");

                entity.Property(e => e.LastUpdated)
                    .HasColumnType("datetime")
                    .HasColumnName("last_updated");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("name");

                entity.HasOne(d => d.Guide)
                    .WithMany(p => p.GuidebookPoicategory1s)
                    .HasForeignKey(d => d.GuideId);
            });

            modelBuilder.Entity<GuidebookSchedule>(entity =>
            {
                entity.ToTable("guidebook_schedule");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Color)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("color");

                entity.Property(e => e.Deleted)
                    .HasColumnType("bool")
                    .HasColumnName("deleted");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.GuideId)
                    .HasColumnType("integer")
                    .HasColumnName("guide_id");

                entity.Property(e => e.HexValue)
                    .HasColumnType("varchar(47)")
                    .HasColumnName("hexValue");

                entity.Property(e => e.Image)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("image");

                entity.Property(e => e.LastUpdated)
                    .HasColumnType("datetime")
                    .HasColumnName("last_updated");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("name");

                entity.HasOne(d => d.Guide)
                    .WithMany(p => p.GuidebookSchedules)
                    .HasForeignKey(d => d.GuideId);
            });

            modelBuilder.Entity<GuidebookSponsor>(entity =>
            {
                entity.ToTable("guidebook_sponsor");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.BannerImageLargeUrl)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("banner_image_large_url");

                entity.Property(e => e.BannerImageUrl)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("banner_image_url");

                entity.Property(e => e.BannerUrl)
                    .HasColumnType("varchar(200)")
                    .HasColumnName("banner_url");

                entity.Property(e => e.Deleted)
                    .HasColumnType("bool")
                    .HasColumnName("deleted");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Enabled)
                    .HasColumnType("bool")
                    .HasColumnName("enabled");

                entity.Property(e => e.GuideId)
                    .HasColumnType("integer")
                    .HasColumnName("guide_id");

                entity.Property(e => e.Image)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("image");

                entity.Property(e => e.ImportId)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("import_id");

                entity.Property(e => e.LastUpdated)
                    .HasColumnType("datetime")
                    .HasColumnName("last_updated");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("name");

                entity.Property(e => e.Url)
                    .HasColumnType("varchar(200)")
                    .HasColumnName("url");

                entity.Property(e => e.WebsiteOnly)
                    .HasColumnType("bool")
                    .HasColumnName("website_only");

                entity.Property(e => e.Weight)
                    .HasColumnType("integer")
                    .HasColumnName("weight");
            });

            modelBuilder.Entity<GuidebookTour>(entity =>
            {
                entity.ToTable("guidebook_tour");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ConcludingMessage)
                    .HasColumnType("text")
                    .HasColumnName("concluding_message");

                entity.Property(e => e.ConclusionActionMenuitemId1)
                    .HasColumnType("integer")
                    .HasColumnName("conclusion_action_menuitem_id_1");

                entity.Property(e => e.ConclusionActionMenuitemId2)
                    .HasColumnType("integer")
                    .HasColumnName("conclusion_action_menuitem_id_2");

                entity.Property(e => e.Cover)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("cover");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.GpsDisabled)
                    .HasColumnType("bool")
                    .HasColumnName("gps_disabled")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.GuideId)
                    .HasColumnType("integer")
                    .HasColumnName("guide_id");

                entity.Property(e => e.Headline)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("headline");

                entity.Property(e => e.HeadlineDescription)
                    .HasColumnType("text")
                    .HasColumnName("headline_description");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("name");

                entity.HasOne(d => d.Guide)
                    .WithMany(p => p.GuidebookTours)
                    .HasForeignKey(d => d.GuideId);
            });

            modelBuilder.Entity<GuidebookTourMediatrack>(entity =>
            {
                entity.ToTable("guidebook_tour_mediatrack");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Image)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("image");

                entity.Property(e => e.Title)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("title");

                entity.Property(e => e.TourId)
                    .HasColumnType("integer")
                    .HasColumnName("tour_id");

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.GuidebookTourMediatracks)
                    .HasForeignKey(d => d.TourId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<GuidebookTourMedium>(entity =>
            {
                entity.ToTable("guidebook_tour_media");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.FileSize)
                    .HasColumnType("integer")
                    .HasColumnName("file_size");

                entity.Property(e => e.Media)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("media");

                entity.Property(e => e.PlaysEnroute)
                    .HasColumnType("bool")
                    .HasColumnName("plays_enroute");

                entity.Property(e => e.TourStopId)
                    .HasColumnType("integer")
                    .HasColumnName("tour_stop_id");

                entity.Property(e => e.TourStopPointId)
                    .HasColumnType("integer")
                    .HasColumnName("tour_stop_point_id");

                entity.Property(e => e.TrackId)
                    .HasColumnType("integer")
                    .HasColumnName("track_id");

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

            modelBuilder.Entity<GuidebookTourstop>(entity =>
            {
                entity.ToTable("guidebook_tourstop");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Latitude)
                    .HasColumnType("double precision")
                    .HasColumnName("latitude");

                entity.Property(e => e.Longitude)
                    .HasColumnType("double precision")
                    .HasColumnName("longitude");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("name");

                entity.Property(e => e.Rank)
                    .HasColumnType("double precision")
                    .HasColumnName("rank");

                entity.Property(e => e.TourId)
                    .HasColumnType("integer")
                    .HasColumnName("tour_id");

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.GuidebookTourstops)
                    .HasForeignKey(d => d.TourId);
            });

            modelBuilder.Entity<GuidebookTourstopPoint>(entity =>
            {
                entity.ToTable("guidebook_tourstop_point");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Latitude)
                    .HasColumnType("double precision")
                    .HasColumnName("latitude");

                entity.Property(e => e.Longitude)
                    .HasColumnType("double precision")
                    .HasColumnName("longitude");

                entity.Property(e => e.Rank)
                    .HasColumnType("double precision")
                    .HasColumnName("rank");

                entity.Property(e => e.StopId)
                    .HasColumnType("integer")
                    .HasColumnName("stop_id");

                entity.HasOne(d => d.Stop)
                    .WithMany(p => p.GuidebookTourstopPoints)
                    .HasForeignKey(d => d.StopId);
            });

            modelBuilder.Entity<GuidebookTourstopimage>(entity =>
            {
                entity.ToTable("guidebook_tourstopimage");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("description");

                entity.Property(e => e.Image)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("image");

                entity.Property(e => e.Rank)
                    .HasColumnType("double precision")
                    .HasColumnName("rank");

                entity.Property(e => e.StopId)
                    .HasColumnType("integer")
                    .HasColumnName("stop_id");

                entity.HasOne(d => d.Stop)
                    .WithMany(p => p.GuidebookTourstopimages)
                    .HasForeignKey(d => d.StopId);
            });

            modelBuilder.Entity<GuidebookVenue>(entity =>
            {
                entity.ToTable("guidebook_venue");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.City)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("city");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.GuideId)
                    .HasColumnType("integer")
                    .HasColumnName("guide_id");

                entity.Property(e => e.Image)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("image");

                entity.Property(e => e.LastUpdated)
                    .HasColumnType("datetime")
                    .HasColumnName("last_updated");

                entity.Property(e => e.Latitude)
                    .HasColumnType("real")
                    .HasColumnName("latitude");

                entity.Property(e => e.Longitude)
                    .HasColumnType("real")
                    .HasColumnName("longitude");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("name");

                entity.Property(e => e.State)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("state");

                entity.Property(e => e.Street)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("street");

                entity.Property(e => e.Zipcode)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("zipcode");

                entity.Property(e => e.Zoom)
                    .HasColumnType("real")
                    .HasColumnName("zoom");

                entity.HasOne(d => d.Guide)
                    .WithMany(p => p.GuidebookVenues)
                    .HasForeignKey(d => d.GuideId);
            });

            modelBuilder.Entity<SchemaInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("schema_info");

                entity.HasIndex(e => e.Version, "IX_schema_info_version")
                    .IsUnique();

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Search>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("search");

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Label).HasColumnName("label");

                entity.Property(e => e.Locations).HasColumnName("locations");

                entity.Property(e => e.Title).HasColumnName("title");

                entity.Property(e => e.Track).HasColumnName("track");
            });

            modelBuilder.Entity<SearchContent>(entity =>
            {
                entity.HasKey(e => e.Docid);

                entity.ToTable("search_content");

                entity.Property(e => e.Docid)
                    .ValueGeneratedNever()
                    .HasColumnName("docid");

                entity.Property(e => e.C0title).HasColumnName("c0title");

                entity.Property(e => e.C1label).HasColumnName("c1label");

                entity.Property(e => e.C2description).HasColumnName("c2description");

                entity.Property(e => e.C3locations).HasColumnName("c3locations");

                entity.Property(e => e.C4category).HasColumnName("c4category");

                entity.Property(e => e.C5track).HasColumnName("c5track");
            });

            modelBuilder.Entity<SearchMetum>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("search_meta");

                entity.Property(e => e.Allday)
                    .HasColumnType("bool")
                    .HasColumnName("allday");

                entity.Property(e => e.CatOrTrack)
                    .HasColumnType("VARCHAR")
                    .HasColumnName("catOrTrack");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("endTime");

                entity.Property(e => e.MapRef)
                    .HasColumnType("VARCHAR")
                    .HasColumnName("mapRef");

                entity.Property(e => e.ObjId).HasColumnName("obj_id");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("startTime");

                entity.Property(e => e.Type)
                    .HasColumnType("VARCHAR")
                    .HasColumnName("type");
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

            modelBuilder.Entity<SearchSegment>(entity =>
            {
                entity.HasKey(e => e.Blockid);

                entity.ToTable("search_segments");

                entity.Property(e => e.Blockid)
                    .ValueGeneratedNever()
                    .HasColumnName("blockid");

                entity.Property(e => e.Block).HasColumnName("block");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
