using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTB.Workers
{
    public interface IWorker
    {
        void Completed(object sender, RunWorkerCompletedEventArgs e);
        void ExecuteWork(object sender, DoWorkEventArgs e);
        void ProgressChanged(object sender, ProgressChangedEventArgs e);
        void StartWork();
    }
}
