using Dtat;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.SharedKernel;

[ComplexType]
public record IP4Address : object
{
	public const int MaxLength = 15;

	public IP4Address(string? value) : base()
	{
		SetValue(value: value);
	}

	[MaxLength(length: MaxLength)]
	[Column(name: nameof(IP4Address))]
	[Required(AllowEmptyStrings = false)]
	public string? Value { get; private set; }

	[Column(name: nameof(IP4Value))]
	public uint IP4Value { get; private set; }

	public void SetValue(string? value)
	{
		value =
			value.Fix();

		if (value is null)
		{
			var errorMessage = string.Format(
				Resources.ValidationErrorMessages.Required,
				Resources.DataDictionary.IP4Address
				);

			throw new Exception(message: errorMessage);
		}

		if (value.Length > MaxLength)
		{
			var errorMessage = string.Format(
				Resources.ValidationErrorMessages.MaxLength,
				Resources.DataDictionary.IP4Address,
				MaxLength
				);

			throw new Exception(message: errorMessage);
		}

		// Check Regular Expression!

		if(Value != value)
		{
			Value = value;
			IP4Value = Dtat.IP4.ToInt(ipString: Value);
		}
	}
}
