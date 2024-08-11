using Microsoft.AspNetCore.Mvc;
using MyAPI.Models;
using VLSMsolver;

public class VLSMService
{
    public VLSMService()
    {
    }

    public string getNetwork([FromBody] InputUser input){
        return input.majorNetwork;
    }

    public List<InputSubnet> getSubnets([FromBody] InputUser input){
        return input.ListOfSubnets;
    }

    public Result solver([FromBody] InputUser input){
        
        // Init some required object
        PriorityQueue<Subnet> queueSubnet = new PriorityQueue<Subnet>(new SubnetComparer());
        BinaryCalculator binaryCalculator = new BinaryCalculator();


        // Getting Info from user
        string networkId = input.majorNetwork;
        List<InputSubnet> listInputSubnet = input.ListOfSubnets;

        // Getting 4 Octet and netmask
        //// Getting Major Network 
        int firstOctet = Convert.ToInt16(networkId.Split('/')[0].Split('.')[0]);
        int secondOctet = Convert.ToInt16(networkId.Split('/')[0].Split('.')[1]);
        int thirdOctet = Convert.ToInt16(networkId.Split('/')[0].Split('.')[2]);
        int fourthOctet = Convert.ToInt16(networkId.Split('/')[0].Split('.')[3]);
        
        string majorNetwork = binaryCalculator.DecimalToBinary8bit(firstOctet) + binaryCalculator.DecimalToBinary8bit(secondOctet) + binaryCalculator.DecimalToBinary8bit(thirdOctet) + binaryCalculator.DecimalToBinary8bit(fourthOctet);

        //// Getting netmask
        int netMask = Convert.ToInt16(networkId.Split('/')[1]);

        //getting the number of subnets
        int numberOfSubnet = listInputSubnet.Count();

        // Console.WriteLine(majorNetwork);
        // Console.WriteLine(netMask);
        // Console.WriteLine(numberOfSubnet);

        // Adding to priority queue
        for (int i = 0; i < numberOfSubnet; i++){
            InputSubnet currentSubnet = listInputSubnet[i];

            queueSubnet.Enqueue(new Subnet(currentSubnet.order, currentSubnet.numberOfHost));
        }

        // Init Model
        Model model = new Model(majorNetwork, netMask, queueSubnet);

        List<SubNetworkID> output = model.Processing();
        Result _result = new Result();
        _result.majorNetwork = networkId;
        List<LAN> tempList = new List<LAN>();
        for (int i = 0; i < numberOfSubnet; i++)
            {
                SubNetworkID current = output[i];
                LAN currentLAN = new LAN();
                currentLAN.order = current.gettingOrder();
                currentLAN.networkAddress = current.GettingNetworkIDWithFormat();
                tempList.Add(currentLAN);
            }
        // Console.WriteLine(_result.majorNetwork);
        _result.result = tempList;
        // Console.WriteLine(tempList);
        return _result;
    }
}