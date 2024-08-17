﻿// <auto-generated />
using System;
using Eon.Com.Application.Configurations.Database.Postgresql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace tests_.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240817185021_AddTagToSectorRelationship")]
    partial class AddTagToSectorRelationship
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Eon.Com.Domain.Models.Entity.FlowEntity.Flow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("FolderId")
                        .HasColumnType("integer")
                        .HasColumnName("fluxo_pasta_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("fluxo_nome");

                    b.HasKey("Id");

                    b.HasIndex("FolderId");

                    b.ToTable("fluxos");
                });

            modelBuilder.Entity("Eon.Com.Domain.Models.Entity.FlowSharedEntity.FlowShared", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("FlowId")
                        .HasColumnType("integer")
                        .HasColumnName("id_fluxo");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("link");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean")
                        .HasColumnName("status");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("id_usuario");

                    b.HasKey("Id");

                    b.ToTable("fluxos_compartilhados");
                });

            modelBuilder.Entity("Eon.Com.Domain.Models.Entity.FolderEntity.Folder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nome_pasta");

                    b.HasKey("Id");

                    b.ToTable("pastas");
                });

            modelBuilder.Entity("Eon.Com.Domain.Models.Entity.MessageSchedulingEntity.MessageScheduling", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Flow")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("id_fluxo");

                    b.Property<string>("MessageText")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("mensagem_de_texto");

                    b.Property<DateTime>("SendDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("data_envio");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("id_etiqueta");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("id_usuario");

                    b.Property<string>("WhatsAppNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("numero_whatsapp");

                    b.HasKey("Id");

                    b.ToTable("mensagens_agendadas");
                });

            modelBuilder.Entity("Eon.Com.Domain.Models.Entity.SectorEntity.Sector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("descricao_setor");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nome_setor");

                    b.Property<int>("UserBusinessId")
                        .HasColumnType("integer")
                        .HasColumnName("user_business_id");

                    b.HasKey("Id");

                    b.HasIndex("UserBusinessId");

                    b.ToTable("setores");
                });

            modelBuilder.Entity("Eon.Com.Domain.Models.Entity.TagEntity.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("descricao_etiqueta");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nome_etiqueta");

                    b.Property<int>("SectorId")
                        .HasColumnType("integer")
                        .HasColumnName("sector_id");

                    b.HasKey("Id");

                    b.HasIndex("SectorId");

                    b.ToTable("etiquetas");
                });

            modelBuilder.Entity("Eon.Com.Domain.Models.Entity.TeamEntity.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("descricao_time");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nome_time");

                    b.Property<int>("SectorId")
                        .HasColumnType("integer")
                        .HasColumnName("sector_id");

                    b.HasKey("Id");

                    b.HasIndex("SectorId");

                    b.ToTable("times");
                });

            modelBuilder.Entity("Eon.Com.Domain.Models.Entity.TokenEntity.Token", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("token_acesso_usuario_id");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("token_acesso_valor");

                    b.Property<int>("token_acesso_usuario")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("token_acesso_usuario");

                    b.ToTable("tokens_acesso");
                });

            modelBuilder.Entity("Eon.Com.Domain.Models.Entity.UserEntity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("usuario_endereco");

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("text")
                        .HasColumnName("usuario_avatar_url");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("usuario_email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("usuario_nome");

                    b.Property<string>("Notes")
                        .HasColumnType("text")
                        .HasColumnName("usuario_anotacoes");

                    b.Property<string>("PhoneWhatsapp")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("usuario_numero_whatsapp");

                    b.Property<int?>("TeamId")
                        .HasColumnType("integer")
                        .HasColumnName("team_id");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("Eon.Com.Domain.Models.Entity.FlowEntity.Flow", b =>
                {
                    b.HasOne("Eon.Com.Domain.Models.Entity.FolderEntity.Folder", "Folder")
                        .WithMany()
                        .HasForeignKey("FolderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Folder");
                });

            modelBuilder.Entity("Eon.Com.Domain.Models.Entity.SectorEntity.Sector", b =>
                {
                    b.HasOne("Eon.Com.Domain.Models.Entity.UserEntity.User", "UserBusiness")
                        .WithMany()
                        .HasForeignKey("UserBusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserBusiness");
                });

            modelBuilder.Entity("Eon.Com.Domain.Models.Entity.TagEntity.Tag", b =>
                {
                    b.HasOne("Eon.Com.Domain.Models.Entity.SectorEntity.Sector", "Sector")
                        .WithMany()
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sector");
                });

            modelBuilder.Entity("Eon.Com.Domain.Models.Entity.TeamEntity.Team", b =>
                {
                    b.HasOne("Eon.Com.Domain.Models.Entity.SectorEntity.Sector", "Sector")
                        .WithMany("Teams")
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sector");
                });

            modelBuilder.Entity("Eon.Com.Domain.Models.Entity.TokenEntity.Token", b =>
                {
                    b.HasOne("Eon.Com.Domain.Models.Entity.UserEntity.User", "User")
                        .WithMany("Tokens")
                        .HasForeignKey("token_acesso_usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Eon.Com.Domain.Models.Entity.UserEntity.User", b =>
                {
                    b.HasOne("Eon.Com.Domain.Models.Entity.TeamEntity.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Eon.Com.Domain.Models.Entity.SectorEntity.Sector", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("Eon.Com.Domain.Models.Entity.UserEntity.User", b =>
                {
                    b.Navigation("Tokens");
                });
#pragma warning restore 612, 618
        }
    }
}
