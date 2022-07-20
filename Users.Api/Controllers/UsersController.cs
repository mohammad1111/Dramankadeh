using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Http;
using Users.Api.Dtos;
using Users.Read.Facades.Facade.Services.Contract.Services;
using Users.Write.Facades.Facade.Contract.Services;
using Users.Write.Facades.Facade.Saga.CreateUser;

namespace Users.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersFacadeReadService _usersFacadeReadService;
    private readonly AuthenticationServiceClient _authenticationServiceClient;
    private readonly ICreateUserService _createUserService;


    public UsersController( IUsersFacadeReadService usersFacadeReadService, AuthenticationServiceClient authenticationServiceClient,ICreateUserService createUserService)
    {
        _usersFacadeReadService = usersFacadeReadService;
        _authenticationServiceClient = authenticationServiceClient;
        _createUserService = createUserService;
    }

    [HttpGet("{id:guid}")]
    public async Task<UserDto> Get(Guid id)
    {
        var user = await _usersFacadeReadService.GetById(id);
        var authenticationViewModel = await _authenticationServiceClient.Get(user.AuthenticationId);
        
        return new UserDto
        {
            Id = user.Id,
            Firstname = user.Firstname,
            Lastname = user.Lastname,
            Mobile = authenticationViewModel.Mobile,
            Email = authenticationViewModel.Email
        };
    }

    [HttpPost]
    public async Task Post(CreateUserDto createUserDto)
    {
        _createUserService.CreateUser(createUserDto.Email, createUserDto.Mobile, createUserDto.Firstname,
            createUserDto.Lastname, createUserDto.Address);
    }
}