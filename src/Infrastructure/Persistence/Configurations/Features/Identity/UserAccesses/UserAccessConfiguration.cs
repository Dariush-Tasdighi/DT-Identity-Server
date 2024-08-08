using Microsoft.EntityFrameworkCore;
using Domain.Features.Identity.UserAccesses;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Features.Identity.UserAccesses;

internal sealed class UserAccessesConfiguration : object, IEntityTypeConfiguration<UserAccess>
{
	public void Configure(EntityTypeBuilder<UserAccess> builder)
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
			.HasIndex(current => new { current.UserId, current.ApplicationId })
			.IsUnique(unique: true)
			;
		// **************************************************
		// **************************************************
		// **************************************************
	}
}
