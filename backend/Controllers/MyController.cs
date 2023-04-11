using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class MyController : ControllerBase
{
    private readonly ILogger<MyController> _logger;

    public MyController(ILogger<MyController> logger)
    {
        _logger = logger;
    }


    [HttpPost(Name = "ReceiveData")]
    public void Post()
    {
        Console.WriteLine("f");
        //Debug.WriteLine("f2");
    }
}
