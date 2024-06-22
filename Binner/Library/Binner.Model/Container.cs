using System.ComponentModel.DataAnnotations;

namespace Binner.Model
{
    /// <summary>
    /// Defines a type of part or category/sub-category
    /// </summary>
    public class Container : IEntity
    {
        /// <summary>
        /// Primary key
        /// </summary>
        [Key]
        public long ContainerId { get; set; }

        /// <summary>
        /// Displayed label of the contaienr
        /// </summary>
        public string? Label { get; set; }

        /// <summary>
        /// Id of the parent container
        /// </summary>
        public long? ParentContainerId { get; set; }


        /// <summary>
        /// Creation date
        /// </summary>
        public DateTime DateCreatedUtc { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Optional user id to associate
        /// </summary>
        public int? UserId { get; set; }


        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is Container container)
                return Equals(container);
            return false;
        }

        public bool Equals(Container other)
        {
            return other != null && ContainerId == other.ContainerId && UserId == other.UserId;
        }

        public override int GetHashCode()
        {
#if (NET462 || NET471)
            return PartTypeId.GetHashCode() ^ (UserId?.GetHashCode() ?? 0);
#else
            return HashCode.Combine(ContainerId, UserId);
#endif

        }

        public override string ToString()
        {
            return $"{ContainerId}: {Label}";
        }
    }
}
