using System;

namespace Dtat.Seedwork.Abstractions;

//public interface IEntityHasCultureId<TIdentity> where TIdentity : notnull
//{
//	TIdentity CultureId { get; }
//}

public interface IEntityHasCultureId
{
	Guid CultureId { get; }
}
