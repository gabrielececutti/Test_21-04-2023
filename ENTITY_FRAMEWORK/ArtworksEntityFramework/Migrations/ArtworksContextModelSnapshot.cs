﻿// <auto-generated />
using System;
using ArtworksEntityFramework.Repositories.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ArtworksEntityFramework.Migrations
{
    [DbContext(typeof(ArtworksContext))]
    partial class ArtworksContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ArtworksEntityFramework.Models.Entities.Artist", b =>
                {
                    b.Property<int>("IdArtist")
                        .HasColumnType("int")
                        .HasColumnName("Id_Artist");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdArtist")
                        .HasName("PK__Artist__FB56A91037BAC086");

                    b.ToTable("Artist", (string)null);
                });

            modelBuilder.Entity("ArtworksEntityFramework.Models.Entities.Artwork", b =>
                {
                    b.Property<int>("IdArtwork")
                        .HasColumnType("int")
                        .HasColumnName("Id_Artwork");

                    b.Property<int>("IdArtist")
                        .HasColumnType("int")
                        .HasColumnName("Id_Artist");

                    b.Property<int?>("IdCharacter")
                        .HasColumnType("int")
                        .HasColumnName("Id_Character");

                    b.Property<int>("IdMuseum")
                        .HasColumnType("int")
                        .HasColumnName("Id_Museum");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdArtwork")
                        .HasName("PK__Artwork__B99D1B3D4401A006");

                    b.HasIndex("IdArtist");

                    b.HasIndex("IdCharacter");

                    b.HasIndex("IdMuseum");

                    b.ToTable("Artwork", (string)null);
                });

            modelBuilder.Entity("ArtworksEntityFramework.Models.Entities.Character", b =>
                {
                    b.Property<int>("IdCharacter")
                        .HasColumnType("int")
                        .HasColumnName("Id_Character");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdCharacter")
                        .HasName("PK__Characte__CDD73BE097DD29FB");

                    b.ToTable("Character", (string)null);
                });

            modelBuilder.Entity("ArtworksEntityFramework.Models.Entities.Museum", b =>
                {
                    b.Property<int>("IdMuseum")
                        .HasColumnType("int")
                        .HasColumnName("Id_Museum");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MuseumName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdMuseum")
                        .HasName("PK__Museum__84BA05225CCC4267");

                    b.ToTable("Museum", (string)null);
                });

            modelBuilder.Entity("ArtworksEntityFramework.Models.Entities.Artwork", b =>
                {
                    b.HasOne("ArtworksEntityFramework.Models.Entities.Artist", "IdArtistNavigation")
                        .WithMany("Artworks")
                        .HasForeignKey("IdArtist")
                        .IsRequired()
                        .HasConstraintName("FK__Artwork__Id_Arti__2B3F6F97");

                    b.HasOne("ArtworksEntityFramework.Models.Entities.Character", "IdCharacterNavigation")
                        .WithMany("Artworks")
                        .HasForeignKey("IdCharacter")
                        .HasConstraintName("FK__Artwork__Id_Char__2C3393D0");

                    b.HasOne("ArtworksEntityFramework.Models.Entities.Museum", "IdMuseumNavigation")
                        .WithMany("Artworks")
                        .HasForeignKey("IdMuseum")
                        .IsRequired()
                        .HasConstraintName("FK__Artwork__Id_Muse__2A4B4B5E");

                    b.Navigation("IdArtistNavigation");

                    b.Navigation("IdCharacterNavigation");

                    b.Navigation("IdMuseumNavigation");
                });

            modelBuilder.Entity("ArtworksEntityFramework.Models.Entities.Artist", b =>
                {
                    b.Navigation("Artworks");
                });

            modelBuilder.Entity("ArtworksEntityFramework.Models.Entities.Character", b =>
                {
                    b.Navigation("Artworks");
                });

            modelBuilder.Entity("ArtworksEntityFramework.Models.Entities.Museum", b =>
                {
                    b.Navigation("Artworks");
                });
#pragma warning restore 612, 618
        }
    }
}