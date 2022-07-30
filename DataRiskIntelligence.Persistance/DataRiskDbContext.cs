using DataRiskIntelligence.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataRiskIntelligence.Persistance;

public class DataRiskDbContext : DbContext
{
    public DbSet<Person> People { get; set; }
    public DbSet<Quote> Quotes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source=../DataRiskIntelligence/dataRiskIntelligence.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Seed();
    }
}