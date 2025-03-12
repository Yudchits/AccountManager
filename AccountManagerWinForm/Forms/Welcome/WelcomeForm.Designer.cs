namespace AccountManagerWinForm.Forms.Welcome
{
    partial class WelcomeForm
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
            HeaderWelcomeLbl = new System.Windows.Forms.Label();
            HeaderPnl = new System.Windows.Forms.Panel();
            HeaderUserLoginLbl = new System.Windows.Forms.Label();
            CreateResBtn = new System.Windows.Forms.Button();
            NoResPnl = new System.Windows.Forms.Panel();
            UserAccountBookmarksPnl = new System.Windows.Forms.Panel();
            AppDescLbl3 = new System.Windows.Forms.Label();
            AppDescLbl2 = new System.Windows.Forms.Label();
            AppDescLbl1 = new System.Windows.Forms.Label();
            HeaderPnl.SuspendLayout();
            NoResPnl.SuspendLayout();
            SuspendLayout();
            // 
            // HeaderWelcomeLbl
            // 
            HeaderWelcomeLbl.Font = new System.Drawing.Font("Cascadia Code", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            HeaderWelcomeLbl.ForeColor = System.Drawing.Color.FromArgb(158, 161, 176);
            HeaderWelcomeLbl.Location = new System.Drawing.Point(230, 16);
            HeaderWelcomeLbl.Name = "HeaderWelcomeLbl";
            HeaderWelcomeLbl.Size = new System.Drawing.Size(234, 30);
            HeaderWelcomeLbl.TabIndex = 0;
            HeaderWelcomeLbl.Text = "Добро пожаловать,";
            // 
            // HeaderPnl
            // 
            HeaderPnl.Controls.Add(HeaderUserLoginLbl);
            HeaderPnl.Controls.Add(HeaderWelcomeLbl);
            HeaderPnl.Dock = System.Windows.Forms.DockStyle.Top;
            HeaderPnl.Location = new System.Drawing.Point(0, 0);
            HeaderPnl.Name = "HeaderPnl";
            HeaderPnl.Size = new System.Drawing.Size(800, 61);
            HeaderPnl.TabIndex = 1;
            // 
            // HeaderUserLoginLbl
            // 
            HeaderUserLoginLbl.AutoSize = true;
            HeaderUserLoginLbl.Font = new System.Drawing.Font("Cascadia Code", 13.8F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 204);
            HeaderUserLoginLbl.ForeColor = System.Drawing.Color.FromArgb(0, 180, 249);
            HeaderUserLoginLbl.Location = new System.Drawing.Point(451, 16);
            HeaderUserLoginLbl.Margin = new System.Windows.Forms.Padding(0);
            HeaderUserLoginLbl.Name = "HeaderUserLoginLbl";
            HeaderUserLoginLbl.Size = new System.Drawing.Size(0, 30);
            HeaderUserLoginLbl.TabIndex = 1;
            // 
            // CreateResBtn
            // 
            CreateResBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            CreateResBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            CreateResBtn.ForeColor = System.Drawing.Color.FromArgb(0, 180, 249);
            CreateResBtn.Image = Properties.Resources.Resources24;
            CreateResBtn.Location = new System.Drawing.Point(290, 270);
            CreateResBtn.Name = "CreateResBtn";
            CreateResBtn.Size = new System.Drawing.Size(220, 47);
            CreateResBtn.TabIndex = 4;
            CreateResBtn.Text = "Создать ресурс";
            CreateResBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            CreateResBtn.UseVisualStyleBackColor = true;
            CreateResBtn.Click += CreateResBtn_Click;
            // 
            // NoResPnl
            // 
            NoResPnl.Controls.Add(UserAccountBookmarksPnl);
            NoResPnl.Controls.Add(AppDescLbl3);
            NoResPnl.Controls.Add(AppDescLbl2);
            NoResPnl.Controls.Add(AppDescLbl1);
            NoResPnl.Controls.Add(CreateResBtn);
            NoResPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            NoResPnl.Location = new System.Drawing.Point(0, 61);
            NoResPnl.Name = "NoResPnl";
            NoResPnl.Size = new System.Drawing.Size(800, 429);
            NoResPnl.TabIndex = 5;
            // 
            // UserAccountBookmarksPnl
            // 
            UserAccountBookmarksPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            UserAccountBookmarksPnl.Location = new System.Drawing.Point(0, 0);
            UserAccountBookmarksPnl.Name = "UserAccountBookmarksPnl";
            UserAccountBookmarksPnl.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            UserAccountBookmarksPnl.Size = new System.Drawing.Size(800, 429);
            UserAccountBookmarksPnl.TabIndex = 8;
            // 
            // AppDescLbl3
            // 
            AppDescLbl3.Location = new System.Drawing.Point(100, 170);
            AppDescLbl3.Name = "AppDescLbl3";
            AppDescLbl3.Size = new System.Drawing.Size(600, 60);
            AppDescLbl3.TabIndex = 7;
            AppDescLbl3.Text = "Поэтому для сохранения данных аккаунтов в первую очередь необходимо создать ресурс";
            // 
            // AppDescLbl2
            // 
            AppDescLbl2.Location = new System.Drawing.Point(100, 100);
            AppDescLbl2.Name = "AppDescLbl2";
            AppDescLbl2.Size = new System.Drawing.Size(600, 60);
            AppDescLbl2.TabIndex = 6;
            AppDescLbl2.Text = "Для более удобного поиска данные об аккаунтах относятся к определенному ресурсу";
            // 
            // AppDescLbl1
            // 
            AppDescLbl1.Location = new System.Drawing.Point(100, 30);
            AppDescLbl1.Name = "AppDescLbl1";
            AppDescLbl1.Size = new System.Drawing.Size(600, 60);
            AppDescLbl1.TabIndex = 5;
            AppDescLbl1.Text = "Приложение создано для хранение данных аккаунтов в зашифрованном виде";
            // 
            // WelcomeForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(46, 51, 73);
            ClientSize = new System.Drawing.Size(800, 490);
            Controls.Add(NoResPnl);
            Controls.Add(HeaderPnl);
            Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            ForeColor = System.Drawing.Color.FromArgb(158, 161, 176);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(4);
            Name = "WelcomeForm";
            Text = "MainForm";
            HeaderPnl.ResumeLayout(false);
            HeaderPnl.PerformLayout();
            NoResPnl.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label HeaderWelcomeLbl;
        private System.Windows.Forms.Panel HeaderPnl;
        private System.Windows.Forms.Label HeaderUserLoginLbl;
        private System.Windows.Forms.Button CreateResBtn;
        private System.Windows.Forms.Panel NoResPnl;
        private System.Windows.Forms.Label AppDescLbl2;
        private System.Windows.Forms.Label AppDescLbl1;
        private System.Windows.Forms.Label AppDescLbl3;
        private System.Windows.Forms.Panel UserAccountBookmarksPnl;
    }
}