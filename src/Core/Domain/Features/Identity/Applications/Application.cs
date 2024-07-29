using System;
using System.Linq;
using Domain.Seedwork;
using Domain.SharedKernel;
using Dtat.Seedwork.Abstractions;
using System.Collections.Generic;
using Domain.Features.Identity.Companies;
using System.ComponentModel.DataAnnotations;
using Domain.Features.Identity.ApplicationRoles;

namespace Domain.Features.Identity.Applications;

public class Application :
	AggregateRoot, IEntityHasIsActive
{
#pragma warning disable CS8618
	private Application() : base()
	{
	}
#pragma warning restore CS8618

	public Application(Guid companyId, Name name, Title title) : base()
	{
		Name = name;
		Title = title;
		CompanyId = companyId;
	}

	[Required]
	public Guid CompanyId { get; private set; }

	public virtual Company? Company { get; private set; }

	public Name Name { get; private set; }

	public Title Title { get; private set; }

	public bool IsActive { get; private set; }

	public bool IsIPRestricted { get; private set; }

	public bool IsUserIPRestricted { get; private set; }

	public bool IsOriginRestricted { get; private set; }

	public bool ValidateUserInEachRequest { get; private set; }

	public bool UserMustHaveMaximumOneRole { get; private set; }

	public void AddUserValidIP(string? ip)
	{
		var ip4 =
			new IP4Address(value: ip);

		var userValidIP =
			new UserValidIP(applicationId: Id, ip4Address: ip4);

		var hasAny =
			UserValidIPs
			.Where(current => current.IP4Address.Value == userValidIP.IP4Address.Value)
			.Any();

		if (hasAny == false)
		{
			UserValidIPs.Add(item: userValidIP);
		}
	}

	public void AddApplicationValidIP(string? ip)
	{
		var ip4 =
			new IP4Address(value: ip);

		var applicationValidIP =
			new ApplicationValidIP(applicationId: Id, ip4Address: ip4);

		var hasAny =
			ApplicationValidIPs
			.Where(current => current.IP4Address.Value == applicationValidIP.IP4Address.Value)
			.Any();

		if (hasAny == false)
		{
			ApplicationValidIPs.Add(item: applicationValidIP);
		}
	}

	public virtual IList<UserValidIP> UserValidIPs { get; } = [];
	public virtual IList<ApplicationRole> ApplicationRoles { get; } = [];
	public virtual IList<ApplicationValidIP> ApplicationValidIPs { get; } = [];
}
