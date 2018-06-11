using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GithubApiTest
{
    class Program
    {
        public static async void HttpClient2()
        {
            string url = "https://api.github.com/user";
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "GithubApiTest");
                client.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue(
        "Basic",
        Convert.ToBase64String(
            System.Text.UTF8Encoding.UTF8.GetBytes(
                string.Format("{0}:{1}", "PedroHMSilva29", "pwd"))));
                var response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;

                    Console.WriteLine(responseString);
                }
                Console.WriteLine(response.ToString());
            }
        }


        public static async void HttpClientAsync(string url)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "GithubApiTest");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", "8f3484ebeae5a01583d94a7944f0b35ad20dad20");
                var response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;

                    Console.WriteLine(responseString);
                }
                Console.WriteLine(response.ToString());
            }
        }


        public static object HttpWebRequestClient(string uri)
        {
            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
            request.Method = "GET";
            request.Proxy = null;
            request.PreAuthenticate = true;
            request.UserAgent = "GithubApiTest";
            var crds = new NetworkCredential("PedroHMSilva29", "pwd");
            CredentialCache myCredentialCache = new CredentialCache();
            myCredentialCache.Add(new Uri(uri), "Basic", crds);
            request.Credentials = myCredentialCache;
            request.Accept = "application/vnd.github.v3+json";
            request.KeepAlive = false;
            
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }
        }



        static void  Main(string[] args)
        {
            string url = "https://api.github.com/user?access_token=token";

            //HttpClientAsync(url);
            //HttpWebRequestClient(url)
            //3 commit
            HttpClient2();
            //var jsonRequest = JSONHelper.GetJSONString(uri);
            //var objRequest = JSONHelper.GetObjectFromJSONString<Rootobject>(jsonRequest);
        }
    }
}
