using System;
using System.Collections.Generic;
using ArtworksEntityFramework.Models.Entities;
using ArtworksEntityFramework.Repositories.DBContext.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ArtworksEntityFramework.Repositories.DBContext;

public partial class ArtworksContext : DbContext
{
    public ArtworksContext()
    {
    }

    public ArtworksContext(DbContextOptions<ArtworksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Artist> Artists { get; set; }

    public virtual DbSet<Artwork> Artworks { get; set; }

    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<Museum> Museums { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-476F63V\\SQLEXPRESS;Initial Catalog=Artworks; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ArtistConfiguration());
        modelBuilder.ApplyConfiguration(new ArtworkConfiguration());
        modelBuilder.ApplyConfiguration(new CharacterConfiguration());
        modelBuilder.ApplyConfiguration(new MuseumConfiguration());
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
