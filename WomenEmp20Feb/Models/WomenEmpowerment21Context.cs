using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WomenEmp20Feb.Models;

namespace WomenEmp20Feb.Models
{
    public partial class WomenEmpowerment21Context : DbContext
    {
        public WomenEmpowerment21Context()
        {
        }

        public WomenEmpowerment21Context(DbContextOptions<WomenEmpowerment21Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Coursecategory> Coursecategories { get; set; } = null!;
        public virtual DbSet<Enrollment> Enrollments { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<Ngo> Ngos { get; set; } = null!;
        public virtual DbSet<Trainer> Trainers { get; set; } = null!;
        public virtual DbSet<Woman> Women { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
              //  optionsBuilder.UseSqlServer("Server=NILAMA\\SQLEXPRESS;Database=WomenEmpowerment21;user id=sa;password=newuser123#;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("admin");

                entity.Property(e => e.AdminId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("admin_id");

                entity.Property(e => e.AdminPassword)
                    .IsUnicode(false)
                    .HasColumnName("admin_password");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("course");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.Approvedstatus)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("approvedstatus")
                    .HasDefaultValueSql("('pending')");

                entity.Property(e => e.CourseDescription)
                    .HasMaxLength(3000)
                    .IsUnicode(false)
                    .HasColumnName("course_description");

                entity.Property(e => e.CourseEndDate)
                    .HasColumnType("date")
                    .HasColumnName("course_end_date");

                entity.Property(e => e.CourseName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("course_name");

                entity.Property(e => e.CourseStartDate)
                    .HasColumnType("date")
                    .HasColumnName("course_start_date");

                entity.Property(e => e.Coursecategory).HasColumnName("coursecategory");

                entity.Property(e => e.Currentseats).HasColumnName("currentseats");

                entity.Property(e => e.IntitialSeats).HasColumnName("intitial_seats");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TrainerId).HasColumnName("trainer_id");

                entity.HasOne(d => d.CoursecategoryNavigation)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.Coursecategory)
                    .HasConstraintName("FK__course__courseca__5165187F");

                entity.HasOne(d => d.Trainer)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.TrainerId)
                    .HasConstraintName("FK__course__trainer___5070F446");
            });

            modelBuilder.Entity<Coursecategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__courseca__D54EE9B4C5012684");

                entity.ToTable("coursecategory");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("category_name");
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasKey(e => new { e.WomenId, e.CourseId })
                    .HasName("PK__enrollme__01C02073F7947CCD");

                entity.ToTable("enrollment");

                entity.Property(e => e.WomenId).HasColumnName("women_id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.ApprovalDate)
                    .HasColumnType("date")
                    .HasColumnName("approval_date");

                entity.Property(e => e.ApprovalStatus)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("approval_status")
                    .HasDefaultValueSql("('pending')");

                entity.Property(e => e.Enrollmentdate)
                    .HasColumnType("date")
                    .HasColumnName("enrollmentdate")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__enrollmen__cours__534D60F1");

                entity.HasOne(d => d.Women)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.WomenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__enrollmen__women__52593CB8");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("feedback");

                entity.Property(e => e.FeedbackId).HasColumnName("feedback_id");

                entity.Property(e => e.FeedbackDate)
                    .HasColumnType("date")
                    .HasColumnName("feedback_date");

                entity.Property(e => e.FeedbackDescription)
                    .IsUnicode(false)
                    .HasColumnName("feedback_description");

                entity.Property(e => e.WomenId).HasColumnName("women_id");

                entity.HasOne(d => d.Women)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.WomenId)
                    .HasConstraintName("FK__feedback__women___5441852A");
            });

            modelBuilder.Entity<Ngo>(entity =>
            {
                entity.ToTable("ngo");

                entity.HasIndex(e => e.NgoEmail, "UQ__ngo__5A6971627ADEEDA1")
                    .IsUnique();

                entity.Property(e => e.NgoId).HasColumnName("ngo_id");

                entity.Property(e => e.Approvedstatus)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("approvedstatus")
                    .HasDefaultValueSql("('pending')");

                entity.Property(e => e.ContactPerson)
                    .IsUnicode(false)
                    .HasColumnName("contact_person");

                entity.Property(e => e.NgoAddress)
                    .IsUnicode(false)
                    .HasColumnName("ngo_address");

                entity.Property(e => e.NgoCity)
                    .IsUnicode(false)
                    .HasColumnName("ngo_city");

                entity.Property(e => e.NgoContactNumber)
                    .IsUnicode(false)
                    .HasColumnName("ngo_contact_number");

                entity.Property(e => e.NgoDescription)
                    .IsUnicode(false)
                    .HasColumnName("ngo_description");

                entity.Property(e => e.NgoEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ngo_email");

                entity.Property(e => e.NgoName)
                    .IsUnicode(false)
                    .HasColumnName("ngo_name");

                entity.Property(e => e.NgoPassword)
                    .IsUnicode(false)
                    .HasColumnName("ngo_password");

                entity.Property(e => e.NgoState)
                    .IsUnicode(false)
                    .HasColumnName("ngo_state");

                entity.Property(e => e.NgoSupportingdocument)
                    .IsUnicode(false)
                    .HasColumnName("ngo_supportingdocument");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Trainer>(entity =>
            {
                entity.ToTable("Trainer");

                entity.Property(e => e.TrainerId).HasColumnName("trainer_id");

                entity.Property(e => e.NgoId).HasColumnName("ngo_id");

                entity.Property(e => e.TrainerContactNumber)
                    .IsUnicode(false)
                    .HasColumnName("trainer_contact_number");

                entity.Property(e => e.TrainerEmail)
                    .IsUnicode(false)
                    .HasColumnName("trainer_email");

                entity.Property(e => e.TrainerFullName)
                    .IsUnicode(false)
                    .HasColumnName("trainer_full_name");

                entity.HasOne(d => d.Ngo)
                    .WithMany(p => p.Trainers)
                    .HasForeignKey(d => d.NgoId)
                    .HasConstraintName("FK__Trainer__ngo_id__5535A963");
            });

            modelBuilder.Entity<Woman>(entity =>
            {
                entity.HasKey(e => e.WomenId)
                    .HasName("PK__women__F931CF090588195D");

                entity.ToTable("women");

                entity.HasIndex(e => e.WomenEmail, "UQ__women__7C85DBC4D539311C")
                    .IsUnique();

                entity.Property(e => e.WomenId).HasColumnName("women_id");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.WomenAddress)
                    .IsUnicode(false)
                    .HasColumnName("women_address");

                entity.Property(e => e.WomenCity)
                    .IsUnicode(false)
                    .HasColumnName("women_city");

                entity.Property(e => e.WomenContactNumber)
                    .IsUnicode(false)
                    .HasColumnName("women_contact_number");

                entity.Property(e => e.WomenDocument)
                    .IsUnicode(false)
                    .HasColumnName("women_document");

                entity.Property(e => e.WomenEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("women_email");

                entity.Property(e => e.WomenFathername)
                    .IsUnicode(false)
                    .HasColumnName("women_fathername");

                entity.Property(e => e.WomenFullName)
                    .IsUnicode(false)
                    .HasColumnName("women_full_name");

                entity.Property(e => e.WomenMaritalStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("women_marital_status");

                entity.Property(e => e.WomenMothername)
                    .IsUnicode(false)
                    .HasColumnName("women_mothername");

                entity.Property(e => e.WomenPassword)
                    .IsUnicode(false)
                    .HasColumnName("women_password");

                entity.Property(e => e.WomenSpousename)
                    .IsUnicode(false)
                    .HasColumnName("women_spousename");

                entity.Property(e => e.WomenState)
                    .IsUnicode(false)
                    .HasColumnName("women_state");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<WomenEmp20Feb.Models.Login> Login { get; set; }
    }
}
