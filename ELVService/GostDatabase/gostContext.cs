using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ELVService.GostDatabase
{
    public partial class gostContext : DbContext
    {
        public gostContext()
        {
        }

        public gostContext(DbContextOptions<gostContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Datastream> Datastream { get; set; }
        public virtual DbSet<Elevator> Elevator { get; set; }
        public virtual DbSet<Elevatorruntime> Elevatorruntime { get; set; }
        public virtual DbSet<Elevatorruntime2> Elevatorruntime2 { get; set; }
        public virtual DbSet<ElevatorruntimeOld> ElevatorruntimeOld { get; set; }
        public virtual DbSet<Featureofinterest> Featureofinterest { get; set; }
        public virtual DbSet<Historicallocation> Historicallocation { get; set; }
        public virtual DbSet<Jsonfiles> Jsonfiles { get; set; }
        public virtual DbSet<Jsonfiles2> Jsonfiles2 { get; set; }
        public virtual DbSet<Lastcellsdata> Lastcellsdata { get; set; }
        public virtual DbSet<LastcellsdataBredegarden> LastcellsdataBredegarden { get; set; }
        public virtual DbSet<LastcellsdataDegeberg> LastcellsdataDegeberg { get; set; }
        public virtual DbSet<LastcellsdataFriberg> LastcellsdataFriberg { get; set; }
        public virtual DbSet<LastcellsdataHedaker> LastcellsdataHedaker { get; set; }
        public virtual DbSet<LastcellsdataHogs> LastcellsdataHogs { get; set; }
        public virtual DbSet<LastcellsdataSjoberg> LastcellsdataSjoberg { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<LocationToHistoricallocation> LocationToHistoricallocation { get; set; }
        public virtual DbSet<Observation> Observation { get; set; }
        public virtual DbSet<Observedproperty> Observedproperty { get; set; }
        public virtual DbSet<Plant> Plant { get; set; }
        public virtual DbSet<Plcdata05> Plcdata05 { get; set; }
        public virtual DbSet<Plcdata06> Plcdata06 { get; set; }
        public virtual DbSet<Plcdata07Eibloggervolt> Plcdata07Eibloggervolt { get; set; }
        public virtual DbSet<Plcdata08> Plcdata08 { get; set; }
        public virtual DbSet<Poi> Poi { get; set; }
        public virtual DbSet<PoiProperty> PoiProperty { get; set; }
        public virtual DbSet<PoiPropertyMeta> PoiPropertyMeta { get; set; }
        public virtual DbSet<Sensor> Sensor { get; set; }
        public virtual DbSet<Thing> Thing { get; set; }
        public virtual DbSet<ThingToLocation> ThingToLocation { get; set; }
        public virtual DbSet<Uniquefeatureofinterest> Uniquefeatureofinterest { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connstr = Environment.GetEnvironmentVariable("CONNECTION_STR");
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=40.69.208.149;Database=gost;Username=postgres;Password=postgres;Port=5432");
                //optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=9999;Database=gost;Username=postgres;Password=postgres;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("fuzzystrmatch")
                .HasPostgresExtension("postgis")
                .HasPostgresExtension("postgis_tiger_geocoder")
                .HasPostgresExtension("postgis_topology");

            modelBuilder.Entity<Datastream>(entity =>
            {
                entity.ToTable("datastream", "v1");

                entity.HasIndex(e => e.ObservedpropertyId)
                    .HasName("fki_observedproperty");

                entity.HasIndex(e => e.SensorId)
                    .HasName("fki_sensor");

                entity.HasIndex(e => e.ThingId)
                    .HasName("fki_thing");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Observationtype).HasColumnName("observationtype");

                entity.Property(e => e.ObservedpropertyId).HasColumnName("observedproperty_id");

                entity.Property(e => e.Phenomenontime)
                    .HasColumnName("phenomenontime")
                    .HasColumnType("tstzrange");

                entity.Property(e => e.Resulttime)
                    .HasColumnName("resulttime")
                    .HasColumnType("tstzrange");

                entity.Property(e => e.SensorId).HasColumnName("sensor_id");

                entity.Property(e => e.ThingId).HasColumnName("thing_id");

                entity.Property(e => e.Unitofmeasurement)
                    .HasColumnName("unitofmeasurement")
                    .HasColumnType("jsonb");

                entity.HasOne(d => d.Observedproperty)
                    .WithMany(p => p.Datastream)
                    .HasForeignKey(d => d.ObservedpropertyId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_observedproperty");

                entity.HasOne(d => d.Sensor)
                    .WithMany(p => p.Datastream)
                    .HasForeignKey(d => d.SensorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_sensor");

                entity.HasOne(d => d.Thing)
                    .WithMany(p => p.Datastream)
                    .HasForeignKey(d => d.ThingId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_thing");
            });

            modelBuilder.Entity<Elevator>(entity =>
            {
                entity.ToTable("elevator", "v1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DeviceId).HasColumnName("device_id");

                entity.Property(e => e.EgwChannel).HasColumnName("egw_channel");

                entity.Property(e => e.EquipmentId)
                    .IsRequired()
                    .HasColumnName("equipment_id")
                    .HasColumnType("character varying");

                entity.Property(e => e.Metadata)
                    .HasColumnName("metadata")
                    .HasColumnType("jsonb");

                entity.Property(e => e.Model).HasColumnName("model");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.PlantId).HasColumnName("plant_id");

                entity.Property(e => e.PlantRef).HasColumnName("plant_ref");

                entity.Property(e => e.PoiId).HasColumnName("poi_id");

                entity.Property(e => e.Productdatamodel).HasColumnName("productdatamodel");

                entity.Property(e => e.Productdataname).HasColumnName("productdataname");

                entity.Property(e => e.Submodel).HasColumnName("submodel");
            });

            modelBuilder.Entity<Elevatorruntime>(entity =>
            {
                entity.ToTable("elevatorruntime", "v1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('v1.elevatorruntime2_id_seq'::regclass)");

                entity.Property(e => e.ElevatorId)
                    .HasColumnName("elevator_id")
                    .HasColumnType("character varying");

                entity.Property(e => e.Endtime)
                    .HasColumnName("endtime")
                    .HasColumnType("character varying");

                entity.Property(e => e.FoiId).HasColumnName("foi_id");

                entity.Property(e => e.FoiName)
                    .HasColumnName("foi_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.Machine)
                    .HasColumnName("machine")
                    .HasColumnType("character varying");

                entity.Property(e => e.PlantName)
                    .HasColumnName("plant_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.PlantRef)
                    .HasColumnName("plant_ref")
                    .HasColumnType("character varying");

                entity.Property(e => e.PlcTagName)
                    .HasColumnName("plc_tag_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.RuntimeMinutes).HasColumnName("runtime_minutes");

                entity.Property(e => e.Starttime)
                    .HasColumnName("starttime")
                    .HasColumnType("character varying");

                entity.Property(e => e.StreamId).HasColumnName("stream_id");

                entity.Property(e => e.TransportRunId)
                    .HasColumnName("transport_run_id")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Elevatorruntime2>(entity =>
            {
                entity.ToTable("elevatorruntime_2", "v1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EndTime)
                    .HasColumnName("end_time")
                    .HasColumnType("character varying");

                entity.Property(e => e.Machine)
                    .HasColumnName("machine")
                    .HasColumnType("character varying");

                entity.Property(e => e.PlantName)
                    .HasColumnName("plant_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.PlantRef)
                    .HasColumnName("plant_ref")
                    .HasColumnType("character varying");

                entity.Property(e => e.StartTime)
                    .HasColumnName("start_time")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<ElevatorruntimeOld>(entity =>
            {
                entity.ToTable("elevatorruntime_old", "v1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('v1.elevatorruntime_id_seq'::regclass)");

                entity.Property(e => e.ElevatorId)
                    .HasColumnName("elevator_id")
                    .HasColumnType("character varying");

                entity.Property(e => e.Endtime)
                    .HasColumnName("endtime")
                    .HasColumnType("character varying");

                entity.Property(e => e.FoiId).HasColumnName("foi_id");

                entity.Property(e => e.FoiName)
                    .HasColumnName("foi_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.Machine)
                    .HasColumnName("machine")
                    .HasColumnType("character varying");

                entity.Property(e => e.PlantName)
                    .HasColumnName("plant_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.PlantRef)
                    .HasColumnName("plant_ref")
                    .HasColumnType("character varying");

                entity.Property(e => e.PlcTagName)
                    .HasColumnName("plc_tag_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.RuntimeMinutes).HasColumnName("runtime_minutes");

                entity.Property(e => e.Starttime)
                    .HasColumnName("starttime")
                    .HasColumnType("character varying");

                entity.Property(e => e.StreamId).HasColumnName("stream_id");

                entity.Property(e => e.TransportRunId)
                    .HasColumnName("transport_run_id")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Featureofinterest>(entity =>
            {
                entity.ToTable("featureofinterest", "v1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500);

                entity.Property(e => e.Encodingtype).HasColumnName("encodingtype");

                entity.Property(e => e.Geojson)
                    .HasColumnName("geojson")
                    .HasColumnType("jsonb");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.OriginalLocationId).HasColumnName("original_location_id");
            });

            modelBuilder.Entity<Historicallocation>(entity =>
            {
                entity.ToTable("historicallocation", "v1");

                entity.HasIndex(e => e.ThingId)
                    .HasName("fki_thing_hl");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ThingId).HasColumnName("thing_id");

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("timestamp with time zone");

                entity.HasOne(d => d.Thing)
                    .WithMany(p => p.Historicallocation)
                    .HasForeignKey(d => d.ThingId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_thing_hl");
            });

            modelBuilder.Entity<Jsonfiles>(entity =>
            {
                entity.ToTable("jsonfiles", "v1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.File)
                    .IsRequired()
                    .HasColumnName("file")
                    .HasColumnType("json");
            });

            modelBuilder.Entity<Jsonfiles2>(entity =>
            {
                entity.ToTable("jsonfiles2", "v1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.File)
                    .HasColumnName("file")
                    .HasColumnType("json");

                entity.Property(e => e.Filename)
                    .HasColumnName("filename")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Lastcellsdata>(entity =>
            {
                entity.ToTable("lastcellsdata", "v1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PlantRef)
                    .HasColumnName("plant_ref")
                    .HasColumnType("character varying");

                entity.Property(e => e.PlcTagName)
                    .HasColumnName("plc_tag_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.Ts).HasColumnName("ts");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<LastcellsdataBredegarden>(entity =>
            {
                entity.ToTable("lastcellsdata_bredegarden", "v1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PlantRef)
                    .IsRequired()
                    .HasColumnName("plant_ref")
                    .HasColumnType("character varying");

                entity.Property(e => e.PlcTagName)
                    .HasColumnName("plc_tag_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.Ts).HasColumnName("ts");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<LastcellsdataDegeberg>(entity =>
            {
                entity.ToTable("lastcellsdata_degeberg", "v1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PlantRef)
                    .IsRequired()
                    .HasColumnName("plant_ref")
                    .HasColumnType("character varying");

                entity.Property(e => e.PlcTagName)
                    .HasColumnName("plc_tag_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.Ts).HasColumnName("ts");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<LastcellsdataFriberg>(entity =>
            {
                entity.ToTable("lastcellsdata_friberg", "v1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PlantRef)
                    .IsRequired()
                    .HasColumnName("plant_ref")
                    .HasColumnType("character varying");

                entity.Property(e => e.PlcTagName)
                    .HasColumnName("plc_tag_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.Ts).HasColumnName("ts");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<LastcellsdataHedaker>(entity =>
            {
                entity.ToTable("lastcellsdata_hedaker", "v1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PlantRef)
                    .IsRequired()
                    .HasColumnName("plant_ref")
                    .HasColumnType("character varying");

                entity.Property(e => e.PlcTagName)
                    .HasColumnName("plc_tag_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.Ts).HasColumnName("ts");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<LastcellsdataHogs>(entity =>
            {
                entity.ToTable("lastcellsdata_hogs", "v1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PlantRef)
                    .IsRequired()
                    .HasColumnName("plant_ref")
                    .HasColumnType("character varying");

                entity.Property(e => e.PlcTagName)
                    .HasColumnName("plc_tag_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.Ts).HasColumnName("ts");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<LastcellsdataSjoberg>(entity =>
            {
                entity.ToTable("lastcellsdata_sjoberg", "v1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ElevatorRuntimeId).HasColumnName("elevator_runtime_id");

                entity.Property(e => e.FoiId).HasColumnName("foi_id");

                entity.Property(e => e.PlantRef)
                    .IsRequired()
                    .HasColumnName("plant_ref")
                    .HasColumnType("character varying");

                entity.Property(e => e.PlcTagName)
                    .HasColumnName("plc_tag_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.Ts).HasColumnName("ts");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("location", "v1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500);

                entity.Property(e => e.Encodingtype).HasColumnName("encodingtype");

                entity.Property(e => e.Geojson)
                    .HasColumnName("geojson")
                    .HasColumnType("jsonb");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<LocationToHistoricallocation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("location_to_historicallocation", "v1");

                entity.HasIndex(e => e.HistoricallocationId)
                    .HasName("fki_historicallocation_1");

                entity.HasIndex(e => e.LocationId)
                    .HasName("fki_location_2");

                entity.Property(e => e.HistoricallocationId).HasColumnName("historicallocation_id");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.HasOne(d => d.Historicallocation)
                    .WithMany()
                    .HasForeignKey(d => d.HistoricallocationId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_historicallocation_1");

                entity.HasOne(d => d.Location)
                    .WithMany()
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_location_2");
            });

            modelBuilder.Entity<Observation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("observation", "v1");

                entity.HasIndex(e => e.FeatureofinterestId)
                    .HasName("fki_featureofinterest");

                entity.HasIndex(e => e.Id)
                    .HasName("i_id");

                entity.HasIndex(e => new { e.StreamId, e.Id })
                    .HasName("i_dsid_id");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("jsonb");

                entity.Property(e => e.FeatureofinterestId).HasColumnName("featureofinterest_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.StreamId).HasColumnName("stream_id");

                entity.HasOne(d => d.Featureofinterest)
                    .WithMany()
                    .HasForeignKey(d => d.FeatureofinterestId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_featureofinterest");

                entity.HasOne(d => d.Stream)
                    .WithMany()
                    .HasForeignKey(d => d.StreamId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_datastream");
            });

            modelBuilder.Entity<Observedproperty>(entity =>
            {
                entity.ToTable("observedproperty", "v1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Definition)
                    .HasColumnName("definition")
                    .HasMaxLength(255);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(120);
            });

            modelBuilder.Entity<Plant>(entity =>
            {
                entity.ToTable("plant", "v1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.City).HasColumnName("city");

                entity.Property(e => e.Country).HasColumnName("country");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("character varying");

                entity.Property(e => e.PlantRef)
                    .HasColumnName("plant_ref")
                    .HasColumnType("character varying");

                entity.Property(e => e.Street1).HasColumnName("street1");

                entity.Property(e => e.Street2).HasColumnName("street2");

                entity.Property(e => e.ThingId).HasColumnName("thing_id");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.Zipcode).HasColumnName("zipcode");
            });

            modelBuilder.Entity<Plcdata05>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("plcdata05", "v1");

                entity.Property(e => e.PlantRef)
                    .HasColumnName("plant_ref")
                    .HasColumnType("character varying");

                entity.Property(e => e.PlcTagName)
                    .HasColumnName("plc_tag_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.Ts)
                    .HasColumnName("ts")
                    .HasColumnType("character varying");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Plcdata06>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("plcdata06", "v1");

                entity.Property(e => e.PlantRef)
                    .HasColumnName("plant_ref")
                    .HasColumnType("character varying");

                entity.Property(e => e.PlcTagName)
                    .HasColumnName("plc_tag_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.Ts)
                    .HasColumnName("ts")
                    .HasColumnType("character varying");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Plcdata07Eibloggervolt>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("plcdata07_eibloggervolt", "v1");

                entity.Property(e => e.PlantRef)
                    .HasColumnName("plant_ref")
                    .HasColumnType("character varying");

                entity.Property(e => e.PlcTagName)
                    .HasColumnName("plc_tag_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.Ts)
                    .HasColumnName("ts")
                    .HasColumnType("character varying");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Plcdata08>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("plcdata08", "v1");

                entity.Property(e => e.PlantRef)
                    .HasColumnName("plant_ref")
                    .HasColumnType("character varying");

                entity.Property(e => e.PlcTagName)
                    .HasColumnName("plc_tag_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.Ts)
                    .HasColumnName("ts")
                    .HasColumnType("character varying");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Poi>(entity =>
            {
                entity.ToTable("poi", "v1");

                entity.HasIndex(e => e.Geom)
                    .HasName("poi_geom");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Geom).HasColumnName("geom");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Location).HasColumnName("location");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.Metadata)
                    .HasColumnName("metadata")
                    .HasColumnType("json");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(300);

                entity.Property(e => e.OoiRef).HasColumnName("ooi_ref");

                entity.Property(e => e.Thingid).HasColumnName("thingid");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PoiProperty>(entity =>
            {
                entity.ToTable("poi_property", "v1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('v1.poi_measurement_id_seq'::regclass)");

                entity.Property(e => e.Currentvalue).HasColumnName("currentvalue");

                entity.Property(e => e.Currentvaluestring)
                    .HasColumnName("currentvaluestring")
                    .HasMaxLength(300);

                entity.Property(e => e.Forecastvaluestream).HasColumnName("forecastvaluestream");

                entity.Property(e => e.Historicalvaluestream).HasColumnName("historicalvaluestream");

                entity.Property(e => e.Observedpropertyid).HasColumnName("observedpropertyid");

                entity.Property(e => e.PoiPropertyMetaid).HasColumnName("poi_property_metaid");

                entity.Property(e => e.Poiid).HasColumnName("poiid");

                entity.Property(e => e.Property)
                    .IsRequired()
                    .HasColumnName("property")
                    .HasMaxLength(100);

                entity.Property(e => e.Timestamp).HasColumnName("timestamp");
            });

            modelBuilder.Entity<PoiPropertyMeta>(entity =>
            {
                entity.ToTable("poi_property_meta", "v1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Unitofmeasurement)
                    .HasColumnName("unitofmeasurement")
                    .HasColumnType("json");

                entity.Property(e => e.Valuerules)
                    .HasColumnName("valuerules")
                    .HasColumnType("json");
            });

            modelBuilder.Entity<Sensor>(entity =>
            {
                entity.ToTable("sensor", "v1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500);

                entity.Property(e => e.Encodingtype).HasColumnName("encodingtype");

                entity.Property(e => e.Metadata).HasColumnName("metadata");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Thing>(entity =>
            {
                entity.ToTable("thing", "v1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Properties)
                    .HasColumnName("properties")
                    .HasColumnType("jsonb");
            });

            modelBuilder.Entity<ThingToLocation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("thing_to_location", "v1");

                entity.HasIndex(e => e.LocationId)
                    .HasName("fki_location_1");

                entity.HasIndex(e => e.ThingId)
                    .HasName("fki_thing_1");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.ThingId).HasColumnName("thing_id");

                entity.HasOne(d => d.Location)
                    .WithMany()
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_location_1");

                entity.HasOne(d => d.Thing)
                    .WithMany()
                    .HasForeignKey(d => d.ThingId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_thing_1");
            });

            modelBuilder.Entity<Uniquefeatureofinterest>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("uniquefeatureofinterest", "v1");

                entity.Property(e => e.FoiId).HasColumnName("foi_id");
            });

            modelBuilder.HasSequence("poi_id_seq", "v1");

            modelBuilder.HasSequence("poi_measurement_id_seq", "v1");

            modelBuilder.HasSequence("poi_property_meta_id_seq", "v1");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
