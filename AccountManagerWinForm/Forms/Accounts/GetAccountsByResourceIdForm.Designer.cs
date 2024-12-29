namespace AccountManagerWinForm.Forms.Accounts
{
    partial class GetAccountsByResourceIdForm
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
            MainPanel = new System.Windows.Forms.Panel();
            AccountsFLP = new System.Windows.Forms.FlowLayoutPanel();
            HeaderLabel = new System.Windows.Forms.Label();
            CloseBtn = new System.Windows.Forms.Button();
            MainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // MainPanel
            // 
            MainPanel.BackColor = System.Drawing.Color.FromArgb(28, 29, 35);
            MainPanel.Controls.Add(AccountsFLP);
            MainPanel.Controls.Add(HeaderLabel);
            MainPanel.Controls.Add(CloseBtn);
            MainPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            MainPanel.Location = new System.Drawing.Point(0, 0);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new System.Drawing.Size(1000, 800);
            MainPanel.TabIndex = 0;
            // 
            // AccountsFLP
            // 
            AccountsFLP.AutoScroll = true;
            AccountsFLP.ForeColor = System.Drawing.Color.White;
            AccountsFLP.Location = new System.Drawing.Point(100, 125);
            AccountsFLP.Name = "AccountsFLP";
            AccountsFLP.Size = new System.Drawing.Size(800, 575);
            AccountsFLP.TabIndex = 3;
            // 
            // HeaderLabel
            // 
            HeaderLabel.AutoSize = true;
            HeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            HeaderLabel.ForeColor = System.Drawing.Color.White;
            HeaderLabel.Location = new System.Drawing.Point(437, 54);
            HeaderLabel.Name = "HeaderLabel";
            HeaderLabel.Size = new System.Drawing.Size(125, 29);
            HeaderLabel.TabIndex = 2;
            HeaderLabel.Text = "Аккаунты";
            // 
            // CloseBtn
            // 
            CloseBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(28, 29, 35);
            CloseBtn.FlatAppearance.BorderSize = 0;
            CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            CloseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            CloseBtn.ForeColor = System.Drawing.Color.White;
            CloseBtn.Location = new System.Drawing.Point(940, 0);
            CloseBtn.Name = "CloseBtn";
            CloseBtn.Size = new System.Drawing.Size(60, 30);
            CloseBtn.TabIndex = 1;
            CloseBtn.Text = "X";
            CloseBtn.UseVisualStyleBackColor = true;
            CloseBtn.Click += CloseBtn_Click;
            // 
            // GetAccountsByResourceIdForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1000, 800);
            Controls.Add(MainPanel);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "GetAccountsByResourceIdForm";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "GetAccountsByResourceIdForm";
            MainPanel.ResumeLayout(false);
            MainPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Label HeaderLabel;
        private System.Windows.Forms.FlowLayoutPanel AccountsFLP;
    }
}