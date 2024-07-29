using System;
using Domain.Seedwork;
using Domain.SharedKernel;
using Dtat.Seedwork.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace Domain.Features.Identity.Applications;

public class ApplicationValidIP : Entity, IEntityHasIsActive
{
#pragma warning disable CS8618
	private ApplicationValidIP() : base()
	{
	}
#pragma warning restore CS8618

	public ApplicationValidIP(Guid applicationId, IP4Address ip4Address) : base()
	{
		IP4Address = ip4Address;
		ApplicationId = applicationId;
	}

	[Required]
	public Guid ApplicationId { get; private set; }

	public virtual Application? Application { get; private set; }

	public bool IsActive { get; private set; }

	public IP4Address IP4Address { get; private set; }
}
