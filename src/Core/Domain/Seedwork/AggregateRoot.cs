//namespace Domain.Seedwork;

//public abstract class AggregateRoot<TStronglyTypedId, TValue>
//	: Entity<TStronglyTypedId, TValue>,
//	Dtat.Seedwork.Abstractions.IAggregateRoot
//	where TValue : notnull
//	where TStronglyTypedId : Dtat.Seedwork.Abstractions.IStronglyTypedId<TValue>
//{
//	public AggregateRoot(TStronglyTypedId id) : base(id: id)
//	{
//	}

//	private readonly System.Collections.Generic.List
//		<Dtat.Seedwork.Abstractions.IDomainEvent> _domainEvents = [];

//	public System.Collections.Generic.IReadOnlyCollection
//		<Dtat.Seedwork.Abstractions.IDomainEvent> DomainEvents
//	{
//		get
//		{
//			return _domainEvents.AsReadOnly();
//		}
//	}

//	public void ClearDomainEvents()
//	{
//		_domainEvents.Clear();
//	}

//	public void RaiseDomainEvent
//		(Dtat.Seedwork.Abstractions.IDomainEvent domainEvent)
//	{
//		_domainEvents.Add
//			(item: domainEvent);
//	}
//}

//using Dtat.Seedwork.Abstractions;
//using System.Collections.Generic;

//namespace Domain.Seedwork;

//public abstract class
//	AggregateRoot<TStronglyTypedId, TValue>(TStronglyTypedId id)
//	: Entity<TStronglyTypedId, TValue>(id: id), IAggregateRoot
//	where TValue : notnull
//	where TStronglyTypedId : IStronglyTypedId<TValue>
//{
//	private readonly List<IDomainEvent> _domainEvents = [];

//	public IReadOnlyCollection<IDomainEvent> DomainEvents
//	{
//		get
//		{
//			return _domainEvents.AsReadOnly();
//		}
//	}

//	public void ClearDomainEvents()
//	{
//		_domainEvents.Clear();
//	}

//	public void RaiseDomainEvent(IDomainEvent domainEvent)
//	{
//		_domainEvents.Add
//			(item: domainEvent);
//	}
//}

using Dtat.Seedwork.Abstractions;
using System.Collections.Generic;

namespace Domain.Seedwork;

public abstract class AggregateRoot : Entity, IAggregateRoot
{
	private readonly List<IDomainEvent> _domainEvents = [];

	//public IList<IDomainEvent> DomainEvents
	//{
	//	get
	//	{
	//		return _domainEvents;
	//	}
	//}

	public IReadOnlyCollection<IDomainEvent> DomainEvents
	{
		get
		{
			return _domainEvents.AsReadOnly();
		}
	}

	public void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

	public void RaiseDomainEvent(IDomainEvent domainEvent)
	{
		_domainEvents.Add(item: domainEvent);
	}
}
