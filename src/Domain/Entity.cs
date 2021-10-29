namespace TeaRoundPicker.Domain;

public abstract class Entity<T>
{
    public virtual T Id { get; protected set; }

    protected Entity(T id)
    {
        Id = id;
    }

    public override bool Equals(object obj)
    {
        if (obj is not Entity<T> other)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (Id.Equals(default) || other.Id.Equals(default))
            return false;

        return Id.Equals(other.Id);
    }

    public static bool operator ==(Entity<T> a, Entity<T> b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(Entity<T> a, Entity<T> b)
    {
        return !(a == b);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
