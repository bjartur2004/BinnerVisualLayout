using AnyMapper;
using Binner.Common;
using Binner.Common.Services;
using Binner.Model;
using Binner.Model.Configuration;
using Binner.Model.Requests;
using Binner.Model.Responses;
using Ganss.Xss;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Binner.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    public class ContainerController : ControllerBase
    {   
        private readonly IContainerService _containerService;
        private readonly ILogger<ContainerController> _logger;
        private readonly WebHostServiceConfiguration _config;

        public ContainerController(ILogger<ContainerController> logger, WebHostServiceConfiguration config, IContainerService ContainerService)
        {
            _logger = logger;
            _config = config;
            _containerService = ContainerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateContainer(CreateContainerRequest request)
        {
            var mappedContainer = Mapper.Map<CreateContainerRequest, Container>(request);
            mappedContainer.DateCreatedUtc = DateTime.UtcNow;

            // create container in database
            var container = await _containerService.AddContainerAsync(mappedContainer);

            var containerResponse = Mapper.Map<Container, ContainerResponse>(container);


            return CreatedAtAction(
                actionName: nameof(GetContainer),
                routeValues: new { id = container.ContainerId },
                value: containerResponse);
        }

        [HttpGet]
        public IActionResult GetContainer(GetContainerRequest request)
        {
            return Ok(request);
        }

        [HttpPut]
        public IActionResult UpdateContainer(UpdateContainerRequest request)
        {
            return Ok(request);
        }

        [HttpDelete]
        public IActionResult DeleteContainer(DeleteContainerRequest request)
        {
            return Ok(request);
        }
    }
}
