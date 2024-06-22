namespace Binner.Model.Requests
{
    public class CreateContainerRequest
    {
        /// <summary>
        /// Displayed Label Of Container
        /// </summary>
        public string? Label { get; set; }

        /// <summary>
        /// Parent Container
        /// If empty it will be a child of the root container
        /// </summary>
        public long? ParentContainerId { get; set; }
    }
}
