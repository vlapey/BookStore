using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]

public class OptionController : ControllerBase
{
    private readonly IOptions<ClownStringsModel> _options;
    
    public OptionController(IOptions<ClownStringsModel> options)
    {
        _options = options;
    }
    
    [HttpGet]
    public string GetString()
    {
        var str = _options.Value.HelloWorld;
        return str;
    }
}