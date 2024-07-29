using System;

namespace Dtat.Seedwork.Abstractions;

//public interface IEntityHasIsVerified<TIdentity> where TIdentity : notnull
//{
//	bool IsVerified { get; }

//	TIdentity? VerifierUserId { get; }

//	DateTimeOffset? VerifyDateTime { get; }

//	void Verify(TIdentity verifierUserId);

//	void Unverify(TIdentity verifierUserId);
//}

public interface IEntityHasIsVerified
{
	bool IsVerified { get; }

	Guid? VerifierUserId { get; }

	DateTimeOffset? VerifyDateTime { get; }

	void Verify(Guid verifierUserId);

	void Unverify(Guid verifierUserId);
}
