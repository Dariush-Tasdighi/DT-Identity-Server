using System;
using Domain.Seedwork;
using Domain.SharedKernel;
using Dtat.Seedwork.Abstractions;
using System.Collections.Generic;
using Domain.Features.Identity.Users;
using Domain.Features.Identity.Applications;
using System.ComponentModel.DataAnnotations;

namespace Domain.Features.Identity.Companies;

public class Company : AggregateRoot, IEntityHasIsActive
{
#pragma warning disable CS8618
	private Company() : base()
	{
	}
#pragma warning restore CS8618

	public Company(Guid userId, Name name, Title title) : base()
	{
		Name = name;
		Title = title;
		UserId = userId;
	}

	[Required]
	public Guid UserId { get; private set; }

	public virtual User? User { get; private set; }

	public Name Name { get; private set; }

	public Title Title { get; private set; }

	public bool IsActive { get; private set; }

	public virtual IList<Application> Applications { get; } = [];
}
