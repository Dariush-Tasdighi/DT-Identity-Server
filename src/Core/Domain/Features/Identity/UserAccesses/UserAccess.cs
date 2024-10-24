using System;
using System.Linq;
using Domain.Seedwork;
using Dtat.Seedwork.Abstractions;
using System.Collections.Generic;
using Domain.Features.Identity.Users;
using Domain.Features.Identity.Applications;
using System.ComponentModel.DataAnnotations;

namespace Domain.Features.Identity.UserAccesses;

public class UserAccess : AggregateRoot, IEntityHasIsActive
{
#pragma warning disable CS8618
	private UserAccess() : base()
	{
	}
#pragma warning restore CS8618

	public UserAccess(Guid userId, Guid applicationId) : base()
	{
		UserId = userId;
		ApplicationId = applicationId;
	}

	[Required]
	public Guid UserId { get; private set; }

	public virtual User? User { get; private set; }

	[Required]
	public Guid ApplicationId { get; private set; }

	public virtual Application? Application { get; private set; }

	public bool IsActive { get; private set; }

	public DateTimeOffset? ExpirationDate { get; private set; }

	public void AddApplicationRole(Guid applicationRoleId)
	{
		var hasAny =
			UserAccessRoles
			.Where(current => current.ApplicationRoleId == applicationRoleId)
			.Any();

		if (hasAny)
		{
			return;
		}

		var userAccessRole =
			new UserAccessRole
			(userAccessId: Id, applicationRoleId: applicationRoleId);

		UserAccessRoles.Add(item: userAccessRole);
	}

	public virtual IList<UserAccessRole> UserAccessRoles { get; } = [];
}
