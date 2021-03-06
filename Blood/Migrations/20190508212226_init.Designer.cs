﻿// <auto-generated />
using System;
using Blood.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Blood.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20190508212226_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Blood.Models.EventBlood", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<int>("DonatedBlood");

                    b.Property<string>("PersonPesel");

                    b.HasKey("Id");

                    b.HasIndex("PersonPesel");

                    b.ToTable("EventBlood");
                });

            modelBuilder.Entity("Blood.Models.Person", b =>
                {
                    b.Property<string>("Pesel")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BloodGroup");

                    b.Property<int>("BloodType");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Pesel");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("Blood.Models.EventBlood", b =>
                {
                    b.HasOne("Blood.Models.Person", "Person")
                        .WithMany("EventBloods")
                        .HasForeignKey("PersonPesel");
                });
#pragma warning restore 612, 618
        }
    }
}
