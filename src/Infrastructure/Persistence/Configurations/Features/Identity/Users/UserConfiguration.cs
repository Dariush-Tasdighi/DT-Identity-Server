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
			.HasConversion(id => id.Value, value => new Username(value));

		builder
			.HasIndex(current => current.Username)
			.IsUnique(unique: true)
			;
		// **************************************************

		// **************************************************
		//builder
		//	.ComplexProperty(current => current.Id), current =>
		//	{
		//		current
		//			.Property(other => other.Value)
		//			.HasColumnName(name: "Id")
		//			;
		//	});

		//builder
		//	.ComplexProperty(current => current.Id);

		//builder
		//	.HasKey(d => d.Id);

		//builder
		//	.HasOne(d => d.Id);

		//builder
		//	.Property(p => p.Id)
		//	.HasConversion(id => id.Value, value => new UserId(value));
		// **************************************************

		// **************************************************
		//builder
		//	.Property(current => current.EmailAddress)
		//	.HasMaxLength(maxLength: 250)
		//	;

		//builder
		//	.Property(current => current.EmailAddress)
		//	.IsUnicode(unicode: false)
		//	;

		//builder
		//	.HasIndex(current => current.EmailAddress)
		//	.IsUnique(unique: true)
		//	;

		//builder
		//	.HasIndex(current => new { current.EmailAddress })
		//	.IsUnique(unique: true)
		//	;
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
