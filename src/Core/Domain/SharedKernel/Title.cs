using Dtat;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.SharedKernel;

[ComplexType]
public record Title : object
{
	public const int MaxLength = 100;

	public Title(string? value) : base()
	{
		SetValue(value: value);
	}

	[MaxLength(length: MaxLength)]
	[Column(name: nameof(Title))]
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
				Resources.DataDictionary.Title
				);

			throw new Exception(message: errorMessage);
		}

		if (value.Length > MaxLength)
		{
			var errorMessage = string.Format(
				Resources.ValidationErrorMessages.MaxLength,
				Resources.DataDictionary.Title,
				MaxLength
				);

			throw new Exception(message: errorMessage);
		}

		if (Value != value)
		{
			Value = value;
		}
	}
}
