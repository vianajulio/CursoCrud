using DemoCrud.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DemoCrud.Api.Contexts;

public class DataContext : DbContext
{
	public DbSet<Car> Cars { get; set; } = null!;

	public DataContext(DbContextOptions<DataContext> options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}
}
