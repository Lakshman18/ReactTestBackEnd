using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APP.DAL.Entities;

public partial class SchoolDbContext : DbContext
{
    public SchoolDbContext()
    {
    }

    public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AllocateClassRoom> AllocateClassRooms { get; set; }

    public virtual DbSet<AllocateSubject> AllocateSubjects { get; set; }

    public virtual DbSet<ClassRoom> ClassRooms { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AllocateClassRoom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Allocate__3213E83FC567C7FA");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClassRoomId).HasColumnName("classRoomId");
            entity.Property(e => e.TeacherId).HasColumnName("teacherId");

            entity.HasOne(d => d.ClassRoom).WithMany(p => p.AllocateClassRooms)
                .HasForeignKey(d => d.ClassRoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AllocateC__class__47DBAE45");

            entity.HasOne(d => d.Teacher).WithMany(p => p.AllocateClassRooms)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AllocateC__teach__46E78A0C");
        });

        modelBuilder.Entity<AllocateSubject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Allocate__3213E83F9614A29B");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.SubjectId).HasColumnName("subjectId");
            entity.Property(e => e.TeacherId).HasColumnName("teacherId");

            entity.HasOne(d => d.Subject).WithMany(p => p.AllocateSubjects)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AllocateS__subje__440B1D61");

            entity.HasOne(d => d.Teacher).WithMany(p => p.AllocateSubjects)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AllocateS__teach__4316F928");
        });

        modelBuilder.Entity<ClassRoom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ClassRoo__3213E83FE572BE8C");

            entity.ToTable("ClassRoom");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3213E83F8E4A625A");

            entity.ToTable("Student");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.ClassRoomId).HasColumnName("classRoomId");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("contact_number");
            entity.Property(e => e.ContactPerson)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("contact_person");
            entity.Property(e => e.Dob)
                .HasColumnType("date")
                .HasColumnName("dob");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");

            entity.HasOne(d => d.ClassRoom).WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassRoomId)
                .HasConstraintName("FK__Student__classRo__403A8C7D");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subject__3213E83F244AC7BA");

            entity.ToTable("Subject");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Teacher__3213E83FB1E3F73E");

            entity.ToTable("Teacher");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("contact_number");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
