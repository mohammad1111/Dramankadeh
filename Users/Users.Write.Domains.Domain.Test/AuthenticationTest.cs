using Users.Write.Domains.Domain.Users;
using Users.Write.Domains.Domain.Users.Exceptions;

namespace Users.Write.Domains.Domain.Test;

public class UsersTest
{
    [SetUp]
    public void Setup()
    {
    }
private static Guid _guid=Guid.Empty;
    [Test]
    [TestCase("a", "b","a",_guid)]
    public void should_create_a_authenticate_with_Valid_email_and_mobile(string firstname, string lastname, string address,
        Guid authenticationId)
    {
        var Users = new Users.User( firstname,lastname,address,authenticationId);
        Assert.IsNotNull(Users.Id);
    }

}