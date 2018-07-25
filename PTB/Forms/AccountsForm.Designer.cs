namespace PTB.Forms
{
    partial class AccountsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvAccounts = new System.Windows.Forms.ListView();
            this.chAccountName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chServer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSpeed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSpeed = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDeleteAccount = new System.Windows.Forms.Button();
            this.btnSaveAccount = new System.Windows.Forms.Button();
            this.btnNewAccount = new System.Windows.Forms.Button();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbRomans = new System.Windows.Forms.RadioButton();
            this.rbGauls = new System.Windows.Forms.RadioButton();
            this.rbTeutons = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvAccounts
            // 
            this.lvAccounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chAccountName,
            this.chServer,
            this.chSpeed});
            this.lvAccounts.FullRowSelect = true;
            this.lvAccounts.GridLines = true;
            this.lvAccounts.Location = new System.Drawing.Point(12, 12);
            this.lvAccounts.MultiSelect = false;
            this.lvAccounts.Name = "lvAccounts";
            this.lvAccounts.Size = new System.Drawing.Size(363, 426);
            this.lvAccounts.TabIndex = 0;
            this.lvAccounts.UseCompatibleStateImageBehavior = false;
            this.lvAccounts.View = System.Windows.Forms.View.Details;
            this.lvAccounts.SelectedIndexChanged += new System.EventHandler(this.lvAccounts_SelectedIndexChanged);
            // 
            // chAccountName
            // 
            this.chAccountName.Tag = "Account Name";
            this.chAccountName.Text = "Account Name";
            this.chAccountName.Width = 128;
            // 
            // chServer
            // 
            this.chServer.Text = "Server";
            this.chServer.Width = 170;
            // 
            // chSpeed
            // 
            this.chSpeed.Text = "Speed";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtSpeed);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnDeleteAccount);
            this.groupBox1.Controls.Add(this.btnSaveAccount);
            this.groupBox1.Controls.Add(this.btnNewAccount);
            this.groupBox1.Controls.Add(this.txtServer);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtAccountName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(381, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 426);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account Settings";
            // 
            // txtSpeed
            // 
            this.txtSpeed.Location = new System.Drawing.Point(131, 96);
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.Size = new System.Drawing.Size(147, 20);
            this.txtSpeed.TabIndex = 10;
            this.txtSpeed.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Speed of server";
            // 
            // btnDeleteAccount
            // 
            this.btnDeleteAccount.Location = new System.Drawing.Point(209, 397);
            this.btnDeleteAccount.Name = "btnDeleteAccount";
            this.btnDeleteAccount.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteAccount.TabIndex = 8;
            this.btnDeleteAccount.Text = "Delete";
            this.btnDeleteAccount.UseVisualStyleBackColor = true;
            this.btnDeleteAccount.Click += new System.EventHandler(this.btnDeleteAccount_Click);
            // 
            // btnSaveAccount
            // 
            this.btnSaveAccount.Location = new System.Drawing.Point(110, 397);
            this.btnSaveAccount.Name = "btnSaveAccount";
            this.btnSaveAccount.Size = new System.Drawing.Size(75, 23);
            this.btnSaveAccount.TabIndex = 7;
            this.btnSaveAccount.Text = "Save";
            this.btnSaveAccount.UseVisualStyleBackColor = true;
            this.btnSaveAccount.Click += new System.EventHandler(this.btnSaveAccount_Click);
            // 
            // btnNewAccount
            // 
            this.btnNewAccount.Location = new System.Drawing.Point(9, 397);
            this.btnNewAccount.Name = "btnNewAccount";
            this.btnNewAccount.Size = new System.Drawing.Size(75, 23);
            this.btnNewAccount.TabIndex = 6;
            this.btnNewAccount.Text = "New";
            this.btnNewAccount.UseVisualStyleBackColor = true;
            this.btnNewAccount.Click += new System.EventHandler(this.btnNewAccount_Click);
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(131, 70);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(147, 20);
            this.txtServer.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(131, 44);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(147, 20);
            this.txtPassword.TabIndex = 2;
            // 
            // txtAccountName
            // 
            this.txtAccountName.Location = new System.Drawing.Point(131, 18);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(147, 20);
            this.txtAccountName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account Name";
            // 
            // rbRomans
            // 
            this.rbRomans.AutoSize = true;
            this.rbRomans.Location = new System.Drawing.Point(102, 22);
            this.rbRomans.Name = "rbRomans";
            this.rbRomans.Size = new System.Drawing.Size(64, 17);
            this.rbRomans.TabIndex = 12;
            this.rbRomans.TabStop = true;
            this.rbRomans.Text = "Romans";
            this.rbRomans.UseVisualStyleBackColor = true;
            // 
            // rbGauls
            // 
            this.rbGauls.AutoSize = true;
            this.rbGauls.Location = new System.Drawing.Point(9, 22);
            this.rbGauls.Name = "rbGauls";
            this.rbGauls.Size = new System.Drawing.Size(52, 17);
            this.rbGauls.TabIndex = 13;
            this.rbGauls.TabStop = true;
            this.rbGauls.Text = "Gauls";
            this.rbGauls.UseVisualStyleBackColor = true;
            // 
            // rbTeutons
            // 
            this.rbTeutons.AutoSize = true;
            this.rbTeutons.Location = new System.Drawing.Point(199, 22);
            this.rbTeutons.Name = "rbTeutons";
            this.rbTeutons.Size = new System.Drawing.Size(64, 17);
            this.rbTeutons.TabIndex = 14;
            this.rbTeutons.TabStop = true;
            this.rbTeutons.Text = "Teutons";
            this.rbTeutons.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbRomans);
            this.groupBox2.Controls.Add(this.rbTeutons);
            this.groupBox2.Controls.Add(this.rbGauls);
            this.groupBox2.Location = new System.Drawing.Point(9, 122);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(269, 52);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tribe";
            // 
            // AccountsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lvAccounts);
            this.Name = "AccountsForm";
            this.Text = "Accounts";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvAccounts;
        private System.Windows.Forms.ColumnHeader chAccountName;
        private System.Windows.Forms.ColumnHeader chServer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDeleteAccount;
        private System.Windows.Forms.Button btnSaveAccount;
        private System.Windows.Forms.Button btnNewAccount;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSpeed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader chSpeed;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbRomans;
        private System.Windows.Forms.RadioButton rbTeutons;
        private System.Windows.Forms.RadioButton rbGauls;
    }
}