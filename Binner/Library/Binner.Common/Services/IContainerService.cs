using Binner.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Binner.Common.Services
{
    public interface IContainerService
    {
        /// <summary>
        /// Add a new Container
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        Task<Container?> AddContainerAsync(Container container);


        /// <summary>
        /// Get all Containers
        /// </summary>
        /// <returns></returns>
        Task<ICollection<Container>> GetContainersAsync();

    }
}
