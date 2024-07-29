using System;

namespace Dtat.Seedwork.Abstractions;

//public interface IEntityHasModifierUserId<TIdentity> where TIdentity : notnull
//{
//	TIdentity? ModifierUserId { get; }

//	DateTimeOffset UpdateDateTime { get; }

//	void Update(TIdentity modifierUserId);
//}

public interface IEntityHasModifierUserId
{
	Guid? ModifierUserId { get; }

	DateTimeOffset UpdateDateTime { get; }

	void Update(Guid modifierUserId);
}
