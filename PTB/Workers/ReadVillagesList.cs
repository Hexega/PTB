using PTB.Models;
using PTB.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTB.Workers
{
    class ReadVillagesList : IWorker
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

        public ReadVillagesList(Account account, CustomHttpClient client, HtmlReader htmlReader, WebBrowser webBrowser, ToolStripStatusLabel progressLabel, ToolStripProgressBar progressBar)
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
            throw new NotImplementedException();
        }

        public void ExecuteWork(object sender, DoWorkEventArgs e)
        {
            ProgressLabel.Text = "Reading Villages List";
            Worker.ReportProgress(20);

            
        }

        public void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void StartWork()
        {
            throw new NotImplementedException();
        }
    }
}
