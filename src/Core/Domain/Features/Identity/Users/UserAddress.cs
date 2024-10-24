using Domain.Seedwork;

namespace Domain.Features.Identity.Users;

public class UserAddress(string postalCode) : Entity
{
	public const int PostalCodeMaxLength = 10;

	public string PostalCode { get; private set; } = postalCode;

	public void UpdatePostalCode(string postalCode)
	{
		PostalCode = postalCode;
	}
}
