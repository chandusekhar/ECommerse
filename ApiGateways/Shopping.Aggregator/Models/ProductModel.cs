using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Models
{
    public class ProductModel
    {
        public string Id { get; set; }
        public decimal Price { get; set; }
        public long Stock { get; set; }
    }
}
