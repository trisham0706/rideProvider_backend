using CommunityCommuting_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityCommuting_DAL.DBContext
{
    public class CommunityCommutingDbContext : DbContext
    {
        public CommunityCommutingDbContext(DbContextOptions<CommunityCommutingDbContext> options) : base(options) { }
        public DbSet<RideInfo> RideInfos { get; set; }
        public DbSet<RideProvide> RideProvides { get; set; }
        public DbSet<Smile> Smiles { get; set; }
        public DbSet<billMaster> billMasters { get; set; }
        public DbSet<Fee> Fees { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        [Obsolete]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RideProvide>(e =>
            {
                e.HasKey(t => new { t.rpId });
            });
            modelBuilder.Entity<RideInfo>().HasOne(e => e.rideProvide).WithMany(t => t.RideInfos).HasForeignKey(e => e.rpId);

            modelBuilder.Entity<RideProvide>()
                        .Property(e => e.firstName)
                        .IsRequired()
                        .HasMaxLength(50).IsRequired();

            modelBuilder.Entity<RideProvide>()
                .Property(e => e.lastName)
                .IsRequired()
                .HasMaxLength(50).IsRequired();

            modelBuilder.Entity<RideProvide>()
                .Property(e => e.validUpto)
                .IsRequired()
                .HasAnnotation("MinValue", DateTime.Now.AddDays(30)).IsRequired(); 

            modelBuilder.Entity<RideProvide>()
                .Property(e => e.status)
                .IsRequired()
                .HasMaxLength(15)
                .HasAnnotation("AllowedValues", new[] { "Registered", "Un-registered" }).IsRequired(); 

            modelBuilder.Entity<RideProvide>()
                .Property(e => e.dlNo)
                .IsRequired()
                .HasMaxLength(18)
                .IsFixedLength()
                .HasAnnotation("RegexPattern", @"^[A-Z0-9]{4}-[A-Z0-9]{3}-[A-Z0-9]{3}-[A-Z0-9]{3}$").IsRequired(); 

            modelBuilder.Entity<RideProvide>()
                .Property(e => e.adharcard)
                .HasMaxLength(12).IsRequired();
            modelBuilder.Entity<RideProvide>().Property(e => e.phone).IsRequired();
            modelBuilder.Entity<RideProvide>().Property(e => e.emailId).IsRequired();

            modelBuilder.Entity<RideInfo>(e =>
            {
                e.HasKey(t => new { t.vehicleNo });
            });


            modelBuilder.Entity<Smile>(e =>
            {
                e.HasKey(t => new { t.smileId });
            });
            modelBuilder.Entity<Smile>().HasOne(e => e.rideInfo).WithMany(t => t.Smiles).HasForeignKey(e => e.rpId);

            modelBuilder.Entity<Fee>(e =>
            {
                e.HasKey(t => new { t.feeId });
            });

            modelBuilder.Entity<billMaster>().HasOne(e => e.fees).WithMany(t => t.billMasters).HasForeignKey(e => e.feeId);

            modelBuilder.Entity<billMaster>(e =>
            {
                e.HasKey(t => new { t.billId });
            });

            modelBuilder.Entity<Booking>().HasOne(e => e.trips).WithMany(t => t.bookings).HasForeignKey(e => e.tripId);
            modelBuilder.Entity<Trip>(e =>
            {
                e.HasKey(t => new { t.tripId });
            });
            modelBuilder.Entity<Booking>(e =>
            {
                e.HasKey(t => new { t.bookingId });
            });
        }
    }
}



