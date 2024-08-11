using System;
namespace VLSMsolver
{
	public class SubNetworkID : NetworkID
	{
		private int order;
		public SubNetworkID(string _networkAddress, int _cidr, int _order) : base(_networkAddress, _cidr)
		{
			order = _order;
		}

		public int gettingOrder()
        {
			return order;
        }
	}
}

