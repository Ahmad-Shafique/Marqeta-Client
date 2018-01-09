using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarqetaClient
{
    class Program
    {


        static void Main(string[] args)
        {

            //WriteToFile.GetInstance().WriteToNewFile(@"Test.txt","Hello World");

            var newCard = new
            {
                start_date = "2017-01-01",
                name = "Example Card Product",
                config = new
                {
                    fulfillment = new
                    {
                        payment_instrument = "VIRTUAL_PAN"
                    },
                    poi = new
                    {
                        ecommerce = true
                    },
                    card_life_cycle = new
                    {
                        activate_upon_issue = true
                    }
                }
            };

            var jsonNewCard = JsonConvert.SerializeObject(newCard);

            var response = HttpHandler.GetInstance().PostRequestAndReceiveResponse(" https://shared-sandbox-api.marqeta.com/v3/cardproducts",
                                                     "application/json", jsonNewCard).Result;


            //var responseAsObject = JsonConvert.DeserializeObject(response.ToString());

            Console.WriteLine(response.ReadAsStringAsync().Result);






        Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
