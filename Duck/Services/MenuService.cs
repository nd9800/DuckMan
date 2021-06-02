using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;


namespace Duck.Services
{
    class MenuService
    {
        private Adapters.Adapter _adapter = Adapters.Adapter.GetAdapter();
        public async Task<Models.Root> GetMenu()
        {
            HttpClient httpClient = new HttpClient();//shipper
            var response = await (httpClient.GetAsync(_adapter.GetMenuAPI));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var stringcontent = await response.Content.ReadAsStringAsync(); //da lay duoc het api qua dang string //read response content
                                                                                // convert string content sang object

                Models.Root g = JsonConvert.DeserializeObject<Models.Root>(stringcontent);
                return g;

            }
            return null;
        }
    }
}
