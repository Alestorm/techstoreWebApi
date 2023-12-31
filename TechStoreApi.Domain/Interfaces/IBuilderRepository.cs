﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStoreApi.Domain.Models;

namespace TechStoreApi.Domain.Interfaces
{
    public interface IBuilderRepository
    {
        Response<int> Create(Builder builder);
        Response<List<Builder>> GetAll();
        Response<Builder> GetById(int id);
        Response<Builder> Update(Builder builder);
    }
}
