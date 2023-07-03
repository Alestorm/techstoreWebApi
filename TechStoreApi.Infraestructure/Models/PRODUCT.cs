using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStoreApi.Infraestructure.Models
{
    public class PRODUCT
    {
        public int CODE_IN { get; set; }
        public string NAME_VC { get; set; }
        [DataType(DataType.Currency)]
        public decimal PRICE_DE { get; set; }
        public int BUILDER_CODE_IN { get; set; }
        public PRODUCT()
        {
            NAME_VC = string.Empty;
        }
    }
}
