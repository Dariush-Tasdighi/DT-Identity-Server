using Microsoft.EntityFrameworkCore;

using Domain.Features.Identity.Users;
using Domain.Features.Identity.Companies;
using Domain.Features.Identity.Applications;
using Domain.Features.Identity.ApplicationRoles;

namespace Persistence;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext() : base()
	{
		Database.EnsureCreated();
	}

	public DbSet<User> Users { get; set; }
	public DbSet<Company> Companies { get; set; }
	public DbSet<Application> Applications { get; set; }
	public DbSet<ApplicationRole> ApplicationRoles { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		var connectionString =
			"Server=.;User ID=sa;Password=1234512345;Database=DT_IDENTITY_SERVER;MultipleActiveResultSets=true;TrustServerCertificate=True;";

		optionsBuilder.UseSqlServer
			(connectionString: connectionString)
			;

		//optionsBuilder.EnableDetailedErrors(detailedErrorsEnabled: true);
		//optionsBuilder.EnableSensitiveDataLogging(sensitiveDataLoggingEnabled: true);

		//optionsBuilder.LogTo(
		//	action: System.Console.WriteLine,

		//	minimumLevel: LogLevel.Trace,
		//	//minimumLevel: Microsoft.Extensions.Logging.LogLevel.Trace,

		//	options:
		//		DbContextLoggerOptions.Id |
		//		DbContextLoggerOptions.Level |
		//		DbContextLoggerOptions.Category |
		//		DbContextLoggerOptions.LocalTime
		//);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly
			(assembly: typeof(ApplicationDbContext).Assembly);

		//modelBuilder.Seed();
	}
}
