using Domain.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Domain.Features.Identity.Applications;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Features.Identity.Applications;

internal sealed class ApplicationConfiguration : object, IEntityTypeConfiguration<Application>
{
	public void Configure(EntityTypeBuilder<Application> builder)
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
			.HasConversion(current => current.Value, value => new Name(value));

		builder
			.HasIndex(current => new { current.Name })
			.IsUnique(unique: true)
			;

		// نام سامانه، در کل سیستم، باید منحصر به فرد باشد

		//builder
		//	.HasIndex(current => new { current.CompanyId, current.Name })
		//	.IsUnique(unique: true)
		//	;
		// **************************************************

		// **************************************************
		builder
			.Property(current => current.Name)
			.HasConversion(current => current.Value, value => new Name(value));

		builder
			.HasIndex(current => new { current.CompanyId, current.Name })
			.IsUnique(unique: true)
			;

		// ولی عنوان سامانه، صرفا باید در هر شرکت منحصر به فرد باشد
		// **************************************************
		// **************************************************
		// **************************************************

		// **************************************************

		// **************************************************
		// **************************************************
		// **************************************************
		builder
			.HasMany(current => current.UserValidIPs)
			.WithOne(other => other.Application)
			.IsRequired(required: true)
			.HasForeignKey(other => other.ApplicationId)
			.OnDelete(deleteBehavior: DeleteBehavior.Cascade)
			;

		builder
			.HasMany(current => current.ApplicationValidIPs)
			.WithOne(other => other.Application)
			.IsRequired(required: true)
			.HasForeignKey(other => other.ApplicationId)
			.OnDelete(deleteBehavior: DeleteBehavior.Cascade)
			;

		builder
			.HasMany(current => current.ApplicationRoles)
			.WithOne(other => other.Application)
			.IsRequired(required: true)
			.HasForeignKey(other => other.ApplicationId)
			.OnDelete(deleteBehavior: DeleteBehavior.NoAction)
			;
		// **************************************************
		// **************************************************
		// **************************************************
	}
}
