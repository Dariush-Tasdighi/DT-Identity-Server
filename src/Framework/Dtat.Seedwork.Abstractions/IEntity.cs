using System;

namespace Dtat.Seedwork.Abstractions;

/// <summary>
/// Marker
/// </summary>
//public interface IEntity
//{
//}

//public interface IEntity
//{
//	int Id { get; }
//}

//public interface IEntity
//{
//	long Id { get; }
//}

//public interface IEntity
//{
//	Guid Id { get; }
//}

//public interface IEntity<TIdentity>
//{
//	TIdentity Id { get; }
//}

//public interface IEntity<TIdentity> where TIdentity : notnull
//{
//	TIdentity Id { get; }
//}

//public interface IEntity<TStronglyTypedId, TValue>
//	where TStronglyTypedId : IStronglyTypedId<TValue> where TValue : notnull
//{
//	TStronglyTypedId Id { get; }
//}

public interface IEntity
{
	Guid Id { get; }
}
