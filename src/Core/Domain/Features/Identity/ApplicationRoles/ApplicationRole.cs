using System;
using Domain.Seedwork;
using Domain.SharedKernel;
using Dtat.Seedwork.Abstractions;
using System.ComponentModel.DataAnnotations;
using Domain.Features.Identity.Applications;
using Domain.Features.Identity.UserAccesses;
using System.Collections.Generic;

namespace Domain.Features.Identity.ApplicationRoles;

public class ApplicationRole :
	AggregateRoot, IEntityHasIsActive
{
#pragma warning disable CS8618
	private ApplicationRole() : base()
	{
	}
#pragma warning restore CS8618

	public ApplicationRole(Guid applicationId, Name name, Code code, Title title) : base()
	{
		Code = code;
		Name = name;
		Title = title;
		ApplicationId = applicationId;
	}

	[Required]
	public Guid ApplicationId { get; private set; }

	public virtual Application? Application { get; private set; }

	public Code Code { get; private set; }

	public Name Name { get; private set; }

	public Title Title { get; private set; }

	public bool IsActive { get; private set; }

	public virtual IList<UserAccessRole> UserAccessRoles { get; } = [];
}
