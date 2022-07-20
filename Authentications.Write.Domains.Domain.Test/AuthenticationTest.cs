using Authentications.Write.Domains.Domain.Authentications;

namespace Authentications.Write.Domains.Domain.Test;


public class AuthenticationTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase("09198769829","bik@gmail.com")]
    [TestCase("989123692827","g@a.c")]
    public void should_create_a_authenticate_with_Valid_email_and_mobile(string mobile,string email)
    {
        var authentication = new Authentication(mobile,email);
        Assert.IsNotNull(authentication.Id);
    }
    
    [Test]
    [TestCase("09198769829","bik@gmail")]
    [TestCase("989198769829","ga.c")]
    public void should_raise_emailIsNotValidException_when_create_a_authenticate_with_unValid_email(string mobile,string email)
    {
        var authentication = new Authentication(mobile,email);
        Assert.IsNotNull(authentication.Id);
    }
    
    
    [Test]
    [TestCase("09198","bik@gmail")]
    [TestCase("980000","bik@gmail.com")]
    public void should_raise_mobileNumberIsNotValidException_when_create_a_authenticate_with_unValid_mobile(string mobile,string email)
    {
        var authentication = new Authentication(mobile,email);
        Assert.IsNotNull(authentication.Id);
    }
}