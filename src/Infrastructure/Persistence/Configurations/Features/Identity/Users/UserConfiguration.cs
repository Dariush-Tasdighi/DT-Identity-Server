using Microsoft.EntityFrameworkCore;
using Domain.Features.Identity.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.SharedKernel;

namespace Persistence.Configurations.Features.Identity.Users;

internal sealed class UserConfiguration : object, IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
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
			.Property(p => p.Username)
			.HasMaxLength(maxLength: Username.MaxLength)
			.HasConversion(id => id.Value, value => new Username(value));

		builder
			.HasIndex(current => new { current.Username })
			.IsUnique(unique: true)
			;
		// **************************************************

		// **************************************************
		builder
			.Property(p => p.EmailAddress)
			.HasMaxLength(maxLength: EmailAddress.MaxLength)
			.HasConversion(id => id.Value, value => new EmailAddress(value));

		builder
			.HasIndex(current => new { current.EmailAddress })
			.IsUnique(unique: true)
			;
		// **************************************************
		// **************************************************
		// **************************************************

		// **************************************************
		// **************************************************
		// **************************************************
		builder
			.HasMany(current => current.Companies)
			.WithOne(other => other.User)
			.IsRequired(required: true)
			.HasForeignKey(other => other.UserId)
			.OnDelete(deleteBehavior: DeleteBehavior.NoAction)
			;
		// **************************************************
		// **************************************************
		// **************************************************
	}
}
