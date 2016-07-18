using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using System.Net;
using System.Text.RegularExpressions;
using System.Web.Script.Services;
using System.IO;

namespace ConversaoMoeda
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class WebServiceMoeda : System.Web.Services.WebService
    {
        [WebMethod]
        public string ConvertYahoo(decimal amount, string fromCurrency, string toCurrency)
        {
            WebClient web = new WebClient();
            string url = string.Format("http://finance.yahoo.com/d/quotes.csv?e=.csv&f=sl1d1t1&s={0}{1}=X", fromCurrency.ToUpper(), toCurrency.ToUpper());
            string response = web.DownloadString(url);
            string[] values = Regex.Split(response, ",");
            string valor = values[1].Replace(".", ",");
            decimal rate = decimal.Parse(valor);
            return (rate * amount).ToString("0.00");
        }

        [WebMethod]
        public string ConvertGoogle(decimal amount, string fromCurrency, string toCurrency)
        {
            string url = String.Format("https://www.google.com/finance/converter?a={0}&from={1}&to={2}&meta={3}", amount, fromCurrency, toCurrency, Guid.NewGuid().ToString());
            WebRequest request = WebRequest.Create(url);
            StreamReader streamReader = new StreamReader(request.GetResponse().GetResponseStream(), System.Text.Encoding.ASCII);
            string result = Regex.Matches(streamReader.ReadToEnd(), "<span class=\"?bld\"?>([^<]+)</span>")[0].Groups[1].Value;
            return result.Substring(0, result.Length - 6);
        }
    }
}
