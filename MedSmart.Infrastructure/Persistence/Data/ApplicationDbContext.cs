using MedSmart.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedSmart.Infrastructure.Persistence.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<FirebaseToken> FirebaseTokens { get; set; }
        public DbSet<HangfireJob> HangfireJobs { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<MedicationCategory> MedicationCategories { get; set; }
        public DbSet<MedicationImage> MedicationImages { get; set; }
        public DbSet<MedicationLog> MedicationLogs { get; set; }
        public DbSet<MedicationSchedule> MedicationSchedules { get; set; }
        public DbSet<MedicationsDiscount> MedicationsDiscounts { get; set; }
        public DbSet<MedicationSubCategory> MedicationSubCategories { get; set; }
        public DbSet<MedicationTag> MedicationTags { get; set; }
        public DbSet<NotificationLog> NotificationLogs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<ReminderHistory> ReminderHistories { get; set; }
        public DbSet<ReminderSettings> ReminderSettings { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<StockAlert> StockAlerts { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relationship between User and Ratings (one-to-many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Ratings)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);

            // Relationship between User and Comments (one-to-many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Comments)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);

            // Relationship between User and Prescriptions (one-to-many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Prescriptions)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            // Relationship between User and Orders (one-to-many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId);

            // Relationship between User and MedicationLogs (one-to-many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.MedicationLogs)
                .WithOne(ml => ml.User)
                .HasForeignKey(ml => ml.UserId);

            // Relationship between User and NotificationLogs (one-to-many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.NotificationLogs)
                .WithOne(nl => nl.User)
                .HasForeignKey(nl => nl.UserId);

            // Relationship between User and StockAlerts (one-to-many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.StockAlerts)
                .WithOne(sa => sa.User)
                .HasForeignKey(sa => sa.UserId);

            // Relationship between User and Reminders (one-to-many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Reminders)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);

            // Relationship between User and FirebaseTokens (one-to-many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.FirebaseTokens)
                .WithOne(ft => ft.User)
                .HasForeignKey(ft => ft.UserId);

            // Relationship between User and ReminderSettings (one-to-one)
            modelBuilder.Entity<User>()
                .HasOne(u => u.ReminderSettings)
                .WithOne(rs => rs.User)
                .HasForeignKey<ReminderSettings>(rs => rs.UserId);

            // Relationship between Medication and Ratings (one-to-many)
            modelBuilder.Entity<Medication>()
                .HasMany(m => m.Ratings)
                .WithOne(r => r.Medication)
                .HasForeignKey(r => r.MedicationId);

            // Relationship between Medication and Comments (one-to-many)
            modelBuilder.Entity<Medication>()
                .HasMany(m => m.Comments)
                .WithOne(c => c.Medication)
                .HasForeignKey(c => c.MedicationId);

            // Relationship between Medication and MedicationLogs (one-to-many)
            modelBuilder.Entity<Medication>()
                .HasMany(m => m.MedicationLogs)
                .WithOne(ml => ml.Medication)
                .HasForeignKey(ml => ml.MedicationId);

            // Relationship between Medication and StockAlerts (one-to-many)
            modelBuilder.Entity<Medication>()
                .HasMany(m => m.StockAlerts)
                .WithOne(sa => sa.Medication)
                .HasForeignKey(sa => sa.MedicationId);

            // Relationship between Medication and MedicationSchedules (one-to-many)
            modelBuilder.Entity<Medication>()
                .HasMany(m => m.MedicationSchedules)
                .WithOne(ms => ms.Medication)
                .HasForeignKey(ms => ms.MedicationId);

            // Relationship between Medication and MedicationImages (one-to-many)
            modelBuilder.Entity<Medication>()
                .HasMany(m => m.Images)
                .WithOne(mi => mi.Medication)
                .HasForeignKey(mi => mi.MedicationId);

            // Relationship between Medication and OrderDetails (one-to-many)
            modelBuilder.Entity<Medication>()
                .HasMany(m => m.OrderDetails)
                .WithOne(od => od.Medication)
                .HasForeignKey(od => od.MedicationId);

            // Relationship between Medication and MedicationTags (one-to-many)
            modelBuilder.Entity<Medication>()
                .HasMany(m => m.MedicationTags)
                .WithOne(mt => mt.Medication)
                .HasForeignKey(mt => mt.MedicationId);

            // Relationship between Tag and MedicationTags (one-to-many)
            modelBuilder.Entity<Tag>()
                .HasMany(t => t.MedicationTags)
                .WithOne(mt => mt.Tag)
                .HasForeignKey(mt => mt.TagId);

            // Relationship between Prescription and MedicationSchedules (one-to-many)
            modelBuilder.Entity<Prescription>()
                .HasMany(p => p.MedicationSchedules)
                .WithOne(ms => ms.Prescription)
                .HasForeignKey(ms => ms.PrescriptionId);

            // Relationship between Order and OrderDetails (one-to-many)
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderDetails)
                .WithOne(od => od.Order)
                .HasForeignKey(od => od.OrderId);

            // Relationship between Order and Shipping (one-to-one)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Shipping)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.ShippingId);

            // Relationship between OrderStatus and Orders (one-to-many)
            modelBuilder.Entity<OrderStatus>()
                .HasMany(os => os.Orders)
                .WithOne(o => o.OrderStatus)
                .HasForeignKey(o => o.OrderStatusId);

            // Relationship between Supplier and Medications (one-to-many)
            modelBuilder.Entity<Supplier>()
                .HasMany(s => s.Medications)
                .WithOne(m => m.Supplier)
                .HasForeignKey(m => m.SupplierId);

            // Relationship between Reminder and ReminderHistories (one-to-many)
            modelBuilder.Entity<Reminder>()
                .HasMany(r => r.ReminderHistories)
                .WithOne(rh => rh.Reminder)
                .HasForeignKey(rh => rh.ReminderId);

            // Relationship between HangfireJob and User (one-to-many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.HangfireJobs)
                .WithOne(hj => hj.User)
                .HasForeignKey(hj => hj.UserId);

            base.OnModelCreating(modelBuilder);


        }
    }
}
