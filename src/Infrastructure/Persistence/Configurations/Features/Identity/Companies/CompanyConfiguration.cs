using Microsoft.EntityFrameworkCore;
using Domain.Features.Identity.Companies;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Features.Identity.Companies;

internal sealed class CompanyConfiguration : object, IEntityTypeConfiguration<Company>
{
	public void Configure(EntityTypeBuilder<Company> builder)
	{
		// **************************************************
		builder
			.HasKey(current => current.Id)
			.IsClustered(clustered: false)
			;
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
