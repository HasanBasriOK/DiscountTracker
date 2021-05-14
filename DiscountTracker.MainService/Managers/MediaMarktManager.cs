using System;
using System.Net;
using DiscountTracker.MainService.Managers.Abstraction;
using HtmlAgilityPack;

namespace DiscountTracker.MainService.Managers
{
    public class MediaMarktManager : IECommerceManager
    {
        public double GetPrice(string productUrl)
        {
            double price = 0;
            Uri url = new Uri(productUrl);
            WebClient client = new WebClient();
            string html = client.DownloadString(url);

            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(html);
            HtmlNode priceNode = document.DocumentNode.SelectSingleNode("//meta[@itemprop='price']");
            price = priceNode.GetAttributeValue("content", 0);

            return price;

        }
    }
}
