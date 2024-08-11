using System;
namespace VLSMsolver
{
    public class IPCalculator
    {
        public IPCalculator()
        {
        }

        //This function returns the netmask of the subnet
        private string netmaskCalculate(int subnet)
        {
            string output = "";
            for (int i = 1; i <= subnet; i++)
            {
                output += '1';
            }
            for (int i = subnet + 1; i <= 32; i++)
            {
                output += '0';
            }

            return output;
        }

        //This function returns the complement of the netmask
        private string complementOfNetmask(string netmask)
        {
            string output = "";

            for (int i = 0; i < 32; i++)
            {
                if (netmask[i] == '1')
                {
                    output += '0';
                }
                else
                {
                    output += '1';
                }
            }

            return output;
        }

        //This function creates the broacast of a subnetwork given a network address
        private string broacastIP(string currentNetworkID, int subnet)
        {
            string Netmask = netmaskCalculate(subnet);
            string _complementOfNetmask = complementOfNetmask(Netmask);

            string output = "";

            for (int i = 0; i < 32; i++)
            {
                char currentComplementIndex = _complementOfNetmask[i];
                char currentNetworkIDIndex = currentNetworkID[i];

                if (currentComplementIndex == '0' && currentNetworkIDIndex == '0')
                {
                    output += '0';
                    continue;
                }

                output += '1';
            }

            return output;
        }

        //This function returns the next ID Network given a networkID
        public string nextNetworkAddress(string currentNetworkID, int subnet)
        {
            string _broacastIP = broacastIP(currentNetworkID, subnet);
            string OneInBinary = "00000000000000000000000000000001";
            int carry = 0;
            string result = "";

            // Iterate through each bit of the binary strings
            for (int i = 31; i >= 0; i--)
            {
                int bitA = int.Parse(_broacastIP[i].ToString());
                int bitB = int.Parse(OneInBinary[i].ToString());

                // Calculate the sum and carry for this bit
                int sum = bitA ^ bitB ^ carry;
                carry = (bitA & bitB) | (bitB & carry) | (bitA & carry);

                // Add the sum to the result string
                result = sum.ToString() + result;
            }

            return result;
        }
    }
}
