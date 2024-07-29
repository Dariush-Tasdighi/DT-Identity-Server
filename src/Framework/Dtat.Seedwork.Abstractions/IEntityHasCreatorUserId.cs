using System;

namespace Dtat.Seedwork.Abstractions;

//public interface IEntityHasCreatorUserId<TIdentity> where TIdentity : notnull
//{
//	TIdentity CreatorUserId { get; }

//	DateTimeOffset InsertDateTime { get; }

//	void Create(TIdentity creatorUserId);
//}

public interface IEntityHasCreatorUserId
{
	Guid CreatorUserId { get; }

	DateTimeOffset InsertDateTime { get; }

	void Create(Guid creatorUserId);
}
