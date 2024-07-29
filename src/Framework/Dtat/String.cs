namespace Dtat;

public static class String : object
{
	public static string? Fix(this string? value)
	{
		if (string.IsNullOrWhiteSpace(value: value))
		{
			return null;
		}

		value =
			value.Trim();

		while(value.Contains(value: "  "))
		{
			value =
				value
				.Replace(oldValue: "  ", newValue: " ")
				;
		}

		return value;
	}
}
