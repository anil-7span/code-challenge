using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Challenge.Entities
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Qty { get; set; }
        public bool IsAssembled { get; set; }
    }
}
