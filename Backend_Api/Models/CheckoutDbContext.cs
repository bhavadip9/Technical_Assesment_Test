using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend_Api.Models;

public partial class CheckoutDbContext : DbContext
{
    public CheckoutDbContext()
    {
    }

    public CheckoutDbContext(DbContextOptions<CheckoutDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CheckoutRequest> CheckoutRequests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-F1KOQJT\\SQLEXPRESS;Database=CheckOut;TrustServerCertificate=True;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CheckoutRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Checkout__3214EC070FD3C4CB");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
