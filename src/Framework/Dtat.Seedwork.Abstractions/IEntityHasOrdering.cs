namespace Dtat.Seedwork.Abstractions;

//public interface IEntityHasOrdering<IOrdering> where IOrdering : notnull
//{
//	IOrdering Ordering { get; }
//}

public interface IEntityHasOrdering
{
	long Ordering { get; }
}
