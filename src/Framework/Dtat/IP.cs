using System.Net;

namespace Dtat;

public static class IP4 : object
{
	public static uint ToInt(string ipString)
	{
		var ipAddress =
			IPAddress.Parse(ipString: ipString);

		if(ipAddress is null)
		{
			throw new ArgumentException
				(message: "IP4 Address is not valid!");
		}

		var bytes =
			ipAddress.GetAddressBytes();

		// Flip big-endian(network order) to little-endian
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(array: bytes);
		}

		var result =
			BitConverter.ToUInt32(bytes, 0);

		return result;
	}

	public static string ToString(uint ipLong)
	{
		var bytes =
			BitConverter.GetBytes(value: ipLong);

		// Flip little-endian to big-endian(network order)
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(array: bytes);
		}

		var result =
			new IPAddress(address: bytes).ToString();

		return result;
	}
}
