using Microsoft.AspNetCore.Mvc;
using MyAPI.Models;

[ApiController]
[Route("api/[controller]")]
// public class VLSMController : ControllerBase
// {
//     private readonly VLSMService _VLSMService;

//     public VLSMController()
//     {
//         _VLSMService = new VLSMService();
//     }

//     [HttpGet]
//     public ActionResult<string> getMajorNetwork()
//     {
//         var majorNetwork = _VLSMService.getMajorNetwork;
//         return Ok(majorNetwork);
//     }
// }

public class VLSMController : ControllerBase
{
    private readonly VLSMService _vlsmService;

    public VLSMController()
    {
        _vlsmService = new VLSMService();
    }

    [HttpPost("network")]
    public IActionResult getNetwork([FromBody] InputUser inputUser)
    {
        var outputResponse = _vlsmService.getNetwork(inputUser);
        return Ok(outputResponse);
    }

    [HttpPost("subnets")]
    public IActionResult getSubnets([FromBody] InputUser inputUser)
    {
        var outputResponse = _vlsmService.getSubnets(inputUser);
        return Ok(outputResponse);
    }
}