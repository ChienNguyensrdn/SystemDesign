using Microsoft.AspNetCore.Mvc;
using UberSystem.Service;
using UberSystem.Domain.Entities;
using UberSystem.Domain.Interfaces.Services;

namespace UberSystem.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CabController : ControllerBase
{
    private readonly ILogger<CabController> _logger;
    private ICabService _cabService;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="cabService"></param>
    public CabController(
        ILogger<CabController> logger
         , ICabService cabService
    )
    {
        _logger = logger;
        _cabService = cabService;
    }
}
