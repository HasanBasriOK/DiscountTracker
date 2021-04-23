using System;
using System.Net;
using DiscountTracker.Business.Abstraction;
using HtmlAgilityPack;

namespace DiscountTracker.MainService.Managers
{
    public class TeknosaManager
    {

        public double GetPrice(string productUrl)
        {
            double price = 0;
            Uri url = new Uri(productUrl);
            WebClient client = new WebClient();
            string html = client.DownloadString(url); // html kodları indiriyoruz.

            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(html); // html kodlarını bir HtmlDocment nesnesine yüklüyoruz.
            HtmlNode newPriceNode = document.DocumentNode.SelectSingleNode("//div[contains(@class,'new-price')]"); // a etiketlerinin içerisinden class haberbas olanları seçiyoruz.

            if (newPriceNode==null)
            {
                HtmlNode defaultPriceNode = document.DocumentNode.SelectSingleNode("//div[contains(@class,'default-price')]"); // a etiketlerinin içerisinden class haberbas olanları seçiyoruz.
                var priceStr = defaultPriceNode.InnerHtml.Replace("TL", "").Replace(" ", "").Replace("\n","").Replace("\r","").Replace("\t","").Replace(".", "").Replace(",", ".");

                price = Convert.ToDouble(priceStr);
            }
            else
            {
                var priceStr = newPriceNode.InnerHtml.Replace("TL", "").Replace(" ", "").Replace("\n", "").Replace("\r", "").Replace("\t", "").Replace(".","").Replace(",",".");
                price = Convert.ToDouble(priceStr);
            }

           
            return price;

        }
    }
}
