using Priority_Queue;
using PTB.Models;
using PTB.Utilities;
using PTB.Workers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTB.Controllers
{
    public class GameController
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

        // Workers
        public IPriorityQueue<IWorker, int> WorkerPriorityQueue { get; set; }


        public GameController(Account account, TabPage tabPage)
        {
            tabPage.Text = account.AccountName + " - Speed: " + account.Speed.ToString();

            PlayerAccount = account;

            WebBrowser = (WebBrowser)tabPage.Controls.Find("webBrowser", true)[0];
            WebBrowser.ScriptErrorsSuppressed = true;

            StatusStrip ss = (StatusStrip)tabPage.Controls.Find("statusStrip1", true)[0];

            ProgressBar = (ToolStripProgressBar)ss.Items.Find("tspbOpperationProgress", true)[0];
            ProgressLabel = (ToolStripStatusLabel)ss.Items.Find("tsslOpperation", true)[0];

            ProgressLabel.Text = "Starting up, starting login soon.";

            Client = new CustomHttpClient(account);
            HtmlReader = new HtmlReader();

            WorkerPriorityQueue = new SimplePriorityQueue<IWorker, int>();

            var loginWorker = new LoginWorker(PlayerAccount, Client, HtmlReader, WebBrowser, ProgressLabel, ProgressBar);
            loginWorker.Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;

            WorkerPriorityQueue.Enqueue(loginWorker, 0);

            IWorker worker = WorkerPriorityQueue.Dequeue();
            worker.StartWork();
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }
    }
}
