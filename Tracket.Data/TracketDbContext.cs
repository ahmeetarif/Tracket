using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tracket.Entities.Entity;

namespace Tracket.Data
{
    public partial class TracketDbContext : IdentityDbContext<TracketUser>
    {
        public TracketDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<TicketPriority> TicketPriorities { get; set; }
        public virtual DbSet<TicketStatus> TicketStatuses { get; set; }
        public virtual DbSet<TicketType> TicketTypes { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }
        public virtual DbSet<UserPermission> UserPermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.CreatedByUserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.UpdatedUserId).HasMaxLength(450);

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.ProjectCreatedByUsers)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Projects_AspNetUsers_ProjectCreatedUserId");

                entity.HasOne(d => d.UpdatedUser)
                    .WithMany(p => p.ProjectUpdatedUsers)
                    .HasForeignKey(d => d.UpdatedUserId)
                    .HasConstraintName("FK_Projects_AspNetUsers_ProjectUpdatedUserId");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.SolvedByUserId).HasMaxLength(450);

                entity.Property(e => e.SubmitterUserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.UpdatedUserId).HasMaxLength(450);

                entity.HasOne(d => d.Priority)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.PriorityId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.SolvedByUser)
                    .WithMany(p => p.TicketSolvedByUsers)
                    .HasForeignKey(d => d.SolvedByUserId)
                    .HasConstraintName("FK_Tickets_AspNetUsers_TicketSolvedUserId");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.SubmitterUser)
                    .WithMany(p => p.TicketSubmitterUsers)
                    .HasForeignKey(d => d.SubmitterUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.UpdatedUser)
                    .WithMany(p => p.TicketUpdatedUsers)
                    .HasForeignKey(d => d.UpdatedUserId)
                    .HasConstraintName("FK_Tickets_AspNetUsers_TicketUpdatedUserId");
            });

            modelBuilder.Entity<TicketPriority>(entity =>
            {
                entity.Property(e => e.CreatedUserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.CreatedUser)
                    .WithMany(p => p.TicketPriorities)
                    .HasForeignKey(d => d.CreatedUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TicketPriorities_AspNetUsers_TicketPriorityCreatedUserId");
            });

            modelBuilder.Entity<TicketStatus>(entity =>
            {
                entity.ToTable("TicketStatus");

                entity.Property(e => e.CreatedUserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.CreatedUser)
                    .WithMany(p => p.TicketStatuses)
                    .HasForeignKey(d => d.CreatedUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TicketStatus_AspNetUsers_TicketStatusCreatedUserId");
            });

            modelBuilder.Entity<TicketType>(entity =>
            {
                entity.Property(e => e.CreatedUserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.CreatedUser)
                    .WithMany(p => p.TicketTypes)
                    .HasForeignKey(d => d.CreatedUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TicketTypes_AspNetUsers_TicketTypeCreatedUserId");
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ProfilePicturePath).IsRequired();

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserDetail)
                    .HasForeignKey<UserDetail>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserDetails_AspNetUsers_UserDetailsUserId");
            });

            modelBuilder.Entity<UserPermission>(entity =>
            {
                entity.HasKey(e => e.PermissionId);

                entity.Property(e => e.PermissionId).ValueGeneratedNever();

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Permission)
                    .WithOne(p => p.UserPermission)
                    .HasForeignKey<UserPermission>(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPermissions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserPermissions_AspNetUsers_PermissionUserId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}