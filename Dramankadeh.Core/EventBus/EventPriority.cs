namespace Dramankadeh.Core.EventBus;

[AttributeUsage(AttributeTargets.Class)]
public class EventPriority : Attribute
{
    public EventPriority(byte priority)
    {
        Priority = priority;
    }

    public byte Priority { get; set; }
}