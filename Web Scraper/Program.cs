using HtmlAgilityPack;
using System;
using System.Net.Http;

namespace WebScraper 
{
    class Program 
    {
        static void Main(string[] args)
        {
            String url = "https://weather.com/en-CA/weather/today/l/584018bec07ce9573837c14fa59da031fa6fcdeb1c3c9e3b2b27cb79ce254b5a?Goto=Redirected";
            var httpClicent = new HttpClient();
            var html = httpClicent.GetStringAsync(url).Result;
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            
            var tempElement = htmlDocument.DocumentNode.SelectSingleNode("//span[@class='CurrentConditions--tempValue--MHmYY']");
            var temp = tempElement.InnerText.Trim();
            Console.WriteLine("Temperature: " + temp);
            var weatherElement = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='CurrentConditions--phraseValue--mZC_p']");
            var weather = weatherElement.InnerText.Trim();
            Console.WriteLine("Weather: " + weather);

        }
    }
}

