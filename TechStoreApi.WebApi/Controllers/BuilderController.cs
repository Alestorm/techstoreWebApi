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
        public ActionResult<Response<int>> Create([FromBody] Builder builder)
        {
            var response = _builderService.Create(builder);
            return response;
        }
        [HttpGet]
        public ActionResult<Response<List<Builder>>> GetAll()
        {
            var response = _builderService.GetAll();
            return response;
        }
        [HttpGet("{id}")]
        public ActionResult<Response<Builder>> GetById([FromRoute] int id)
        {
            var response = _builderService.GetById(id);
            return response;
        }
        [HttpPut]
        public ActionResult<Response<Builder>> Update([FromBody] Builder builder)
        {
            var response = _builderService.Update(builder);
            return response;
        }
    }
}
