using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Challenge.Entities
{
    public class ProductMappings
    {
        public int Id { get; set; }
        public int ParentProductId { get; set; }
        public int ChildProductId { get; set; }
        public int RequiredQty { get; set; }
    }
}
