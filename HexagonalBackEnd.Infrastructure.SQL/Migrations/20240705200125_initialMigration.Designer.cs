﻿// <auto-generated />
using System;
using HexagonalBackEnd.Infrastructure.SQL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HexagonalBackEnd.Infrastructure.SQL.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240705200125_initialMigration")]
    partial class initialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HexagonalBackEnd.Domain.Entities.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Area", (string)null);
                });

            modelBuilder.Entity("HexagonalBackEnd.Domain.Entities.AreaLeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdArea")
                        .HasColumnType("int");

                    b.Property<int>("IdLeaderArea")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdArea");

                    b.HasIndex("IdLeaderArea")
                        .IsUnique();

                    b.ToTable("AreaLeader", (string)null);
                });

            modelBuilder.Entity("HexagonalBackEnd.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdAreaLeader")
                        .HasColumnType("int");

                    b.Property<int?>("IdLeader")
                        .HasColumnType("int");

                    b.Property<int>("IdRole")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(400)
                        .IsUnicode(false)
                        .HasColumnType("varchar(400)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("Id");

                    b.HasIndex("IdAreaLeader");

                    b.HasIndex("IdRole");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("HexagonalBackEnd.Domain.Entities.HistoryOvertime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdApprover")
                        .HasColumnType("int");

                    b.Property<int>("IdEmployee")
                        .HasColumnType("int");

                    b.Property<int>("IdOvertimeHours")
                        .HasColumnType("int");

                    b.Property<int?>("IdStateFinal")
                        .HasColumnType("int");

                    b.Property<int?>("IdStateInitial")
                        .HasColumnType("int");

                    b.Property<DateTime>("MovementDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdApprover");

                    b.HasIndex("IdEmployee");

                    b.HasIndex("IdStateFinal");

                    b.HasIndex("IdStateInitial");

                    b.ToTable("HistoryOvertime", (string)null);
                });

            modelBuilder.Entity("HexagonalBackEnd.Domain.Entities.OvertimeHours", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdApprover")
                        .HasColumnType("int");

                    b.Property<int>("IdEmployee")
                        .HasColumnType("int");

                    b.Property<int>("IdRemunerationType")
                        .HasColumnType("int");

                    b.Property<int>("IdState")
                        .HasColumnType("int");

                    b.Property<string>("Justification")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("JustificationState")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("RemunerationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RemunerationHours")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdApprover");

                    b.HasIndex("IdEmployee");

                    b.HasIndex("IdRemunerationType");

                    b.HasIndex("IdState");

                    b.ToTable("OvertimeHours", (string)null);
                });

            modelBuilder.Entity("HexagonalBackEnd.Domain.Entities.RemunerationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("RemunerationType", (string)null);
                });

            modelBuilder.Entity("HexagonalBackEnd.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("HexagonalBackEnd.Domain.Entities.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("State", (string)null);
                });

            modelBuilder.Entity("HexagonalBackEnd.Domain.Entities.AreaLeader", b =>
                {
                    b.HasOne("HexagonalBackEnd.Domain.Entities.Area", "Area")
                        .WithMany("AreaLeaders")
                        .HasForeignKey("IdArea")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HexagonalBackEnd.Domain.Entities.Employee", "Employee")
                        .WithMany("AreaLeaders")
                        .HasForeignKey("IdLeaderArea")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Area");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("HexagonalBackEnd.Domain.Entities.Employee", b =>
                {
                    b.HasOne("HexagonalBackEnd.Domain.Entities.AreaLeader", "AreaLeader")
                        .WithMany("Employees")
                        .HasForeignKey("IdAreaLeader");

                    b.HasOne("HexagonalBackEnd.Domain.Entities.Role", "Role")
                        .WithMany("Employess")
                        .HasForeignKey("IdRole")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AreaLeader");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("HexagonalBackEnd.Domain.Entities.HistoryOvertime", b =>
                {
                    b.HasOne("HexagonalBackEnd.Domain.Entities.Employee", "Approver")
                        .WithMany("HistoryOvertimeApprovers")
                        .HasForeignKey("IdApprover")
                        .OnDelete(DeleteBehavior.ClientNoAction);

                    b.HasOne("HexagonalBackEnd.Domain.Entities.Employee", "Employee")
                        .WithMany("HistoryOvertimeEmployees")
                        .HasForeignKey("IdEmployee")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("HexagonalBackEnd.Domain.Entities.State", "FinalState")
                        .WithMany("HistoryOvertimeFinalStates")
                        .HasForeignKey("IdStateFinal")
                        .OnDelete(DeleteBehavior.ClientNoAction);

                    b.HasOne("HexagonalBackEnd.Domain.Entities.State", "InitialState")
                        .WithMany("HistoryOvertimeInitialStates")
                        .HasForeignKey("IdStateInitial")
                        .OnDelete(DeleteBehavior.ClientNoAction);

                    b.Navigation("Approver");

                    b.Navigation("Employee");

                    b.Navigation("FinalState");

                    b.Navigation("InitialState");
                });

            modelBuilder.Entity("HexagonalBackEnd.Domain.Entities.OvertimeHours", b =>
                {
                    b.HasOne("HexagonalBackEnd.Domain.Entities.Employee", "Aproveer")
                        .WithMany("OvertimeHoursLeaders")
                        .HasForeignKey("IdApprover")
                        .OnDelete(DeleteBehavior.ClientNoAction);

                    b.HasOne("HexagonalBackEnd.Domain.Entities.Employee", "Employee")
                        .WithMany("OvertimeHoursEmployees")
                        .HasForeignKey("IdEmployee")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("HexagonalBackEnd.Domain.Entities.RemunerationType", "RemunerationType")
                        .WithMany("OvertimeHours")
                        .HasForeignKey("IdRemunerationType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HexagonalBackEnd.Domain.Entities.State", "State")
                        .WithMany("OvertimeHours")
                        .HasForeignKey("IdState")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aproveer");

                    b.Navigation("Employee");

                    b.Navigation("RemunerationType");

                    b.Navigation("State");
                });

            modelBuilder.Entity("HexagonalBackEnd.Domain.Entities.Area", b =>
                {
                    b.Navigation("AreaLeaders");
                });

            modelBuilder.Entity("HexagonalBackEnd.Domain.Entities.AreaLeader", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("HexagonalBackEnd.Domain.Entities.Employee", b =>
                {
                    b.Navigation("AreaLeaders");

                    b.Navigation("HistoryOvertimeApprovers");

                    b.Navigation("HistoryOvertimeEmployees");

                    b.Navigation("OvertimeHoursEmployees");

                    b.Navigation("OvertimeHoursLeaders");
                });

            modelBuilder.Entity("HexagonalBackEnd.Domain.Entities.RemunerationType", b =>
                {
                    b.Navigation("OvertimeHours");
                });

            modelBuilder.Entity("HexagonalBackEnd.Domain.Entities.Role", b =>
                {
                    b.Navigation("Employess");
                });

            modelBuilder.Entity("HexagonalBackEnd.Domain.Entities.State", b =>
                {
                    b.Navigation("HistoryOvertimeFinalStates");

                    b.Navigation("HistoryOvertimeInitialStates");

                    b.Navigation("OvertimeHours");
                });
#pragma warning restore 612, 618
        }
    }
}
