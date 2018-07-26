using PTB.Models;
using PTB.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTB.Workers
{
    public class LoginWorker : IWorker
    {
        // UI components for updating task progress or show completion.
        public ToolStripStatusLabel ProgressLabel { get; set; }
        public ToolStripProgressBar ProgressBar { get; set; }
        public WebBrowser WebBrowser { get; set; }

        // Data processing
        public CustomHttpClient Client { get; set; }
        public HtmlReader HtmlReader { get; set; }
        public BackgroundWorker Worker { get; set; }

        // Models
        public Account PlayerAccount { get; set; }

        public LoginWorker(Account account, CustomHttpClient client, HtmlReader htmlReader, WebBrowser webBrowser, ToolStripStatusLabel progressLabel, ToolStripProgressBar progressBar)
        {
            PlayerAccount = account;
            Client = client;
            HtmlReader = htmlReader;

            WebBrowser = webBrowser;
            ProgressLabel = progressLabel;
            ProgressBar = progressBar;

            Worker = new BackgroundWorker();
            Worker.WorkerReportsProgress = true;

            Worker.DoWork += ExecuteWork;
            Worker.ProgressChanged += ProgressChanged;
            Worker.RunWorkerCompleted += Completed;
        }

        public void Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            HtmlDisplayer.DisplayHtml(e.Result.ToString(), WebBrowser);
            ProgressLabel.Text = "Login complete!";
        }

        public void ExecuteWork(object sender, DoWorkEventArgs e)
        {
            ProgressLabel.Text = "Logging in!";
            Worker.ReportProgress(20);

            var result = Client.Get("/login.php");

            Thread.Sleep(300);

            var html = result.Content.ReadAsStringAsync().Result;

            Worker.ReportProgress(40);

            Thread.Sleep(300);

            Worker.ReportProgress(60);

            var ftHiddenField = HtmlReader.Find(html, "//input[@name='ft']");
            var ft = ftHiddenField.Attributes.FirstOrDefault(x => x.Name == "value").Value;

            var loginHiddenField = HtmlReader.Find(html, "//input[@name='login']");
            var login = loginHiddenField.Attributes.FirstOrDefault(x => x.Name == "value").Value;

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("ft", ft), // get from html
                new KeyValuePair<string, string>("user", PlayerAccount.AccountName),
                new KeyValuePair<string, string>("pw", PlayerAccount.Password),
                new KeyValuePair<string, string>("s1", "login"),
                new KeyValuePair<string, string>("w", "1920:1080"),
                new KeyValuePair<string, string>("login", login), // get from html
            });

            Thread.Sleep(300);

            Worker.ReportProgress(80);

            Thread.Sleep(300);

            result = Client.Post("/login.php", content);

            html = result.Content.ReadAsStringAsync().Result;

            Worker.ReportProgress(100);

            e.Result = html;
        }

        public void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBar.Value = e.ProgressPercentage;
        }

        public void StartWork()
        {
            Worker.RunWorkerAsync();
        }
    }
}
