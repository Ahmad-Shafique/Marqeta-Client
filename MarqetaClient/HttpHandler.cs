using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace MarqetaClient
{
    public class HttpHandler : Singleton<HttpHandler>
    {

        private HttpContent CreateHttpContent(string key, string value)
        {
            return new FormUrlEncodedContent(new[] {
            new KeyValuePair<string, string>(key, value),
            });
        }

        private async Task<HttpResponseMessage> SendPostRequest(string Url, HttpContent Content)
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.PostAsync(Url,Content);
            }
        }
        

        public async Task<HttpContent> PostRequestAndReceiveResponse(string Url, string header, string value)
        {
           return (await SendPostRequest(Url, CreateHttpContent(header, value))).Content;
        }

        //// Get the stream of the content.
        //using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
        //{
        //    // Write the output.
        //    Console.WriteLine(await reader.ReadToEndAsync());
        //}

        
    }
}
