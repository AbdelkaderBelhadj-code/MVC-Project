﻿// <auto-generated />
using System;
using AM.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    [DbContext(typeof(AMContext))]
    [Migration("20221218164830_initdb")]
    partial class initdb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AM.ApplicationCore.Domain.Fete", b =>
                {
                    b.Property<int>("IdFete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFete"), 1L, 1);

                    b.Property<DateTime>("DateFete")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Duree")
                        .HasColumnType("int");

                    b.Property<int>("NbInviteMax")
                        .HasColumnType("int");

                    b.Property<int>("SalleId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("IdFete");

                    b.HasIndex("SalleId");

                    b.ToTable("Fete");
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Invitation", b =>
                {
                    b.Property<int>("FeteFk")
                        .HasColumnType("int");

                    b.Property<int>("InviteFk")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateInvitation")
                        .HasColumnType("datetime2");

                    b.Property<bool>("ConfirmeInvitation")
                        .HasColumnType("bit");

                    b.HasKey("FeteFk", "InviteFk", "DateInvitation");

                    b.HasIndex("InviteFk");

                    b.ToTable("Invitation");
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Invite", b =>
                {
                    b.Property<int>("IdInvite")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdInvite"), 1L, 1);

                    b.Property<string>("AdresseInvite")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("IdInvite");

                    b.ToTable("Invite");
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Salle", b =>
                {
                    b.Property<int>("IdSalle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSalle"), 1L, 1);

                    b.Property<string>("AdresseSalle")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Capacite")
                        .HasColumnType("int");

                    b.Property<string>("NomSalle")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<double>("PrixParHeure")
                        .HasColumnType("float");

                    b.HasKey("IdSalle");

                    b.ToTable("Salle");
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Fete", b =>
                {
                    b.HasOne("AM.ApplicationCore.Domain.Salle", "Salle")
                        .WithMany("Fetes")
                        .HasForeignKey("SalleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Salle");
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Invitation", b =>
                {
                    b.HasOne("AM.ApplicationCore.Domain.Fete", "Fete")
                        .WithMany("Invitations")
                        .HasForeignKey("FeteFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AM.ApplicationCore.Domain.Invite", "Invite")
                        .WithMany("Invitations")
                        .HasForeignKey("InviteFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fete");

                    b.Navigation("Invite");
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Fete", b =>
                {
                    b.Navigation("Invitations");
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Invite", b =>
                {
                    b.Navigation("Invitations");
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Salle", b =>
                {
                    b.Navigation("Fetes");
                });
#pragma warning restore 612, 618
        }
    }
}