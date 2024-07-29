using System;

namespace Dtat.Seedwork.Abstractions;

public interface IEntityHasIsSynced
{
	bool IsSynced { get; }

	DateTimeOffset? SyncDateTime { get; }

	void Sync();
}
