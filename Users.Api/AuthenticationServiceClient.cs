namespace Users.Api;


public class AuthenticationServiceClient
{
    private readonly HttpClient _client;

    public AuthenticationServiceClient(HttpClient client)
    {
        _client = client;
    }

    public Task<AuthenticationViewModel> Get(Guid id)
    {
        //todo: get authentication data using _client.
        throw new NotImplementedException();
    }
}

public class AuthenticationViewModel
{
    public string Email { get; set; }
    
    public string Mobile { get; set; }
} 