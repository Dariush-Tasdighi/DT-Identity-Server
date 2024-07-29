using Dtat;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.SharedKernel;

[ComplexType]
public record Name : object
{
	public const int MaxLength = 100;

	public Name(string? value) : base()
	{
		SetValue(value: value);
	}

	[MaxLength(length: MaxLength)]
	[Column(name: nameof(Name))]
	[Required(AllowEmptyStrings = false)]
	public string? Value { get; private set; }

	public void SetValue(string? value)
	{
		value =
			value.Fix();

		if (value is null)
		{
			var errorMessage = string.Format(
				Resources.ValidationErrorMessages.Required,
				Resources.DataDictionary.Name
				);

			throw new Exception(message: errorMessage);
		}

		if (value.Length > MaxLength)
		{
			var errorMessage = string.Format(
				Resources.ValidationErrorMessages.MaxLength,
				Resources.DataDictionary.Name,
				MaxLength
				);

			throw new Exception(message: errorMessage);
		}

		// TODO: Check Regular Expression!

		if (Value != value)
		{
			Value = value;
		}
	}
}
