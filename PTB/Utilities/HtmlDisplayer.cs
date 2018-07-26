using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTB.Utilities
{
    public class HtmlDisplayer
    {
        public static void DisplayHtml(string html, WebBrowser browser)
        {

            browser.Navigate("about:blank");

            if (browser.Document != null)

            {

                browser.Document.Write(string.Empty);

            }

            browser.DocumentText = html;
        }
    }
}
