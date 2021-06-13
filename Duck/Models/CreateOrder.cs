using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duck.Models
{
    public class DataC
    {
        public int order_id { get; set; }
    }

    public class CreateOrder
    {
        public string message { get; set; }
        public DataC data { get; set; }
    }
}