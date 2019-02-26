using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace App1
{
    public class UserClass
    {
        /// <summary>
        ///
        /// param.Add("block1", TextBox1.Text);
///        param.Add("block2", TextBox2.Text);
///        param.Add("block3", TextBox3.Text);
///        param.Add("SteamId", SteamId.Text);
///        param.Add("TokenId", TokenId.Text);

        /// </summary>
        /// <param name="pDictionary"></param>
        /// <returns></returns>
        public async Task<string> Run(IDictionary<string,string> pDictionary)
        {

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://steamcommunity.com/");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/57.0.2987.133 Safari/537.36");
            httpClient.DefaultRequestHeaders.Referrer = 
                new Uri(string.Concat("https://steamcommunity.com/tradeoffer/new/?partner=",pDictionary["SteamId"], "&token=",pDictionary["TokenId"]));


            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("sessionid", pDictionary["sessionid"]),
                new KeyValuePair<string, string>("serverid","1"),
                new KeyValuePair<string, string>("captcha",""),
                new KeyValuePair<string, string>("tradeofferid_countered",""),
                new KeyValuePair<string, string>("partner",pDictionary["SteamId"]),
                new KeyValuePair<string, string>("tradeoffermessage",pDictionary["block1"]),
                new KeyValuePair<string, string>("json_tradeoffer",pDictionary["block3"]),
            });

            var response = await httpClient.PostAsync("tradeoffer/new/send", formContent);
            if (response.StatusCode  == HttpStatusCode.OK)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return "500 fatal error";
        }
    }
}
