using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Application.Services
{
    public class ProductModel
    {
        public string Id { get; set; }
        public long Stock { get; set; }
        public decimal Price { get; set; }
    }
}
