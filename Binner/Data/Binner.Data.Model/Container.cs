using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Binner.Data.Model
{
    /// <summary>
    /// Defines a type of part or category/sub-category
    /// </summary>
    public class Container : IEntity, IUserData
    {
        /// <summary>
        /// Primary key
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        /// Associated user for user defined types, null for system defined types
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// Associated organization
        /// </summary>
        public int? OrganizationId { get; set; }

        /// <summary>
        /// Creation date
        /// </summary>
        public DateTime DateCreatedUtc { get; set; }


#if INITIALCREATE
        public DateTime DateModifiedUtc { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }
#endif

        [ForeignKey(nameof(ParentContainerId))]
        public Container? ParentContainer { get; set; }

    }
}
