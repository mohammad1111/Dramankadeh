namespace Dramankadeh.Core.DataModel;

public class CommonResultBase
{
    public string DeveloperMessage { get; set; }

    public bool HasError { get; set; }

    public Guid Id { get; set; }

    public static implicit operator bool(CommonResultBase result)
    {
        return !result.HasError;
    }
}