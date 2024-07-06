using HexagonalBackEnd.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalBackEnd.Infrastructure.SQL.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Id");

                entity.ToTable("Employee");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Password)
                    .HasMaxLength(400)
                    .IsUnicode(false);
                entity.Property(e => e.IdRole);
                entity.Property(e => e.IdAreaLeader);
                entity.HasOne(b => b.Role)
                                  .WithMany(b => b.Employess)
                                  .HasForeignKey(b => b.IdRole);
                entity.HasOne(b => b.AreaLeader)
                                  .WithMany(b => b.Employees)
                                  .HasForeignKey(b => b.IdAreaLeader);
            });

            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Area");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.CreationDate);
                entity.Property(e => e.UpdateDate);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Role");
                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.CreationDate);
                entity.Property(e => e.UpdateDate);
            });


            modelBuilder.Entity<AreaLeader>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("AreaLeader");
                entity.HasIndex(e => e.IdLeaderArea).IsUnique();
                entity.HasIndex(e => e.IdArea);
                entity.HasOne(b => b.Employee)
                                  .WithMany(b => b.AreaLeaders)
                                  .HasForeignKey(b => b.IdLeaderArea)
                                  .OnDelete(DeleteBehavior.ClientNoAction);
                entity.HasOne(b => b.Area)
                                  .WithMany(b => b.AreaLeaders)
                                  .HasForeignKey(b => b.IdArea);
                entity.Property(e => e.CreationDate);
                entity.Property(e => e.UpdateDate);
            });


            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("State");
                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.CreationDate);
                entity.Property(e => e.UpdateDate);
            });

            modelBuilder.Entity<RemunerationType>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("RemunerationType");
                entity.Property(e => e.Code)
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .HasMaxLength(50);
                entity.Property(e => e.CreationDate);
                entity.Property(e => e.UpdateDate);
            });

            modelBuilder.Entity<OvertimeHours>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("OvertimeHours");
                entity.Property(e => e.Justification)
                .HasMaxLength(50);
                entity.Property(e => e.JustificationState)
                    .HasMaxLength(50);
                entity.Property(e => e.RemunerationDate);
                entity.Property(e => e.RemunerationHours);
                entity.Property(e => e.IdEmployee);
                entity.Property(e => e.IdApprover);
                entity.Property(e => e.IdRemunerationType);
                entity.Property(e => e.IdState);
                entity.HasOne(b => b.Employee)
                                 .WithMany(b => b.OvertimeHoursEmployees)
                                 .HasForeignKey(b => b.IdEmployee)
                                 .OnDelete(DeleteBehavior.ClientNoAction);
                entity.HasOne(b => b.Aproveer)
                                 .WithMany(b => b.OvertimeHoursLeaders)
                                 .HasForeignKey(b => b.IdApprover)
                                 .OnDelete(DeleteBehavior.ClientNoAction);
                entity.HasOne(b => b.RemunerationType)
                                 .WithMany(b => b.OvertimeHours)
                                 .HasForeignKey(b => b.IdRemunerationType);
                entity.HasOne(b => b.State)
                                 .WithMany(b => b.OvertimeHours)
                                 .HasForeignKey(b => b.IdState);
                entity.Property(e => e.CreationDate);
                entity.Property(e => e.UpdateDate);

            });

            modelBuilder.Entity<HistoryOvertime>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("HistoryOvertime");
                entity.Property(e => e.Comments)
                .HasMaxLength(100);
                entity.Property(e => e.IdEmployee);
                entity.Property(e => e.IdApprover);
                entity.Property(e => e.IdStateInitial);
                entity.Property(e => e.IdStateFinal);
                entity.HasOne(b => b.Employee)
                                 .WithMany(b => b.HistoryOvertimeEmployees)
                                 .HasForeignKey(b => b.IdEmployee)
                                 .OnDelete(DeleteBehavior.ClientNoAction);
                entity.HasOne(b => b.Approver)
                                 .WithMany(b => b.HistoryOvertimeApprovers)
                                 .HasForeignKey(b => b.IdApprover)
                                 .OnDelete(DeleteBehavior.ClientNoAction);
                entity.HasOne(b => b.InitialState)
                                 .WithMany(b => b.HistoryOvertimeInitialStates)
                                 .HasForeignKey(b => b.IdStateInitial)
                                 .OnDelete(DeleteBehavior.ClientNoAction);
                entity.HasOne(b => b.FinalState)
                                 .WithMany(b => b.HistoryOvertimeFinalStates)
                                 .HasForeignKey(b => b.IdStateFinal)
                                 .OnDelete(DeleteBehavior.ClientNoAction);
                entity.Property(e => e.CreationDate);
                entity.Property(e => e.UpdateDate);

            });
        }
        }
    }
