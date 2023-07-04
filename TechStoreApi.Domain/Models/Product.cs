using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStoreApi.Domain.Models
{
    public class Product
    {
        public int Code { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int BuilderCode { get; set; }
    }
}
