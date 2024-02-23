using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Challenge.Entities
{
    public class ProductMappings
    {
        [Key]
        public int Id { get; set; }
        public int ParentProductId { get; set; }
        public int ChildProductId { get; set; }
        public int RequiredQty { get; set; }
    }
}
