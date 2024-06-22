namespace Binner.Model.Requests
{
    public class UpdateContainerRequest
    {
        /// <summary>
        /// Part Type id
        /// </summary>
        public long ContainerId { get; set; }

        /// <summary>
        /// Displayed Label Of Container
        /// </summary>
        public string? Label { get; set; }

        /// <summary>
        /// Parent Container
        /// </summary>
        public long? ParentContainerId { get; set; }
    }
}
