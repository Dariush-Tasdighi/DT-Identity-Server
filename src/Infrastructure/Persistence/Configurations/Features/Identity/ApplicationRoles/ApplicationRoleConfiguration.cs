using Microsoft.EntityFrameworkCore;
using Domain.Features.Identity.ApplicationRoles;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.SharedKernel;

namespace Persistence.Configurations.Features.Identity.ApplicationRoles;

internal sealed class ApplicationRoleConfiguration : object, IEntityTypeConfiguration<ApplicationRole>
{
	public void Configure(EntityTypeBuilder<ApplicationRole> builder)
	{
		// **************************************************
		// **************************************************
		// **************************************************
		builder
			.HasKey(current => current.Id)
			.IsClustered(clustered: false)
			;
		// **************************************************

		// **************************************************
		builder
			.Property(current => current.Code)
			.HasConversion(current => current.Value, value => new Code(value));

		builder
			.HasIndex(current => new { current.ApplicationId, current.Code })
			.IsUnique(unique: true)
			;
		// **************************************************

		// **************************************************
		builder
			.Property(current => current.Name)
			.HasConversion(current => current.Value, value => new Name(value));

		builder
			.HasIndex(current => new { current.ApplicationId, current.Name })
			.IsUnique(unique: true)
			;
		// **************************************************
		// **************************************************
		// **************************************************
	}
}
