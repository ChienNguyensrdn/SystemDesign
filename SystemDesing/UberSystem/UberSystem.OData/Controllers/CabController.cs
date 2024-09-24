using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using UberSystem.Domain.Interfaces.Services;

namespace UberSystem.OData.Controllers;

[Route("api/[controller]")]
public class CabController : ODataController
{
    private readonly ILogger<CabController> _logger;
    private ICabService _cabService;
    
    public CabController(ICabService cabService, ILogger<CabController> logger)
    {
        _cabService = cabService;
        _logger = logger;
    }
    
    // GET: api/values
    [HttpGet]
    [EnableQuery]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody]string value)
    {
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}