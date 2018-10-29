﻿// <auto-generated />
using System;
using CustomerApi.Models.Relational;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CustomerApi.Migrations
{
    [DbContext(typeof(CustomerRelationalDBContext))]
    [Migration("20181029145639_CreateDatabase")]
    partial class CreateDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846");

            modelBuilder.Entity("CustomerApi.Models.Relational.CustomerRecord", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CustomerApi.Models.Relational.PhoneRecord", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AreaCode");

                    b.Property<long?>("CustomerRecordId");

                    b.Property<int>("Number");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("CustomerRecordId");

                    b.ToTable("PhoneRecord");
                });

            modelBuilder.Entity("CustomerApi.Models.Relational.PhoneRecord", b =>
                {
                    b.HasOne("CustomerApi.Models.Relational.CustomerRecord")
                        .WithMany("Phones")
                        .HasForeignKey("CustomerRecordId");
                });
#pragma warning restore 612, 618
        }
    }
}