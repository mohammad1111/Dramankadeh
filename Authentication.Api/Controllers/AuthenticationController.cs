using Authentications.Read.Applications.Application.Contract.ViewModels;
using Authentications.Read.Facades.Facade.Services.Contract.Services;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<AuthenticationController> _logger;
    private readonly IAuthenticationFacadeReadService _authenticationFacadeReadService;

    public AuthenticationController(ILogger<AuthenticationController> logger,
        IAuthenticationFacadeReadService authenticationFacadeReadService)
    {
        _logger = logger;
        _authenticationFacadeReadService = authenticationFacadeReadService;
    }

    [HttpGet("{id:guid}")]
    public async Task<AuthenticationViewModel> Get(Guid id)
    {
        return await _authenticationFacadeReadService.GetById(id);
    }
}