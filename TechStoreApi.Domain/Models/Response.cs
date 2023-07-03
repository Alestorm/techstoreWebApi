using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStoreApi.Domain.Models
{
    public class Response<T>
    {
        public int State { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public object Exceptions { get; set; }

    }
}
