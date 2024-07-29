using Dtat;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.SharedKernel;

[ComplexType]
public record EmailAddress : object
{
	public const int MaxLength = 250;

	public EmailAddress(string? value) : base()
	{
		SetValue(value: value);
	}

	[MaxLength(length: MaxLength)]
	[Column(name: nameof(EmailAddress))]
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
				Resources.DataDictionary.EmailAddress
				);

			throw new Exception(message: errorMessage);
		}

		if (value.Length > MaxLength)
		{
			var errorMessage = string.Format(
				Resources.ValidationErrorMessages.MaxLength,
				Resources.DataDictionary.EmailAddress,
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
