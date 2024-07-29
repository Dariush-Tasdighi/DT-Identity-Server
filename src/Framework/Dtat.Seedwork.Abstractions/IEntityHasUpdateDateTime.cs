namespace Dtat.Seedwork.Abstractions;

public interface IEntityHasUpdateDateTime
{
	System.DateTimeOffset UpdateDateTime { get; }

	void Update();
}
