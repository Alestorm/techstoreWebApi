using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TechStoreApi.Application.Services;
using TechStoreApi.Domain.Models;

namespace TechStoreApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuilderController : ControllerBase
    {
        private readonly BuilderService _builderService;
        public BuilderController(BuilderService builderService)
        {
            _builderService = builderService;
        }
        [HttpPost]
        public IActionResult Create([FromBody] Builder builder)
        {
            var response = _builderService.Create(builder);
            return Ok(JsonConvert.SerializeObject(response));
        }
    }
}
