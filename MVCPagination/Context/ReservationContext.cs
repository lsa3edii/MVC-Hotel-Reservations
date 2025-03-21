﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using MVCHotel.Models;
using Microsoft.EntityFrameworkCore;

namespace MVCHotel.Context;

public partial class ReservationContext : DbContext
{
    //public ReservationContext() { }

    public ReservationContext(DbContextOptions<ReservationContext> options)
        : base(options) { }


    public virtual DbSet<Reservation> Reservations { get; set; }


    // EF Core gets the connection string from Program.cs. The corrected class should look like this:

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Data Source=lSa3edii\\SQLEXPRESS01;Initial Catalog=MVC_FRONTEND_RESERVATION;Integrated Security=true;Encrypt=false;");


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC070939E04D");

            entity.ToTable("reservation");

            entity.Property(e => e.AptSuite)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("apt_suite");
            entity.Property(e => e.ArrivalTime)
                .HasColumnType("date")
                .HasColumnName("arrival_time");
            entity.Property(e => e.BirthDay)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("birth_day");
            entity.Property(e => e.BreakFast).HasColumnName("break_fast");
            entity.Property(e => e.CardCvc)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("card_cvc");
            entity.Property(e => e.CardExp)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("card_exp");
            entity.Property(e => e.CardNumber)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("card_number");
            entity.Property(e => e.CardType)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("card_type");
            entity.Property(e => e.CheckIn).HasColumnName("check_in");
            entity.Property(e => e.City)
                .IsRequired()
                .HasColumnName("city");
            entity.Property(e => e.Cleaning).HasColumnName("cleaning");
            entity.Property(e => e.Dinner).HasColumnName("dinner");
            entity.Property(e => e.EmailAddress)
                .IsRequired()
                .HasColumnName("email_address");
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.FoodBill).HasColumnName("food_bill");
            entity.Property(e => e.Gender)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("gender");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.LeavingTime)
                .HasColumnType("date")
                .HasColumnName("leaving_time");
            entity.Property(e => e.Lunch).HasColumnName("lunch");
            entity.Property(e => e.NumberGuest).HasColumnName("number_guest");
            entity.Property(e => e.PaymentType)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("payment_type");
            entity.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("phone_number");
            entity.Property(e => e.RoomFloor)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("room_floor");
            entity.Property(e => e.RoomNumber)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("room_number");
            entity.Property(e => e.RoomType)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("room_type");
            entity.Property(e => e.SSurprise).HasColumnName("s_surprise");
            entity.Property(e => e.State)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("state");
            entity.Property(e => e.StreetAddress)
                .IsRequired()
                .HasColumnName("street_address");
            entity.Property(e => e.SupplyStatus).HasColumnName("supply_status");
            entity.Property(e => e.TotalBill).HasColumnName("total_bill");
            entity.Property(e => e.Towel).HasColumnName("towel");
            entity.Property(e => e.ZipCode)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("zip_code");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
