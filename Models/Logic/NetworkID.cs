using System;
namespace VLSMsolver
{
	public class NetworkID
	{
		private string networkAddress;
		private int CIDR;

		public NetworkID(string _networkID, int _CIDR)
		{
			networkAddress = _networkID;
			CIDR = _CIDR;
		}

		//properties
		public string GettingNetworkAddress()
		{
			return networkAddress;
		}

		public int GettingCIDR()
		{
			return CIDR;
		}
		//properties


		//method getting address with the format a.b.c.d
		public string GettingAddressWithFormat()
		{
			//first octet
			string firstOctet = networkAddress.Substring(0, 8);
			int firstOctetInDecimal = Convert.ToInt32(firstOctet, 2);
			//second octet
			string secondOctet = networkAddress.Substring(8, 8);
			int secondOctetInDecimal = Convert.ToInt32(secondOctet, 2);
			//third octet
			string thirdOctet = networkAddress.Substring(16, 8);
			int thirdOctetInDecimal = Convert.ToInt32(thirdOctet, 2);
			//fourth octet
			string fourthOctet = networkAddress.Substring(24, 8);
			int fourthOctetInDecimal = Convert.ToInt32(fourthOctet, 2);


			string outputAddress = Convert.ToString(firstOctetInDecimal) + '.' + Convert.ToString(secondOctetInDecimal) + '.' + Convert.ToString(thirdOctetInDecimal) + '.' + Convert.ToString(fourthOctetInDecimal);

			return outputAddress;
		}

		//method getting CIDR as a string
		public string GettingCIDRWithFormat()
		{
			return CIDR.ToString();
		}

		//method getting a string a.b.c.d/netmask
		public string GettingNetworkIDWithFormat()
		{
			string netWorkIDString = GettingAddressWithFormat();
			string CIDRString = GettingCIDRWithFormat();
			string output = netWorkIDString + '/' + CIDRString;
			return output;
		}
	}
}

