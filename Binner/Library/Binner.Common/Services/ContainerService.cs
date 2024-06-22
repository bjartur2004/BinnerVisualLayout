using Binner.Global.Common;
using Binner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Binner.Common.Services
{
    public class ContainerService : IContainerService
    {
        private readonly IStorageProvider _storageProvider;
        private readonly RequestContextAccessor _requestContext;

        public ContainerService(IStorageProvider storageProvider, RequestContextAccessor requestContextAccessor)
        {
            _storageProvider = storageProvider;
            _requestContext = requestContextAccessor;
        }

        public async Task<Container?> AddContainerAsync(Container container)
        {
            return await _storageProvider.AddContainerAsync(container, _requestContext.GetUserContext());
        }
    }
}
