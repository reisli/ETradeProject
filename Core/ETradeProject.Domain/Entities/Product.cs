using ETradeProject.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeProject.Domain.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public int UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
