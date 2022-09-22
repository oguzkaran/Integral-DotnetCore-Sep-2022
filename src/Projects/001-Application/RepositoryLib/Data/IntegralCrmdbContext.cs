using Integral.CRM.Data.Repository.Entity;
using Microsoft.EntityFrameworkCore;

namespace Integral.CRM.Data.Repository;

public partial class IntegralCrmdbContext : DbContext
{
    public IntegralCrmdbContext()
    {
    }

    public IntegralCrmdbContext(DbContextOptions<IntegralCrmdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
            return;

        optionsBuilder.UseSqlServer("Server = aws-mssql.cct1ehgoywdp.us-east-2.rds.amazonaws.com; Database = integral_crmdb; User Id = admin; Password = csystem1993;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.CustomerAddress).IsUnicode(false);

            entity.Property(e => e.CustomerName)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
