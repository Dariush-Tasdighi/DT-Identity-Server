using System;

namespace Dtat.Seedwork.Abstractions;

//public interface IEntityIdIsSetable<TIdentity> where TIdentity : notnull
//{
//	void SetId(TIdentity id);
//}

public interface IEntityIdIsSetable
{
	void SetId(Guid id);
}
