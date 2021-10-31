namespace TeaRoundPicker.Domain;

/// <summary>
/// Represents an object that has an identity. Entities are compared by their identity; two entities with the same id are representing the same thing.
/// </summary>
public abstract class Entity<T>
{
    /// <summary>
    /// Gets a value which uniquley identifies an entity.
    /// </summary>
    public virtual T Id { get; protected set; }

    /// <summary>
    /// Creates a new instance of an entity object.
    /// </summary>
    /// <param name="id"></param>
    protected Entity(T id)
    {
        Id = id;
    }

    /// <summary>
    /// Determines whether the specified entity is equal to the current entity.
    /// </summary>
    public override bool Equals(object? obj)
    {
        if (obj is not Entity<T> other)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (Id.Equals(default) || other.Id.Equals(default))
            return false;

        return Id.Equals(other.Id);
    }

    /// <summary>
    /// Determines if two entitiy objects are representing the same entity.
    /// </summary>
    public static bool operator ==(Entity<T> a, Entity<T> b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    /// <summary>
    /// Determines if two entitiy objects are representing different entities.
    /// </summary>
    public static bool operator !=(Entity<T> a, Entity<T> b)
    {
        return !(a == b);
    }

    /// <summary>
    /// Returns the hash-code of the current entity.
    /// </summary>
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
