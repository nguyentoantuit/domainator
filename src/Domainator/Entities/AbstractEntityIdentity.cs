using System;
using System.Collections.Generic;

namespace Domainator.Entities
{
    /// <summary>
    /// A base class for the scalar type based identities such as <see cref="Int32"/>, <see cref="string"/>,
    /// <see cref="Guid"/>, etc. The class implements basic equality functionality.
    /// </summary>
    /// <typeparam name="TKey">The type of scalar type.</typeparam>
    public abstract class AbstractEntityIdentity<TKey> : IEntityIdentity, IEquatable<AbstractEntityIdentity<TKey>>
        where TKey : notnull
    {
        /// <summary>
        /// Gets internal value of the identity as CLR type.
        /// </summary>
        public abstract TKey Id { get; protected set; }

        /// <inheritdoc />
        public abstract string Tag { get; }

        /// <inheritdoc />
        public virtual string Value => Id.ToString();

        /// <inheritdoc />
        public virtual bool Equals(AbstractEntityIdentity<TKey>? other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return EqualityComparer<TKey>.Default.Equals(Id, other.Id) && Tag.Equals(other.Tag, StringComparison.Ordinal);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((AbstractEntityIdentity<TKey>) obj);
        }

        /// <summary>
        /// Returns a hash code value calculated based on <see cref="Id"/> and <see cref="Tag"/> properties.
        /// </summary>
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Tag);
        }

        public static bool operator ==(AbstractEntityIdentity<TKey>? left, AbstractEntityIdentity<TKey>? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AbstractEntityIdentity<TKey>? left, AbstractEntityIdentity<TKey>? right)
        {
            return !Equals(left, right);
        }
    }
}
