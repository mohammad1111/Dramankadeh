namespace Dramankadeh.Core.DataModel;

public class GigCommonResultBase
{
    public string DeveloperMessage { get; set; }

    public bool HasError { get; set; }

    public Guid Id { get; set; }

    public static implicit operator bool(GigCommonResultBase result)
    {
        return !result.HasError;
    }
}