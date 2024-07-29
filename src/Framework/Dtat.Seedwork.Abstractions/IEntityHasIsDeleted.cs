using System;

namespace Dtat.Seedwork.Abstractions;

//public interface IEntityHasIsDeleted<TIdentity> where TIdentity : notnull
//{
//	bool IsDeleted { get; }

//	TIdentity? RemoverUserId { get; }

//	DateTimeOffset? DeleteDateTime { get; }

//	void Delete(TIdentity removerUserId);

//	void Undelete(TIdentity removerUserId);
//}

public interface IEntityHasIsDeleted
{
	bool IsDeleted { get; }

	Guid? RemoverUserId { get; }

	DateTimeOffset? DeleteDateTime { get; }

	void Delete(Guid removerUserId);

	void Undelete(Guid removerUserId);
}
