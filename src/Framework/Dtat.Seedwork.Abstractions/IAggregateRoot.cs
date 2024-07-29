namespace Dtat.Seedwork.Abstractions;

//public interface IAggregateRoot
//{
//	void ClearDomainEvents();
//	void AddDomainEvent(IDomainEvent domainEvent);
//}

public interface IAggregateRoot
{
	void ClearDomainEvents();
	void RaiseDomainEvent(IDomainEvent domainEvent);
}
