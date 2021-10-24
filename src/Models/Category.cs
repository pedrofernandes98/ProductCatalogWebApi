using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogv2.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string title { get; set; }

        public IEnumerable<Product> Products { get; set; }

    }
}
