using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStoreApi.Domain.Interfaces;
using TechStoreApi.Domain.Models;

namespace TechStoreApi.Application.Services
{
    public class BuilderService
    {
        private readonly IBuilderRepository _builderRepository;
        public BuilderService(IBuilderRepository builderRepository)
        {
            _builderRepository = builderRepository;
        }
        public Response<int> Create(Builder builder)
        {
            Response<int> response = new Response<int>();
            response = _builderRepository.Create(builder);
            return response;
        }
    }
}
