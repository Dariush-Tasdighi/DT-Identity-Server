using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.SharedKernel;

//[ComplexType]
//public record Code(long Value) : object;

[ComplexType]
public record Code : object
{
	public Code(long? value) : base()
	{
		SetValue(value: value);
	}

	[Column(name: nameof(Code))]
	public long Value { get; private set; }

	public void SetValue(long? value)
	{
		if (value is null)
		{
			var errorMessage = string.Format(
				Resources.ValidationErrorMessages.Required,
				Resources.DataDictionary.Code
				);

			throw new Exception(message: errorMessage);
		}

		if (Value != value)
		{
			Value = value.Value;
		}
	}
}
