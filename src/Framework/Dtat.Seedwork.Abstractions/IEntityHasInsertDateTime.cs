using System;

namespace Dtat.Seedwork.Abstractions;

public interface IEntityHasInsertDateTime
{
	DateTimeOffset InsertDateTime { get; }

	void Create();
}
