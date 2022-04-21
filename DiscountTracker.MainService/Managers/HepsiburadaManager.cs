using System;
using System.IO;
using System.Net;
using DiscountTracker.MainService.Managers.Abstraction;
using HtmlAgilityPack;

namespace DiscountTracker.MainService.Managers
{
    public class HepsiburadaManager : IECommerceManager
    {
        public double GetPrice(string productUrl)
        {
            double price = 0;
            Uri url = new Uri(productUrl);
            string html = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(html);
            HtmlNode priceNode = document.DocumentNode.SelectSingleNode("//span[@itemprop='price']");
            var priceStr = priceNode.GetAttributeValue("content", "");
            price = Convert.ToDouble(priceStr);

            return price;

        }
    }
}
