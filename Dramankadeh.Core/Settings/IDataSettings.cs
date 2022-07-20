namespace Dramankadeh.Core.Settings;

public interface IDataSettings
{
    string ConnectionString { get; }

    string MicroServiceName { get; }
}