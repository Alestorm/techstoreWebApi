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
        public Response<List<Builder>> GetAll()
        {
            Response<List<Builder>> response = new Response<List<Builder>>();
            response = _builderRepository.GetAll();
            return response;
        }
        public Response<Builder> GetById(int id)
        {
            Response<Builder> response = new Response<Builder>();
            response = _builderRepository.GetById(id);
            return response;
        }
        public Response<Builder> Update(Builder builder)
        {
            Response<Builder> response = new Response<Builder>();
            response = _builderRepository.Update(builder);
            return response;
        }
    }
}