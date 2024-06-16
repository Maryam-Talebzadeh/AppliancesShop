﻿// <auto-generated />
using System;
using AM.Infrastructure.DB.SqlServer.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AM.Infrastructure.DB.SqlServer.EFCore.Migrations
{
    [DbContext(typeof(AccountContext))]
    [Migration("20240616162227_AddColleagueUserRole")]
    partial class AddColleagueUserRole
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AM.Domain.Core.AccountAgg.Entities.Account", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ProfilePhoto")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreationDate = new DateTime(2024, 6, 16, 9, 22, 20, 791, DateTimeKind.Local).AddTicks(1107),
                            Fullname = "Mary",
                            IsRemoved = false,
                            Mobile = "09386485663",
                            Password = "10000.lyz67IGPgBUonnD4LNGVTQ==.4tH6b2mcWg+vVPSEHhzaEX0aatIlFdqGDcI+NUA/VLA=",
                            ProfilePhoto = "DefaultAvatar.jpg",
                            RoleId = 1L,
                            Username = "Mary"
                        });
                });

            modelBuilder.Entity("AM.Domain.Core.RoleAgg.Entities.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreationDate = new DateTime(2024, 6, 16, 9, 22, 20, 793, DateTimeKind.Local).AddTicks(440),
                            IsRemoved = false,
                            Name = "مدیرسیستم"
                        },
                        new
                        {
                            Id = 2L,
                            CreationDate = new DateTime(2024, 6, 16, 9, 22, 20, 793, DateTimeKind.Local).AddTicks(757),
                            IsRemoved = false,
                            Name = "کاربر عادی"
                        },
                        new
                        {
                            Id = 3L,
                            CreationDate = new DateTime(2024, 6, 16, 9, 22, 20, 793, DateTimeKind.Local).AddTicks(816),
                            IsRemoved = false,
                            Name = "محتوا گذار"
                        },
                        new
                        {
                            Id = 4L,
                            CreationDate = new DateTime(2024, 6, 16, 9, 22, 20, 793, DateTimeKind.Local).AddTicks(864),
                            IsRemoved = false,
                            Name = "کاربر همکار"
                        });
                });

            modelBuilder.Entity("AM.Domain.Core.AccountAgg.Entities.Account", b =>
                {
                    b.HasOne("AM.Domain.Core.RoleAgg.Entities.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("AM.Domain.Core.RoleAgg.Entities.Role", b =>
                {
                    b.OwnsMany("AM.Domain.Core.RoleAgg.Entities.Permission", "Permissions", b1 =>
                        {
                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<long>("Id"));

                            b1.Property<int>("Code")
                                .HasColumnType("int");

                            b1.Property<long>("RoleId")
                                .HasColumnType("bigint");

                            b1.HasKey("Id");

                            b1.HasIndex("RoleId");

                            b1.ToTable("RolePermissions", (string)null);

                            b1.WithOwner("Role")
                                .HasForeignKey("RoleId");

                            b1.Navigation("Role");

                            b1.HasData(
                                new
                                {
                                    Id = 1L,
                                    Code = 52,
                                    RoleId = 1L
                                },
                                new
                                {
                                    Id = 2L,
                                    Code = 53,
                                    RoleId = 1L
                                },
                                new
                                {
                                    Id = 3L,
                                    Code = 54,
                                    RoleId = 1L
                                },
                                new
                                {
                                    Id = 4L,
                                    Code = 55,
                                    RoleId = 1L
                                },
                                new
                                {
                                    Id = 18L,
                                    Code = 50,
                                    RoleId = 1L
                                },
                                new
                                {
                                    Id = 6L,
                                    Code = 56,
                                    RoleId = 1L
                                },
                                new
                                {
                                    Id = 7L,
                                    Code = 51,
                                    RoleId = 1L
                                },
                                new
                                {
                                    Id = 8L,
                                    Code = 12,
                                    RoleId = 1L
                                },
                                new
                                {
                                    Id = 9L,
                                    Code = 13,
                                    RoleId = 1L
                                },
                                new
                                {
                                    Id = 10L,
                                    Code = 10,
                                    RoleId = 1L
                                },
                                new
                                {
                                    Id = 11L,
                                    Code = 11,
                                    RoleId = 1L
                                },
                                new
                                {
                                    Id = 12L,
                                    Code = 22,
                                    RoleId = 1L
                                },
                                new
                                {
                                    Id = 13L,
                                    Code = 23,
                                    RoleId = 1L
                                },
                                new
                                {
                                    Id = 14L,
                                    Code = 20,
                                    RoleId = 1L
                                },
                                new
                                {
                                    Id = 15L,
                                    Code = 21,
                                    RoleId = 1L
                                });
                        });

                    b.Navigation("Permissions");
                });

            modelBuilder.Entity("AM.Domain.Core.RoleAgg.Entities.Role", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
