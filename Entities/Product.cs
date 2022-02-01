using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cofetarie.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Price { get; set; }
        public virtual Recipe Recipe { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
