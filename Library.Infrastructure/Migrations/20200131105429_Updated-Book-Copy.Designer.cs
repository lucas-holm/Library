﻿// <auto-generated />
using System;
using Library.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Library.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200131105429_Updated-Book-Copy")]
    partial class UpdatedBookCopy
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Library.Domain.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "William Shakespeare"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Villiam Skakspjut"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Robert C. Martin"
                        });
                });

            modelBuilder.Entity("Library.Domain.BookCopy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Condition")
                        .HasColumnType("int");

                    b.Property<int>("DetailsId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LoanStart")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DetailsId");

                    b.ToTable("BookCopies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Condition = 0,
                            DetailsId = 1
                        },
                        new
                        {
                            Id = 2,
                            Condition = 2,
                            DetailsId = 2
                        },
                        new
                        {
                            Id = 3,
                            Condition = 1,
                            DetailsId = 3
                        });
                });

            modelBuilder.Entity("Library.Domain.BookDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("BookDetails");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Description = "Arguably Shakespeare's greatest tragedy",
                            ISBN = "1472518381",
                            Title = "Hamlet"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 2,
                            Description = "King Lear is a tragedy written by William Shakespeare. It depicts the gradual descent into madness of the title character, after he disposes of his kingdom by giving bequests to two of his three daughters egged on by their continual flattery, bringing tragic consequences for all.",
                            ISBN = "9780141012292",
                            Title = "King Lear"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 3,
                            Description = "An intense drama of love, deception, jealousy and destruction.",
                            ISBN = "1853260185",
                            Title = "Othello"
                        });
                });

            modelBuilder.Entity("Library.Domain.Loan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookCopyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LoanEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LoanStart")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookCopyId");

                    b.HasIndex("MemberId");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("Library.Domain.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SSN")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Members");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Kjell Svantesson",
                            SSN = "1234567890"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Maja Svantesson",
                            SSN = "1122334455"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Ola Svantesson",
                            SSN = "5544332211"
                        });
                });

            modelBuilder.Entity("Library.Domain.BookCopy", b =>
                {
                    b.HasOne("Library.Domain.BookDetails", "Details")
                        .WithMany("Copies")
                        .HasForeignKey("DetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Library.Domain.BookDetails", b =>
                {
                    b.HasOne("Library.Domain.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Library.Domain.Loan", b =>
                {
                    b.HasOne("Library.Domain.BookCopy", "BookCopy")
                        .WithMany()
                        .HasForeignKey("BookCopyId");

                    b.HasOne("Library.Domain.Member", "Member")
                        .WithMany("Loans")
                        .HasForeignKey("MemberId");
                });
#pragma warning restore 612, 618
        }
    }
}
