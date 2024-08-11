using Microsoft.AspNetCore.Mvc;
using MyAPI.Models;

public class VLSMService
{
    public VLSMService()
    {
    }

    public string getNetwork([FromBody] InputUser input){
        Console.WriteLine("input");
        return input.majorNetwork;
    }

    public List<InputSubnet> getSubnets([FromBody] InputUser input){
        return input.ListOfSubnets;
    }

    public string solver([FromBody] InputUser input){
        return "haah";
    }
}