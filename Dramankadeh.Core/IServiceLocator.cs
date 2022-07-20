namespace Dramankadeh.Core;

public interface IServiceLocator
{
    T Resolve<T>();
    IEnumerable<T> ResolveAll<T>();
}