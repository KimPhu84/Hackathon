using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BodyBuilderApp.Models
{
    public partial class BodyBuilderAppContext : DbContext
    {
        public BodyBuilderAppContext()
        {
        }

        public BodyBuilderAppContext(DbContextOptions<BodyBuilderAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BodyStatus> BodyStatuses { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DailyFoodDetail> DailyFoodDetails { get; set; }
        public virtual DbSet<Exercise> Exercises { get; set; }
        public virtual DbSet<FoodDetail> FoodDetails { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<ScheduleExercise> ScheduleExercises { get; set; }
        public virtual DbSet<Target> Targets { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=(local);Uid=sa;Pwd=123;Database=BodyBuilderApp");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BodyStatus>(entity =>
            {
                entity.ToTable("BodyStatus");

                entity.Property(e => e.BodyStatusId).HasMaxLength(50);

                entity.Property(e => e.Date)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BodyStatuses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BodyStatus_Customer");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("Customer");

                entity.Property(e => e.UserId).HasMaxLength(50);

                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.BodyStatusId).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Role).IsRequired();

                entity.Property(e => e.TargetId).HasMaxLength(50);

                entity.HasOne(d => d.Target)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.TargetId)
                    .HasConstraintName("FK_Customer_Target");
            });

            modelBuilder.Entity<DailyFoodDetail>(entity =>
            {
                entity.ToTable("DailyFoodDetail");

                entity.Property(e => e.DailyFoodDetailId).HasMaxLength(50);

                entity.Property(e => e.DailyFoodId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FoodName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Recommend)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TimeToEat)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.FoodNameNavigation)
                    .WithMany(p => p.DailyFoodDetails)
                    .HasForeignKey(d => d.FoodName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DailyFoodDetail_FoodDetail");
            });

            modelBuilder.Entity<Exercise>(entity =>
            {
                entity.ToTable("Exercise");

                entity.Property(e => e.ExerciseId).HasMaxLength(50);

                entity.Property(e => e.BodyPart)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ExerciseName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Step)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<FoodDetail>(entity =>
            {
                entity.HasKey(e => e.FoodName);

                entity.ToTable("FoodDetail");

                entity.Property(e => e.FoodName).HasMaxLength(50);

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule");

                entity.Property(e => e.ScheduleId).HasMaxLength(50);

                entity.Property(e => e.EndDate)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TrainerId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Trainer)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.TrainerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Schedule_Trainer");
            });

            modelBuilder.Entity<ScheduleExercise>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ScheduleExercise");

                entity.Property(e => e.ExerciseId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ScheduleId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Exercise)
                    .WithMany()
                    .HasForeignKey(d => d.ExerciseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ScheduleExercise_Exercise1");

                entity.HasOne(d => d.Schedule)
                    .WithMany()
                    .HasForeignKey(d => d.ScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ScheduleExercise_Schedule");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ScheduleExercise_Customer");
            });

            modelBuilder.Entity<Target>(entity =>
            {
                entity.ToTable("Target");

                entity.Property(e => e.TargetId).HasMaxLength(50);

                entity.Property(e => e.TargetName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Trainer>(entity =>
            {
                entity.ToTable("Trainer");

                entity.Property(e => e.TrainerId).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
