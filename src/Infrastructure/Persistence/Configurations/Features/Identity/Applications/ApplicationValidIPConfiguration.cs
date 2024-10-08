﻿using Domain.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Domain.Features.Identity.Applications;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Features.Identity.Applications;

internal sealed class ApplicationValidIPConfiguration : object, IEntityTypeConfiguration<ApplicationValidIP>
{
	public void Configure(EntityTypeBuilder<ApplicationValidIP> builder)
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
			.Property(current => current.IP4Address)
			.HasMaxLength(maxLength: IP4Address.MaxLength)
			.HasConversion(current => current.Value, value => new IP4Address(value));

		builder
			.HasIndex(current => new { current.ApplicationId, current.IP4Address })
			.IsUnique(unique: true)
			;
		// **************************************************
		// **************************************************
		// **************************************************
		// **************************************************
		// **************************************************
	}
}
