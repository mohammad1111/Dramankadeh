using System.ComponentModel.DataAnnotations.Schema;

namespace Darmankadeh.Core.Domain;

public abstract class Entity : IEquatable<Entity>
{
    protected Entity()
    {
        IsInUpdateMode = false;
    }

    [NotMapped] public bool IsInUpdateMode { get; } = true;

    public Guid Id { get; protected set; }

    public byte[] RowVersion { get; protected set; }

    public bool Equals(Entity? other)
    {
        return base.Equals((Entity)other);
    }
}