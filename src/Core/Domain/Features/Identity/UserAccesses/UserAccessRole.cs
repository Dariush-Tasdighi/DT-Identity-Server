using System;
using Domain.Seedwork;
using System.ComponentModel.DataAnnotations;
using Domain.Features.Identity.ApplicationRoles;

namespace Domain.Features.Identity.UserAccesses;

public class UserAccessRole : Entity
{
#pragma warning disable CS8618
	private UserAccessRole() : base()
	{
	}
#pragma warning restore CS8618

	internal UserAccessRole(Guid userAccessId, Guid applicationRoleId) : base()
	{
		UserAccessId = userAccessId;
		ApplicationRoleId = applicationRoleId;
	}

	[Required]
	public Guid UserAccessId { get; private set; }

	public virtual UserAccess? UserAccess { get; private set; }

	[Required]
	public Guid ApplicationRoleId { get; private set; }

	public virtual ApplicationRole? ApplicationRole { get; private set; }
}
