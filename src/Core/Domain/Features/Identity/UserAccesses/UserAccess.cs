using System;
using Domain.Seedwork;
using Dtat.Seedwork.Abstractions;
using System.ComponentModel.DataAnnotations;

using Domain.Features.Identity.Users;
using Domain.Features.Identity.Applications;

namespace Domain.Features.Identity.UserAccesses;

public class UserAccess :
	AggregateRoot, IEntityHasIsActive
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

	public DateTimeOffset? ExpirationDate { get; private set; }

	public bool IsActive { get; private set; }
}
