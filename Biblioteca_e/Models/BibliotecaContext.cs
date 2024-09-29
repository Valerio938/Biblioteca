using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_e.Models;

public partial class BibliotecaContext : DbContext
{
    public BibliotecaContext()
    {
    }

    public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<Prestito> Prestitos { get; set; }

    public virtual DbSet<Utente> Utentes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("SERVER=ACADEMY2024-21\\SQLEXPRESS;Database=Biblioteca;User Id=Academy;Password=academy!;\nMultipleActiveResultSets=true;\nEncrypt=false;\nTrustServerCertificate=false\n");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.LibroId).HasName("PK__Libro__18C65F4BA1F0B211");

            entity.ToTable("Libro");

            entity.Property(e => e.LibroId).HasColumnName("libroID");
            entity.Property(e => e.AnnoPubblicazione).HasColumnName("anno_pubblicazione");
            entity.Property(e => e.CodiceUtente)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("codice_utente");
            entity.Property(e => e.Disponibilita).HasColumnName("disponibilita");
            entity.Property(e => e.Titolo)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("titolo");
        });

        modelBuilder.Entity<Prestito>(entity =>
        {
            entity.HasKey(e => e.PrestitoId).HasName("PK__Prestito__7E579A75A94C25B4");

            entity.ToTable("Prestito");

            entity.HasIndex(e => new { e.UtenteRif, e.LibroRif }, "UQ__Prestito__FB14A73C4F0EC330").IsUnique();

            entity.Property(e => e.PrestitoId).HasColumnName("prestitoID");
            entity.Property(e => e.CodiceUtente)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("codice_utente");
            entity.Property(e => e.DataConsegna).HasColumnName("data_consegna");
            entity.Property(e => e.DataRitiro).HasColumnName("data_ritiro");
            entity.Property(e => e.LibroRif).HasColumnName("libroRIF");
            entity.Property(e => e.UtenteRif).HasColumnName("utenteRIF");

            entity.HasOne(d => d.LibroRifNavigation).WithMany(p => p.Prestitos)
                .HasForeignKey(d => d.LibroRif)
                .HasConstraintName("FK__Prestito__libroR__403A8C7D");

            entity.HasOne(d => d.UtenteRifNavigation).WithMany(p => p.Prestitos)
                .HasForeignKey(d => d.UtenteRif)
                .HasConstraintName("FK__Prestito__utente__3F466844");
        });

        modelBuilder.Entity<Utente>(entity =>
        {
            entity.HasKey(e => e.UtenteId).HasName("PK__Utente__CA5C2253B1F34C19");

            entity.ToTable("Utente");

            entity.Property(e => e.UtenteId).HasColumnName("utenteID");
            entity.Property(e => e.CodiceUtente)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("codice_utente");
            entity.Property(e => e.Cognome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("cognome");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
