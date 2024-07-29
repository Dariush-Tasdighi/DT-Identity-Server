using System;
using Dtat.Seedwork.Abstractions;

namespace Domain.Seedwork;

//public abstract class DomainEvent(DateTime occurredOn)
//	: object, Dtat.Seedwork.Abstractions.IDomainEvent
//{
//	public DateTime OccurredOn { get; init; } = occurredOn;
//}

public abstract class DomainEvent(Guid id, DateTime occurredOn) : object, IDomainEvent
{
	public Guid Id { get; init; } = id;
	public DateTimeOffset OccurredOn { get; init; } = occurredOn;
}
