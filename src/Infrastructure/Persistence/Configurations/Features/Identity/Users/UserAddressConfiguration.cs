//using System;
//using Microsoft.EntityFrameworkCore;
//using Domain.Features.Identity.Users;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Persistence.Configurations.Features.Identity.Users;

//internal sealed class UserAddressConfiguration :
//	object, IEntityTypeConfiguration<UserAddress>
//{
//	public UserAddressConfiguration() : base()
//	{
//	}

//	public void Configure
//		(EntityTypeBuilder<UserAddress> builder)
//	{
//		builder.ToTable(name: "UserAddresses");

//		// **************************************************
//		// **************************************************
//		// **************************************************
//builder
//	.HasKey(current => current.Id)
//	.IsClustered(clustered: false)
//	;

//		builder
//			.HasKey(d => d.Id);

//		//builder
//		//	.HasOne(d => d.Id);

//		builder
//			.Property(p => p.Id)
//			.HasConversion(id => id.Value,
//			value => new UserAddressId(value));
//		// **************************************************

//		// **************************************************
//		builder
//			.Property(current => current.PostalCode)
//			.HasMaxLength(maxLength: UserAddress.PostalCodeMaxLength)
//			;

//		builder
//			.Property(current => current.PostalCode)
//			.IsUnicode(unicode: false)
//			;
//		// **************************************************

//		// **************************************************
//		builder
//			.Property<Guid>(propertyName: "UserId")
//			;

//		//builder
//		//	.HasIndex("UserId", "PostalCode")
//		//	.IsUnique(unique: true)
//		//	;

//		builder
//			.HasIndex("UserId", nameof(UserAddress.PostalCode))
//			.IsUnique(unique: true)
//			;
//		// **************************************************
//		// **************************************************
//		// **************************************************
//	}
//}
