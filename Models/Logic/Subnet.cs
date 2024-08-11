using System;
namespace VLSMsolver
{
    public class Subnet
    {
        private int order;
        private int numberOfHosts;
        public Subnet(int _order, int _numberOfHosts)
        {
            order = _order;
            numberOfHosts = _numberOfHosts;
        }

        //properties
        public int gettingOrder()
        {
            return order;
        }

        public int gettingNumberOfHosts()
        {
            return numberOfHosts;
        }
		//method returns the approriate CIDR for the subnet based on the current number of hosts
		public int approriateCIDR()
        {
            if (numberOfHosts <= 65534 && numberOfHosts > 32766)
            {
                return 16;
            }
            else if (numberOfHosts <= 32766 && numberOfHosts > 16382)
            {
                return 17;
            }
            else if (numberOfHosts <= 16382 && numberOfHosts > 8190)
            {
                return 18;
            }
            else if (numberOfHosts <= 8190 && numberOfHosts > 4094)
            {
                return 19;
            }
            else if (numberOfHosts <= 4094 && numberOfHosts > 2046)
            {
                return 20;
            }
            else if (numberOfHosts <= 2046 && numberOfHosts > 1022)
            {
                return 21;
            }
            else if (numberOfHosts <= 1022 && numberOfHosts > 510)
            {
                return 22;
            }
            else if (numberOfHosts <= 510 && numberOfHosts > 254)
            {
                return 23;
            }
            else if (numberOfHosts <= 254 && numberOfHosts > 126)
            {
                return 24;
            }
            else if (numberOfHosts <= 126 && numberOfHosts > 62)
            {
                return 25;
            }
            else if (numberOfHosts <= 62 && numberOfHosts > 30)
            {
                return 26;
            }
            else if (numberOfHosts <= 30 && numberOfHosts > 14)
            {
                return 27;
            }
            else if (numberOfHosts <= 14 && numberOfHosts > 6)
            {
                return 28;
            }
            else if (numberOfHosts <= 6 && numberOfHosts > 2)
            {
                return 29;
            }
            return 30;
        }
	}
}

