namespace PTB.Components
{
    partial class TempAccountPage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.AccountTabPage = new System.Windows.Forms.TabPage();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.tabControl.SuspendLayout();
            this.AccountTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.AccountTabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(896, 676);
            this.tabControl.TabIndex = 0;
            // 
            // AccountTabPage
            // 
            this.AccountTabPage.Controls.Add(this.webBrowser);
            this.AccountTabPage.Location = new System.Drawing.Point(4, 22);
            this.AccountTabPage.Name = "AccountTabPage";
            this.AccountTabPage.Size = new System.Drawing.Size(888, 650);
            this.AccountTabPage.TabIndex = 0;
            this.AccountTabPage.Text = "UserName - Speed";
            this.AccountTabPage.UseVisualStyleBackColor = true;
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(888, 650);
            this.webBrowser.TabIndex = 0;
            // 
            // TempAccountPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Name = "TempAccountPage";
            this.Size = new System.Drawing.Size(896, 676);
            this.tabControl.ResumeLayout(false);
            this.AccountTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage AccountTabPage;
        public System.Windows.Forms.TabControl tabControl;
        public System.Windows.Forms.WebBrowser webBrowser;
    }
}
