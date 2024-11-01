﻿// <auto-generated />
using System;
using APS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APS.Data.Migrations
{
    [DbContext(typeof(ApdatadbContext))]
    partial class ApdatadbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APS.Data.Models.Account", b =>
            {
                b.Property<int>("AccountId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasColumnName("account_id");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"));

                b.Property<string>("AccountType")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("account_type");

                b.Property<decimal?>("Balance")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("decimal(10, 2)")
                    .HasDefaultValue(0.00m)
                    .HasColumnName("balance");

                b.Property<DateTime?>("CreatedAt")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                b.Property<int?>("UserId")
                    .HasColumnType("int")
                    .HasColumnName("user_id");

                b.HasKey("AccountId")
                    .HasName("PK__account__46A222CDB9FFDFD3");

                b.HasIndex("UserId");

                b.ToTable("account", (string)null);
            });

            modelBuilder.Entity("APS.Data.Models.Aprobacione", b =>
            {
                b.Property<int>("AprobacionId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasColumnName("aprobacion_id");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AprobacionId"));

                b.Property<string>("Criterio")
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("criterio");

                b.Property<bool>("Cumple")
                    .HasColumnType("bit")
                    .HasColumnName("cumple");

                b.Property<int>("EquipoId")
                    .HasColumnType("int")
                    .HasColumnName("equipo_id");

                b.HasKey("AprobacionId")
                    .HasName("PK__aprobaci__841444415F806074");

                b.HasIndex("EquipoId");

                b.ToTable("aprobaciones", (string)null);
            });

            modelBuilder.Entity("APS.Data.Models.Authorization", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasColumnName("id");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<string>("Pages")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)")
                    .HasColumnName("pages");

                b.Property<int>("UserId")
                    .HasColumnType("int")
                    .HasColumnName("userId");

                b.HasKey("Id")
                    .HasName("PK__authoriz__3213E83F41813066");

                b.HasIndex("UserId");

                b.ToTable("authorizations", (string)null);
            });

            modelBuilder.Entity("APS.Data.Models.Equipo", b =>
            {
                b.Property<int>("EquipoId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasColumnName("equipo_id");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EquipoId"));

                b.Property<string>("ContraseñaEquipo")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("contraseña_equipo");

                b.Property<string>("Descripcion")
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                b.Property<DateTime>("FechaIngreso")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_ingreso")
                    .HasDefaultValueSql("(getdate())");

                b.Property<bool>("GarantiaConLocal")
                    .HasColumnType("bit")
                    .HasColumnName("garantia_con_local");

                b.Property<string>("Marca")
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("marca");

                b.Property<string>("Modelo")
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("modelo");

                b.Property<string>("MotivoIngreso")
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("motivo_ingreso");

                b.Property<string>("NombreCliente")
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnType("varchar(150)")
                    .HasColumnName("nombre_cliente");

                b.Property<int>("UsuarioId")
                    .HasColumnType("int")
                    .HasColumnName("usuario_id");

                b.HasKey("EquipoId")
                    .HasName("PK__equipos__50EAD2BF9783599C");

                b.HasIndex("UsuarioId");

                b.ToTable("equipos", (string)null);
            });

            modelBuilder.Entity("APS.Data.Models.Notification", b =>
            {
                b.Property<int>("NotificationId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasColumnName("notification_id");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificationId"));

                b.Property<DateTime?>("CreatedAt")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                b.Property<bool?>("IsRead")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("bit")
                    .HasDefaultValue(false)
                    .HasColumnName("is_read");

                b.Property<string>("Message")
                    .HasColumnType("text")
                    .HasColumnName("message");

                b.Property<int?>("UserId")
                    .HasColumnType("int")
                    .HasColumnName("user_id");

                b.HasKey("NotificationId")
                    .HasName("PK__notifica__E059842FAF406580");

                b.HasIndex("UserId");

                b.ToTable("notifications", (string)null);
            });

            modelBuilder.Entity("APS.Data.Models.User", b =>
            {
                b.Property<int>("UserId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasColumnName("user_id");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                b.Property<DateTime?>("CreatedAt")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                b.Property<string>("Description")
                    .HasMaxLength(10)
                    .HasColumnType("nchar(10)")
                    .HasColumnName("description")
                    .IsFixedLength();

                b.Property<string>("Email")
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("email");

                b.Property<bool?>("IsAuthorized")
                    .HasColumnType("bit")
                    .HasColumnName("isAuthorized");

                b.Property<string>("Password")
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("password");

                b.Property<string>("Username")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("username");

                b.HasKey("UserId")
                    .HasName("PK__user__B9BE370F4435B8CB");

                b.HasIndex(new[] { "Email" }, "UQ_user_email")
                    .IsUnique();

                b.HasIndex(new[] { "Username" }, "UQ_user_username")
                    .IsUnique();

                b.ToTable("user", (string)null);
            });

            modelBuilder.Entity("APS.Data.Models.Account", b =>
            {
                b.HasOne("APS.Data.Models.User", "User")
                    .WithMany("Accounts")
                    .HasForeignKey("UserId")
                    .HasConstraintName("FK_account_user_id");

                b.Navigation("User");
            });

            modelBuilder.Entity("APS.Data.Models.Aprobacione", b =>
            {
                b.HasOne("APS.Data.Models.Equipo", "Equipo")
                    .WithMany("Aprobaciones")
                    .HasForeignKey("EquipoId")
                    .IsRequired()
                    .HasConstraintName("FK__aprobacio__equip__6D0D32F4");

                b.Navigation("Equipo");
            });

            modelBuilder.Entity("APS.Data.Models.Authorization", b =>
            {
                b.HasOne("APS.Data.Models.User", "User")
                    .WithMany("Authorizations")
                    .HasForeignKey("UserId")
                    .IsRequired()
                    .HasConstraintName("FK_authorizations_userId");

                b.Navigation("User");
            });

            modelBuilder.Entity("APS.Data.Models.Equipo", b =>
            {
                b.HasOne("APS.Data.Models.User", "Usuario")
                    .WithMany("Equipos")
                    .HasForeignKey("UsuarioId")
                    .IsRequired()
                    .HasConstraintName("FK__equipos__usuario__6A30C649");

                b.Navigation("Usuario");
            });

            modelBuilder.Entity("APS.Data.Models.Notification", b =>
            {
                b.HasOne("APS.Data.Models.User", "User")
                    .WithMany("Notifications")
                    .HasForeignKey("UserId")
                    .HasConstraintName("FK_notifications_user_id");

                b.Navigation("User");
            });

            modelBuilder.Entity("APS.Data.Models.Equipo", b =>
            {
                b.Navigation("Aprobaciones");
            });

            modelBuilder.Entity("APS.Data.Models.User", b =>
            {
                b.Navigation("Accounts");

                b.Navigation("Authorizations");

                b.Navigation("Equipos");

                b.Navigation("Notifications");
            });
#pragma warning restore 612, 618
        }
    }
}