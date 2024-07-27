//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;

//namespace ThirdTryOfASPNETCOREWEBAPI.Models;

//public partial class MydbContext : DbContext
//{
//    public MydbContext()
//    {
//    }

//    public MydbContext(DbContextOptions<MydbContext> options)
//        : base(options)
//    {
//    }

//    public virtual DbSet<Student> Students { get; set; }



//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {

//        modelBuilder.Entity<Student>(entity =>
//        {
//            // Define the primary key
//            entity.HasKey(e => e.StudentId);

//            // Define the table name
//            entity.ToTable("STUDENTS");

//            entity.Property(e => e.StudentId)
//                .HasColumnName("STUDENT_ID");

//            entity.Property(e => e.FatherName)
//                .HasMaxLength(220)
//                .IsUnicode(false);
//            entity.Property(e => e.StudentGender)
//                .HasMaxLength(220)
//                .IsUnicode(false);
//            entity.Property(e => e.StudentName)
//                .HasMaxLength(220)
//                .IsUnicode(false);
//        });

//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ThirdTryOfASPNETCOREWEBAPI.Models;

public partial class MydbContext : DbContext
{
    public MydbContext()
    {
    }

    public MydbContext(DbContextOptions<MydbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            // Define the primary key
            entity.HasKey(e => e.StudentId);

            // Define the table name
            entity.ToTable("STUDENTS");

            entity.Property(e => e.StudentId)
                .HasColumnName("Id"); // Add this line to map the StudentId property to the correct column if needed

            entity.Property(e => e.FatherName)
                .HasMaxLength(220)
                .IsUnicode(false);
            entity.Property(e => e.StudentGender)
                .HasMaxLength(220)
                .IsUnicode(false);
            entity.Property(e => e.StudentName)
                .HasMaxLength(220)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

