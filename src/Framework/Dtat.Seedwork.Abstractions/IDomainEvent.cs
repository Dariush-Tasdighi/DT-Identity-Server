using System;
using Mediator;

namespace Dtat.Seedwork.Abstractions;

/// <summary>
/// Marker
/// </summary>
//public interface IDomainEvent : INotification
//{
//}

//public interface IDomainEvent : INotification
//{
//	DateTimeOffset OccurredOn { get; }
//}

public interface IDomainEvent : INotification
{
	Guid Id { get; }

	DateTimeOffset OccurredOn { get; }
}
