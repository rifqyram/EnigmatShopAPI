using Microsoft.AspNetCore.Mvc;

namespace EnigmatShopAPI.Controllers;

[ApiController]
[Route("api/hello")]
public class HelloController
{
    [HttpGet]
    public string SayHello()
    {
        return "Hello World";
    }

    [HttpGet("get-object")]
    public object GetObject()
    {
        return new
        {
            Id = Guid.NewGuid(),
            Name = "Budi",
            Date = DateTime.Now
        };
    }

    [HttpGet("get-array")]
    public List<object> GetArrayObj()
    {
        return new List<object>
        {
            new
            {
                Id = Guid.NewGuid(),
                Name = "Budi",
                Date = DateTime.Now
            },
            new
            {
                Id = Guid.NewGuid(),
                Name = "Rio",
                Date = DateTime.Now
            }
        };
    }

    [HttpGet("{name}")]
    public string GetWithPathVariable(string name)
    {
        return $"Hello {name}";
    }

    // /api/hello/query-param?name=Budi&isActive=true
    [HttpGet("query-param")]
    public string GetWithQueryParam([FromQuery] string name, [FromQuery] bool isActive)
    {
        return $"Name: {name}, isActive: {isActive}";
    }
}