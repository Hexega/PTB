using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PTB.Utilities
{
    public class HtmlReader
    {
        
        public HtmlReader()
        {

        }

        public HtmlNode Find(string html, string search)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            return doc.DocumentNode.SelectSingleNode("//input[@name='ft']");
        }
    }
}
