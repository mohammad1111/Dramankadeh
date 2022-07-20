namespace Users.Write.Facades.Facade.Saga.CreateUser;

public interface ICreateUserService
{
   Task CreateUser(string email,string mobile,string firstname,string lastname,string address);
}