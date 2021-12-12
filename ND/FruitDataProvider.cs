using ND.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ND
{
    public class FruitDataProvider : IFruitDataProvider
    {
        private RestClient m_client;
        public FruitDataProvider()
        {
            m_client = new RestClient("https://www.fruityvice.com/api/fruit/");
            m_client.Timeout = -1;
            m_client.AddDefaultHeader("Authorization", "iTGusD5aFlUkAs9NV_nFw");
           
        }
        public List<Root> GetRecentFruits(string name)
        {
            try
            {


                // Uri baseUrl = new Uri("https://www.fruityvice.com/api/fruit/all");
                //IRestClient client = new RestClient(baseUrl);
                IRestRequest request = new RestRequest($"{name}", Method.GET);
                
            IRestResponse response = m_client.Execute(request);
           // Console.WriteLine(response.Content);

            List<Root> results = JsonConvert.DeserializeObject<List<Root>>(response.Content);
           
            return results;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
                
            }
        }

        public List<Root> GetRecentFruitsOfFamily(string family)
        {
            try
            {
                IRestRequest request = new RestRequest($"family/{family}", Method.GET);


                IRestResponse response = m_client.Execute(request);
              //  Console.WriteLine(response.Content);

                List<Root> results = JsonConvert.DeserializeObject<List<Root>>(response.Content);
                // var status = results[0].Status;
                return results;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;

            }
        }

        

        public List<Root> GetRecentFruitsOfGenus(string genus)
        {
            try
            {
                IRestRequest request = new RestRequest($"genus/{genus}", Method.GET);


                IRestResponse response = m_client.Execute(request);
              //  Console.WriteLine(response.Content);

                List<Root> results = JsonConvert.DeserializeObject<List<Root>>(response.Content);
                // var status = results[0].Status;
                return results;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;

            }
        }
        public List<Root> GetRecentSugaryFruits(double sugar)
        {
            try
            {
                IRestRequest request = new RestRequest($"sugar?min={sugar}", Method.GET);


                IRestResponse response = m_client.Execute(request);
             //   Console.WriteLine(response.Content);

                List<Root> results = JsonConvert.DeserializeObject<List<Root>>(response.Content);
                // var status = results[0].Status;
                return results;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;

            }
        }

        
    }
}
