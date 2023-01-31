using Insurance_Portal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Insurance_Portal.Infrastructure.Persistance;

public partial class InsuranceDBContext : DbContext
{

  public InsuranceDBContext(DbContextOptions<InsuranceDBContext> options) : base(options)
  {

  }

  public virtual DbSet<AuthDetail> AuthDetails { get; set; }

  public virtual DbSet<Policy> Policies { get; set; }

  public virtual DbSet<UserDetail> UserDetails { get; set; }

  public virtual DbSet<UserPolicy> UserPolicies { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder
        .UseCollation("utf8mb3_general_ci")
        .HasCharSet("utf8mb3");

    modelBuilder.Entity<AuthDetail>(entity =>
    {
      entity.HasKey(e => e.Email).HasName("PRIMARY");

      entity.ToTable("AuthDetail");

      entity.Property(e => e.Email)
              .HasMaxLength(50)
              .HasColumnName("email");
      entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");
      entity.Property(e => e.Password)
              .HasMaxLength(60)
              .IsFixedLength()
              .HasColumnName("password");
    });

    modelBuilder.Entity<Policy>(entity =>
    {
      entity.HasKey(e => e.PolicyId).HasName("PRIMARY");

      entity.ToTable("Policy");

      entity.Property(e => e.PolicyId).HasColumnName("policyId");
      entity.Property(e => e.PolicyDescription)
              .HasColumnType("mediumtext")
              .HasColumnName("policyDescription");
      entity.Property(e => e.PolicyName)
              .HasMaxLength(50)
              .HasColumnName("policyName");
      entity.Property(e => e.PolicyPrice)
              .HasColumnType("double(10,2)")
              .HasColumnName("policyPrice");
      entity.Property(e => e.PolicyType)
              .HasMaxLength(30)
              .HasColumnName("policyType");
      entity.Property(e => e.PolicyValidity).HasColumnName("policyValidity");
    });

    modelBuilder.Entity<UserDetail>(entity =>
    {
      entity.HasKey(e => e.Email).HasName("PRIMARY");

      entity.ToTable("UserDetail");

      entity.Property(e => e.Email)
              .HasMaxLength(50)
              .HasColumnName("email");
      entity.Property(e => e.Address)
              .HasMaxLength(255)
              .HasColumnName("address");
      entity.Property(e => e.Dob)
              .HasMaxLength(10)
              .HasColumnName("dob");
      entity.Property(e => e.FirstName)
              .HasMaxLength(50)
              .HasColumnName("firstName");
      entity.Property(e => e.Gender)
              .HasMaxLength(10)
              .HasColumnName("gender");
      entity.Property(e => e.LastName)
              .HasMaxLength(50)
              .HasColumnName("lastName");
      entity.Property(e => e.MobileNumber).HasColumnName("mobileNumber");
    });

    modelBuilder.Entity<UserPolicy>(entity =>
    {
      entity.HasKey(e => e.RecordId).HasName("PRIMARY");

      entity.ToTable("UserPolicy");

      entity.HasIndex(e => e.PolicyUserId, "email_idx");

      entity.HasIndex(e => e.PolicyId, "policyId_idx");

      entity.Property(e => e.RecordId).HasColumnName("recordId");
      entity.Property(e => e.PolicyEndDate)
              .HasMaxLength(10)
              .HasColumnName("policyEndDate");
      entity.Property(e => e.PolicyId).HasColumnName("policyId");
      entity.Property(e => e.PolicyStartDate)
              .HasMaxLength(10)
              .HasColumnName("policyStartDate");
      entity.Property(e => e.PolicyStatus)
              .HasMaxLength(10)
              .HasDefaultValueSql("'PENDING'")
              .HasColumnName("policyStatus");
      entity.Property(e => e.PolicyUserId)
              .HasMaxLength(50)
              .HasColumnName("policyUserId");

      entity.HasOne(d => d.Policy).WithMany(p => p.UserPolicies)
              .HasForeignKey(d => d.PolicyId)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("policyId");

      entity.HasOne(d => d.PolicyUser).WithMany(p => p.UserPolicies)
              .HasForeignKey(d => d.PolicyUserId)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("email");
    });

    OnModelCreatingPartial(modelBuilder);
  }

  partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
