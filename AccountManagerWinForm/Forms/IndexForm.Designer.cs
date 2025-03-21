﻿namespace AccountManagerWinForm.Forms
{
    partial class IndexForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IndexForm));
            DashboardMainPnl = new System.Windows.Forms.Panel();
            ActivePnl = new System.Windows.Forms.Panel();
            Btn_ToSettings = new System.Windows.Forms.Button();
            Btn_ToResources = new System.Windows.Forms.Button();
            Btn_ToWelcome = new System.Windows.Forms.Button();
            DashboardTopPnl = new System.Windows.Forms.Panel();
            DashboardNameLabel = new System.Windows.Forms.Label();
            DashboardLogoPicture = new System.Windows.Forms.PictureBox();
            CloseBtn = new System.Windows.Forms.Button();
            HeaderPnl = new System.Windows.Forms.Panel();
            MinimizeBtn = new System.Windows.Forms.Button();
            ActiveFormNameLbl = new System.Windows.Forms.Label();
            SearchPnl = new System.Windows.Forms.Panel();
            BodyPnl = new System.Windows.Forms.Panel();
            DashboardMainPnl.SuspendLayout();
            DashboardTopPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DashboardLogoPicture).BeginInit();
            HeaderPnl.SuspendLayout();
            SuspendLayout();
            // 
            // DashboardMainPnl
            // 
            DashboardMainPnl.BackColor = System.Drawing.Color.FromArgb(24, 30, 54);
            DashboardMainPnl.Controls.Add(ActivePnl);
            DashboardMainPnl.Controls.Add(Btn_ToSettings);
            DashboardMainPnl.Controls.Add(Btn_ToResources);
            DashboardMainPnl.Controls.Add(Btn_ToWelcome);
            DashboardMainPnl.Controls.Add(DashboardTopPnl);
            DashboardMainPnl.Dock = System.Windows.Forms.DockStyle.Left;
            DashboardMainPnl.Location = new System.Drawing.Point(0, 0);
            DashboardMainPnl.Margin = new System.Windows.Forms.Padding(0);
            DashboardMainPnl.Name = "DashboardMainPnl";
            DashboardMainPnl.Size = new System.Drawing.Size(200, 600);
            DashboardMainPnl.TabIndex = 0;
            // 
            // ActivePnl
            // 
            ActivePnl.BackColor = System.Drawing.Color.FromArgb(0, 126, 249);
            ActivePnl.Location = new System.Drawing.Point(0, 110);
            ActivePnl.Name = "ActivePnl";
            ActivePnl.Size = new System.Drawing.Size(3, 60);
            ActivePnl.TabIndex = 2;
            // 
            // Btn_ToSettings
            // 
            Btn_ToSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            Btn_ToSettings.FlatAppearance.BorderSize = 0;
            Btn_ToSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Btn_ToSettings.ForeColor = System.Drawing.Color.FromArgb(0, 180, 249);
            Btn_ToSettings.Image = Properties.Resources.Settings24;
            Btn_ToSettings.Location = new System.Drawing.Point(0, 540);
            Btn_ToSettings.Name = "Btn_ToSettings";
            Btn_ToSettings.Size = new System.Drawing.Size(200, 60);
            Btn_ToSettings.TabIndex = 1;
            Btn_ToSettings.Text = "Настройки";
            Btn_ToSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            Btn_ToSettings.UseVisualStyleBackColor = true;
            Btn_ToSettings.Click += Btn_ToSettings_Click;
            // 
            // Btn_ToResources
            // 
            Btn_ToResources.Dock = System.Windows.Forms.DockStyle.Top;
            Btn_ToResources.FlatAppearance.BorderSize = 0;
            Btn_ToResources.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Btn_ToResources.ForeColor = System.Drawing.Color.FromArgb(0, 180, 249);
            Btn_ToResources.Image = Properties.Resources.Resources24;
            Btn_ToResources.Location = new System.Drawing.Point(0, 170);
            Btn_ToResources.Name = "Btn_ToResources";
            Btn_ToResources.Size = new System.Drawing.Size(200, 60);
            Btn_ToResources.TabIndex = 1;
            Btn_ToResources.Text = "Ресурсы";
            Btn_ToResources.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            Btn_ToResources.UseVisualStyleBackColor = true;
            Btn_ToResources.Click += Btn_ToResources_Click;
            // 
            // Btn_ToWelcome
            // 
            Btn_ToWelcome.Dock = System.Windows.Forms.DockStyle.Top;
            Btn_ToWelcome.FlatAppearance.BorderSize = 0;
            Btn_ToWelcome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Btn_ToWelcome.ForeColor = System.Drawing.Color.FromArgb(0, 180, 249);
            Btn_ToWelcome.Image = Properties.Resources.Home24;
            Btn_ToWelcome.Location = new System.Drawing.Point(0, 110);
            Btn_ToWelcome.Name = "Btn_ToWelcome";
            Btn_ToWelcome.Size = new System.Drawing.Size(200, 60);
            Btn_ToWelcome.TabIndex = 1;
            Btn_ToWelcome.Text = "Главная";
            Btn_ToWelcome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            Btn_ToWelcome.UseVisualStyleBackColor = true;
            Btn_ToWelcome.Click += Btn_ToWelcome_Click;
            // 
            // DashboardTopPnl
            // 
            DashboardTopPnl.Controls.Add(DashboardNameLabel);
            DashboardTopPnl.Controls.Add(DashboardLogoPicture);
            DashboardTopPnl.Dock = System.Windows.Forms.DockStyle.Top;
            DashboardTopPnl.Location = new System.Drawing.Point(0, 0);
            DashboardTopPnl.Name = "DashboardTopPnl";
            DashboardTopPnl.Size = new System.Drawing.Size(200, 110);
            DashboardTopPnl.TabIndex = 0;
            // 
            // DashboardNameLabel
            // 
            DashboardNameLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            DashboardNameLabel.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            DashboardNameLabel.ForeColor = System.Drawing.Color.FromArgb(0, 180, 249);
            DashboardNameLabel.Location = new System.Drawing.Point(0, 68);
            DashboardNameLabel.Name = "DashboardNameLabel";
            DashboardNameLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            DashboardNameLabel.Size = new System.Drawing.Size(200, 42);
            DashboardNameLabel.TabIndex = 1;
            DashboardNameLabel.Text = "AccountManager";
            DashboardNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DashboardLogoPicture
            // 
            DashboardLogoPicture.Image = Properties.Resources.Logo;
            DashboardLogoPicture.Location = new System.Drawing.Point(65, 10);
            DashboardLogoPicture.Name = "DashboardLogoPicture";
            DashboardLogoPicture.Size = new System.Drawing.Size(65, 65);
            DashboardLogoPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            DashboardLogoPicture.TabIndex = 0;
            DashboardLogoPicture.TabStop = false;
            // 
            // CloseBtn
            // 
            CloseBtn.FlatAppearance.BorderSize = 0;
            CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            CloseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            CloseBtn.Location = new System.Drawing.Point(745, 0);
            CloseBtn.Name = "CloseBtn";
            CloseBtn.Size = new System.Drawing.Size(55, 28);
            CloseBtn.TabIndex = 1;
            CloseBtn.Text = "X";
            CloseBtn.UseVisualStyleBackColor = true;
            CloseBtn.Click += CloseBtn_Click;
            // 
            // HeaderPnl
            // 
            HeaderPnl.Controls.Add(MinimizeBtn);
            HeaderPnl.Controls.Add(ActiveFormNameLbl);
            HeaderPnl.Controls.Add(CloseBtn);
            HeaderPnl.Controls.Add(SearchPnl);
            HeaderPnl.Dock = System.Windows.Forms.DockStyle.Top;
            HeaderPnl.Location = new System.Drawing.Point(200, 0);
            HeaderPnl.Name = "HeaderPnl";
            HeaderPnl.Size = new System.Drawing.Size(800, 110);
            HeaderPnl.TabIndex = 2;
            // 
            // MinimizeBtn
            // 
            MinimizeBtn.FlatAppearance.BorderSize = 0;
            MinimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            MinimizeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            MinimizeBtn.Image = Properties.Resources.Minimize16;
            MinimizeBtn.Location = new System.Drawing.Point(690, 0);
            MinimizeBtn.Name = "MinimizeBtn";
            MinimizeBtn.Size = new System.Drawing.Size(55, 28);
            MinimizeBtn.TabIndex = 4;
            MinimizeBtn.UseVisualStyleBackColor = true;
            MinimizeBtn.Click += MinimizeBtn_Click;
            // 
            // ActiveFormNameLbl
            // 
            ActiveFormNameLbl.AutoSize = true;
            ActiveFormNameLbl.Font = new System.Drawing.Font("Cascadia Code", 13.8F);
            ActiveFormNameLbl.ForeColor = System.Drawing.Color.FromArgb(158, 161, 176);
            ActiveFormNameLbl.Location = new System.Drawing.Point(15, 36);
            ActiveFormNameLbl.Name = "ActiveFormNameLbl";
            ActiveFormNameLbl.Size = new System.Drawing.Size(89, 25);
            ActiveFormNameLbl.TabIndex = 2;
            ActiveFormNameLbl.Text = "Главная";
            // 
            // SearchPnl
            // 
            SearchPnl.Location = new System.Drawing.Point(473, 10);
            SearchPnl.Name = "SearchPnl";
            SearchPnl.Size = new System.Drawing.Size(300, 75);
            SearchPnl.TabIndex = 3;
            // 
            // BodyPnl
            // 
            BodyPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            BodyPnl.Location = new System.Drawing.Point(200, 110);
            BodyPnl.Name = "BodyPnl";
            BodyPnl.Size = new System.Drawing.Size(800, 490);
            BodyPnl.TabIndex = 3;
            // 
            // IndexForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(46, 51, 73);
            ClientSize = new System.Drawing.Size(1000, 600);
            Controls.Add(BodyPnl);
            Controls.Add(HeaderPnl);
            Controls.Add(DashboardMainPnl);
            Font = new System.Drawing.Font("Cascadia Code", 12F);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4);
            Name = "IndexForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "AccountManager";
            DashboardMainPnl.ResumeLayout(false);
            DashboardTopPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DashboardLogoPicture).EndInit();
            HeaderPnl.ResumeLayout(false);
            HeaderPnl.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel DashboardMainPnl;
        private System.Windows.Forms.Panel DashboardTopPnl;
        private System.Windows.Forms.PictureBox DashboardLogoPicture;
        private System.Windows.Forms.Label DashboardNameLabel;
        private System.Windows.Forms.Button Btn_ToWelcome;
        private System.Windows.Forms.Button Btn_ToSettings;
        private System.Windows.Forms.Panel ActivePnl;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Button Btn_ToResources;
        public System.Windows.Forms.Label ActiveFormNameLbl;
        public System.Windows.Forms.Panel BodyPnl;
        private System.Windows.Forms.Panel HeaderPnl;
        public System.Windows.Forms.Panel SearchPnl;
        private System.Windows.Forms.Button MinimizeBtn;
    }
}