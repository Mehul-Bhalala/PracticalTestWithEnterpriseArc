using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Practical.Repo;

namespace Practical.Repo.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20170906221200_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Practical.Data.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("IsActive");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Practical.Data.UserService", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<long>("ServiceId");

                    b.HasKey("UserId", "ServiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("UserService");
                });

            modelBuilder.Entity("Practical.Data.UService", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("UService");
                });

            modelBuilder.Entity("Practical.Data.UserService", b =>
                {
                    b.HasOne("Practical.Data.UService", "Service")
                        .WithMany("UserServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Practical.Data.User", "User")
                        .WithMany("UserServices")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
