using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cofetarie.Entities
{
    public class Order
    {
        public int Id { get; set;}
        public int Price { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
