using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogv2.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string title { get; set; }
        public string description { get; set; }

        public decimal price { get; set; }

        public int quantity { get; set; }

        public string image { get; set; }

        public DateTime createDate { get; set; }

        public DateTime lastUpdateDate { get; set; }

        public int categoryId { get; set; }

        public Category category { get; set; }
    }
}
