using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duck.Adapters
{
    class Adapter
    {
        private string baseURL = "https://foodgroup.herokuapp.com";
        private static Adapter instance;
        private Adapter()
        {

        }
        public static Adapter GetAdapter()
        {
            
            if(instance==null)
                {
                    instance = new Adapter();
                }
                return instance;
            

        }
        public string GetMenuAPI
        {
            get => String.Format(baseURL + "/api/category/1");
        }
        public string GetCreateOrderAPI
        {
            get => String.Format(baseURL + "api/create-order");
        }
   
    }
}
