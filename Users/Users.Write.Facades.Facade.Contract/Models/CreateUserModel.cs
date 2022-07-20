using MassTransit;

namespace Users.Write.Facades.Facade.Contract.Models;

public class CreateUserState : SagaStateMachineInstance
{
    public Guid AuthenticationId { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Address { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }

    public Guid CorrelationId { get; set; }
}