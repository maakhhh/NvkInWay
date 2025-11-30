using Microsoft.EntityFrameworkCore;
using NvkInWay.Api.Persistence.Converters;
using NvkInWay.Api.Persistence.Entities;

namespace NvkInWay.Api.Persistence.DbContext;

internal sealed class ApplicationContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<RefreshTokenEntity> RefreshTokens => Set<RefreshTokenEntity>();
    public DbSet<UserSessionsEntity> UserSessions => Set<UserSessionsEntity>();
    public DbSet<RevokedTokenEntity> RevokedTokens => Set<RevokedTokenEntity>();
    public DbSet<UserVerificationEntity> Verifications => Set<UserVerificationEntity>();
    
    public DbSet<UserEntity> Users => Set<UserEntity>();
    public DbSet<TripEntity> Trips => Set<TripEntity>();
    public DbSet<TripPassengerEntity> TripPassengers => Set<TripPassengerEntity>();
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<DateTimeOffset>()
            .HaveConversion<DateTimeOffsetToUtcConverter>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RefreshTokenEntity>(entity =>
        {
            entity.HasKey(rt => rt.Id);
            entity.HasIndex(rt => rt.Token).IsUnique();
            entity.HasIndex(rt => new { rt.UserId, rt.DeviceId });
            entity.HasIndex(rt => rt.ExpiryDate);
            
            entity.Property(rt => rt.Token).IsRequired().HasMaxLength(500);
            entity.Property(rt => rt.JwtId).IsRequired().HasMaxLength(100);
        });

        modelBuilder.Entity<UserSessionsEntity>(entity =>
        {
            entity.HasKey(us => us.Id);
            entity.Property(us => us.Id)
                .ValueGeneratedOnAdd();
            
            entity.HasIndex(us => new { us.UserId, us.DeviceId }).IsUnique();
            entity.HasIndex(us => us.LastActivity);
            
            entity.Property(us => us.DeviceId).IsRequired().HasMaxLength(200);
        });

        modelBuilder.Entity<RevokedTokenEntity>(entity =>
        {
            entity.HasKey(rt => rt.Id);
            
            entity.HasIndex(rt => rt.JwtId).IsUnique();
            
            entity.HasIndex(rt => rt.UserId);
            entity.HasIndex(rt => rt.ExpiryDate);
            entity.HasIndex(rt => new { rt.UserId, rt.DeviceId });
            
            entity.Property(rt => rt.JwtId).IsRequired().HasMaxLength(100);
            entity.Property(rt => rt.TokenHash).HasMaxLength(256); // Для хеша токена
            entity.Property(rt => rt.Reason).HasMaxLength(200);
            entity.Property(rt => rt.RevocationType).HasConversion<string>().HasMaxLength(50);
            
            entity.HasOne(rt => rt.User)
                .WithMany()
                .HasForeignKey(rt => rt.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        modelBuilder.Entity<UserEntity>(entity =>
        {
            entity.HasKey(u => u.Id);

            entity.HasIndex(u => new {u.Email, u.IsDeleted});
            entity.Property(u => u.Email).IsRequired().HasMaxLength(100);
            entity.Property(u => u.FirstName).IsRequired().HasMaxLength(200);
            entity.Property(u => u.SecondName).IsRequired().HasMaxLength(200);
            entity.Property(u => u.Age).IsRequired();
        });

        modelBuilder.Entity<TripEntity>(entity =>
        {
            entity.HasKey(t => t.Id);
            
            entity.Property(t => t.StartPlace).HasMaxLength(200);
            entity.Property(t => t.EndPlace).HasMaxLength(200);
            entity.Property(t => t.Description).HasMaxLength(1000);
            entity.Property(t => t.CarModel).HasMaxLength(200);
            entity.Property(t => t.CarNumber).HasMaxLength(10);

            entity.HasOne(t => t.Creator)
                .WithMany()
                .HasForeignKey(t => t.CreatorId);
        });

        modelBuilder.Entity<TripPassengerEntity>(entity =>
        {
            entity.HasKey(p => p.Id);

            entity.HasOne(p => p.Trip)
                .WithMany()
                .HasForeignKey(p => p.TripId);

            entity.HasOne(p => p.Passenger)
                .WithMany()
                .HasForeignKey(p => p.PassengerId);
        });

        modelBuilder.Entity<UserVerificationEntity>(entity =>
        {
            entity.HasKey(u => u.Id);

            entity.Property(v => v.UnconfirmedEmail).HasMaxLength(100);
            entity.Property(v => v.UnconfirmedEmailCode).HasMaxLength(64);

            entity.HasOne(v => v.User)
                .WithMany();
            
            entity.HasIndex(v => new { v.UnconfirmedEmailCode, UnconfirmedEmailCodeExpirationAt = v.VerificationCodeExpiredAt });
            entity.HasIndex(v => new { v.UserId, UnconfirmedEmailCodeCreatedAt = v.VerificationCodeCreatedAt });
        });
    }
}