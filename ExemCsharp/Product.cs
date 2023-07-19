using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemCsharp
{
    [Table(name: "Product")]
    internal class Product
    {
        [Key]
        public string ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
