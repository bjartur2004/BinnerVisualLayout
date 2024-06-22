namespace Binner.Model.Responses
{
    /// <summary>
    /// A user defined project
    /// </summary>
    public class ContainerResponse
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public long ContainerId { get; set; }

        /// <summary>
        /// Displayed Label Of Container
        /// </summary>
        public string? Label { get; set; }


        /// <summary>
        /// The Parent Container
        /// </summary>
        public long? ParentContainerId { get; set; }

        /// <summary>
        /// Creation date
        /// </summary>
        public DateTime DateCreatedUtc { get; set; } = DateTime.UtcNow;

    }
}
