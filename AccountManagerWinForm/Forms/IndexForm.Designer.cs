namespace AccountManagerWinForm.Forms
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
            DashboardMainPnl = new System.Windows.Forms.Panel();
            ActivePnl = new System.Windows.Forms.Panel();
            Btn_ToSettings = new System.Windows.Forms.Button();
            Btn_ToResources = new System.Windows.Forms.Button();
            Btn_ToMain = new System.Windows.Forms.Button();
            DashboardTopPnl = new System.Windows.Forms.Panel();
            DashboardNameLabel = new System.Windows.Forms.Label();
            DashboardLogoPicture = new System.Windows.Forms.PictureBox();
            CloseBtn = new System.Windows.Forms.Button();
            DashboardMainPnl.SuspendLayout();
            DashboardTopPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DashboardLogoPicture).BeginInit();
            SuspendLayout();
            // 
            // DashboardMainPnl
            // 
            DashboardMainPnl.BackColor = System.Drawing.Color.FromArgb(24, 30, 54);
            DashboardMainPnl.Controls.Add(ActivePnl);
            DashboardMainPnl.Controls.Add(Btn_ToSettings);
            DashboardMainPnl.Controls.Add(Btn_ToResources);
            DashboardMainPnl.Controls.Add(Btn_ToMain);
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
            ActivePnl.Location = new System.Drawing.Point(0, 150);
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
            Btn_ToResources.Location = new System.Drawing.Point(0, 210);
            Btn_ToResources.Name = "Btn_ToResources";
            Btn_ToResources.Size = new System.Drawing.Size(200, 60);
            Btn_ToResources.TabIndex = 1;
            Btn_ToResources.Text = "Ресурсы";
            Btn_ToResources.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            Btn_ToResources.UseVisualStyleBackColor = true;
            Btn_ToResources.Click += Btn_ToResources_Click;
            // 
            // Btn_ToMain
            // 
            Btn_ToMain.Dock = System.Windows.Forms.DockStyle.Top;
            Btn_ToMain.FlatAppearance.BorderSize = 0;
            Btn_ToMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Btn_ToMain.ForeColor = System.Drawing.Color.FromArgb(0, 180, 249);
            Btn_ToMain.Image = Properties.Resources.Home24;
            Btn_ToMain.Location = new System.Drawing.Point(0, 150);
            Btn_ToMain.Name = "Btn_ToMain";
            Btn_ToMain.Size = new System.Drawing.Size(200, 60);
            Btn_ToMain.TabIndex = 1;
            Btn_ToMain.Text = "Главная";
            Btn_ToMain.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            Btn_ToMain.UseVisualStyleBackColor = true;
            Btn_ToMain.Click += Btn_ToMain_Click;
            // 
            // DashboardTopPnl
            // 
            DashboardTopPnl.Controls.Add(DashboardNameLabel);
            DashboardTopPnl.Controls.Add(DashboardLogoPicture);
            DashboardTopPnl.Dock = System.Windows.Forms.DockStyle.Top;
            DashboardTopPnl.Location = new System.Drawing.Point(0, 0);
            DashboardTopPnl.Name = "DashboardTopPnl";
            DashboardTopPnl.Size = new System.Drawing.Size(200, 150);
            DashboardTopPnl.TabIndex = 0;
            // 
            // DashboardNameLabel
            // 
            DashboardNameLabel.AutoSize = true;
            DashboardNameLabel.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            DashboardNameLabel.ForeColor = System.Drawing.Color.FromArgb(0, 180, 249);
            DashboardNameLabel.Location = new System.Drawing.Point(10, 100);
            DashboardNameLabel.Name = "DashboardNameLabel";
            DashboardNameLabel.Size = new System.Drawing.Size(180, 27);
            DashboardNameLabel.TabIndex = 1;
            DashboardNameLabel.Text = "AccountManager";
            // 
            // DashboardLogoPicture
            // 
            DashboardLogoPicture.Image = Properties.Resources.Logo;
            DashboardLogoPicture.Location = new System.Drawing.Point(65, 24);
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
            CloseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            CloseBtn.Location = new System.Drawing.Point(940, 0);
            CloseBtn.Name = "CloseBtn";
            CloseBtn.Size = new System.Drawing.Size(60, 30);
            CloseBtn.TabIndex = 1;
            CloseBtn.Text = "X";
            CloseBtn.UseVisualStyleBackColor = true;
            CloseBtn.Click += CloseBtn_Click;
            // 
            // IndexForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(46, 51, 73);
            ClientSize = new System.Drawing.Size(1000, 600);
            Controls.Add(CloseBtn);
            Controls.Add(DashboardMainPnl);
            Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(4);
            Name = "IndexForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Index";
            Load += Index_Load;
            DashboardMainPnl.ResumeLayout(false);
            DashboardTopPnl.ResumeLayout(false);
            DashboardTopPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DashboardLogoPicture).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel DashboardMainPnl;
        private System.Windows.Forms.Panel DashboardTopPnl;
        private System.Windows.Forms.PictureBox DashboardLogoPicture;
        private System.Windows.Forms.Label DashboardNameLabel;
        private System.Windows.Forms.Button Btn_ToMain;
        private System.Windows.Forms.Button Btn_ToSettings;
        private System.Windows.Forms.Panel ActivePnl;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Button Btn_ToResources;
    }
}