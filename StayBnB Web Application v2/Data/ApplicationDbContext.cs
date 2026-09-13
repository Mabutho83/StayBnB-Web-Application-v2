using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StayBnB_Web_Application_v2.Models;

namespace StayBnB_Web_Application_v2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<HostProperty> HostProperties { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<PropertyImage> PropertyImages { get; set; }
        public DbSet<WishlistItem> WishlistItems { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<HostApplication> HostApplications { get; set; }
        public DbSet<CheckInProcess> CheckInProcesses { get; set; }
        public DbSet<GuestCheckIn> GuestCheckIns { get; set; }
        public DbSet<GuestDocument> GuestDocuments { get; set; }
        public DbSet<HostPropertyAmenity> HostPropertyAmenities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //one to many relationship between ApplicationUser and HostProperty
            builder.Entity<HostProperty>()
                .HasOne(p => p.ApplicationUser)
                .WithMany(u => u.HostProperties)
                .HasForeignKey(p => p.HostId)
                .OnDelete(DeleteBehavior.Restrict);

            //one to many relationship between HostProperty and Booking
            builder.Entity<Booking>()
                .HasOne(b => b.HostProperty)
                .WithMany(p => p.Bookings)
                .HasForeignKey(b => b.HostPropertyId)
                .OnDelete(DeleteBehavior.Restrict);

            //many to many relationship between HostProperty and Amenity through HostPropertyAmenity
            builder.Entity<HostPropertyAmenity>()
                .HasKey(hpa => new { hpa.HostPropertyId, hpa.AmenityId });

            builder.Entity<HostPropertyAmenity>()
                .HasOne(hpa => hpa.HostProperty)
                .WithMany(hp => hp.PropertyAmenities)
                .HasForeignKey(hpa => hpa.HostPropertyId);

            builder.Entity<HostPropertyAmenity>()
                .HasOne(hpa => hpa.Amenity)
                .WithMany(a => a.HostPropertyAmenity)
                .HasForeignKey(hpa => hpa.AmenityId);

            //one to one relationship between Booking and GuestCheckIn
            //docs say to use .isRequired(), but for now we'll let this slide because so far, no fk was made nullable
            builder.Entity<GuestCheckIn>()
                .HasOne(gci => gci.Booking)
                .WithOne(b => b.GuestCheckIn)
                .HasForeignKey<GuestCheckIn>(gci => gci.BookingId)
                .OnDelete(DeleteBehavior.Restrict);

            //one to many relationship between applicationuser and booking
            builder.Entity<Booking>()
                .HasOne(b => b.ApplicationUser)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.GuestId)
                .OnDelete(DeleteBehavior.Restrict);

            //one to may relationship between hostproperty and review
            builder.Entity<Review>()
                .HasOne(r => r.HostProperty)
                .WithMany(hp => hp.Reviews)
                .HasForeignKey(r => r.PropertyId)
                .OnDelete(DeleteBehavior.Restrict);

            //one to many relationship between property and image
            builder.Entity<PropertyImage>()
                .HasOne(pi => pi.HostProperty)
                .WithMany(hp => hp.PropertyImages)
                .HasForeignKey(pi => pi.PropertyId)
                .OnDelete(DeleteBehavior.Restrict);

            //one to many relationship between guestcheckin and guestdocument
            builder.Entity<GuestDocument>()
                .HasOne(gd => gd.GuestCheckIn)
                .WithMany(gci => gci.GuestDocuments)
                .HasForeignKey(gd => gd.GuestCheckInId)
                .OnDelete(DeleteBehavior.Restrict);

            //one to many relationship between applicationuser and review
            builder.Entity<Review>()
                .HasOne(r => r.Reviewer)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.ReviewerId)
                .OnDelete(DeleteBehavior.Restrict);

            //one to one relationship between booking and payment
            builder.Entity<Payment>()
                .HasOne(p => p.Booking)
                .WithOne(b => b.Payment)
                .HasForeignKey<Payment>(p => p.BookingId)
                .OnDelete(DeleteBehavior.Restrict);

            //one to one relationship between hostproperty and checkinprocess
            builder.Entity<CheckInProcess>()
                .HasOne(cip => cip.HostProperty)
                .WithOne(hp => hp.CheckInProcess)
                .HasForeignKey<CheckInProcess>(cip => cip.PropertyId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
