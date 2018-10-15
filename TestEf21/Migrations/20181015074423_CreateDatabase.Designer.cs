﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestEf21;

namespace TestEf21.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20181015074423_CreateDatabase")]
    partial class CreateDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestEf21.ChildEntity", b =>
                {
                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CanView");

                    b.Property<int>("ParentKey");

                    b.HasKey("Key");

                    b.HasIndex("ParentKey");

                    b.ToTable("Children");

                    b.HasData(
                        new { Key = 1, CanView = true, ParentKey = 1 },
                        new { Key = 2, CanView = false, ParentKey = 1 },
                        new { Key = 3, CanView = false, ParentKey = 2 },
                        new { Key = 4, CanView = false, ParentKey = 2 }
                    );
                });

            modelBuilder.Entity("TestEf21.ParentEntity", b =>
                {
                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Key");

                    b.ToTable("Parents");

                    b.HasData(
                        new { Key = 1, Name = "Object1" },
                        new { Key = 2, Name = "Object2" }
                    );
                });

            modelBuilder.Entity("TestEf21.ChildEntity", b =>
                {
                    b.HasOne("TestEf21.ParentEntity", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
