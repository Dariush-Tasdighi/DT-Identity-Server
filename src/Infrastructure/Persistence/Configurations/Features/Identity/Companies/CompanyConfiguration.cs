using Microsoft.EntityFrameworkCore;
using Domain.Features.Identity.Companies;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.SharedKernel;

namespace Persistence.Configurations.Features.Identity.Companies;

internal sealed class CompanyConfiguration : object, IEntityTypeConfiguration<Company>
{
	public void Configure(EntityTypeBuilder<Company> builder)
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
			.Property(current => current.Name)
			.HasMaxLength(maxLength: Name.MaxLength)
			.HasConversion(current => current.Value, value => new Name(value));

		builder
			.HasIndex(current => new { current.Name })
			.IsUnique(unique: true)
			;

		//builder
		//	.HasIndex(current => new { current.UserId, current.Name })
		//	.IsUnique(unique: true)
		//	;
		// **************************************************

		// **************************************************
		builder
			.Property(current => current.Title)
			.HasMaxLength(maxLength: Title.MaxLength)
			.HasConversion(current => current.Value, value => new Title(value));

		builder
			.HasIndex(current => new { current.Title })
			.IsUnique(unique: true)
			;

		//builder
		//	.HasIndex(current => new { current.UserId, current.Title })
		//	.IsUnique(unique: true)
		//	;
		// **************************************************
		// **************************************************
		// **************************************************

		// **************************************************
		// **************************************************
		// **************************************************
		builder
			.HasMany(current => current.Applications)
			.WithOne(other => other.Company)
			.IsRequired(required: true)
			.HasForeignKey(other => other.CompanyId)
			.OnDelete(deleteBehavior: DeleteBehavior.NoAction)
			;
		// **************************************************
		// **************************************************
		// **************************************************
	}
}
