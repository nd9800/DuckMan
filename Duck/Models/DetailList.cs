using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duck.Models
{
    public class DetailList
    {

        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public int price { get; set; }
    }

    public class Root2
    {
        public string message { get; set; }
        public DetailList data { get; set; }
    }


}
