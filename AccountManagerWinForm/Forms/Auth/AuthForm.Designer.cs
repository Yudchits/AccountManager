using AccountManagerWinForm.Forms.Common.Elements.Mat;

namespace AccountManagerWinForm.Forms.Auth
{
    partial class AuthForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthForm));
            CloseBtn = new System.Windows.Forms.Button();
            AuthPnl = new System.Windows.Forms.Panel();
            AuthHavingPnl = new System.Windows.Forms.Panel();
            AuthHavingLinkLbl = new System.Windows.Forms.Label();
            AuthHavingLbl = new System.Windows.Forms.Label();
            AuthBtn = new System.Windows.Forms.Button();
            AuthHeaderLbl = new System.Windows.Forms.Label();
            AuthPnl.SuspendLayout();
            AuthHavingPnl.SuspendLayout();
            SuspendLayout();
            // 
            // CloseBtn
            // 
            CloseBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(28, 29, 35);
            CloseBtn.FlatAppearance.BorderSize = 0;
            CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            CloseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            CloseBtn.ForeColor = System.Drawing.Color.White;
            CloseBtn.Location = new System.Drawing.Point(365, 0);
            CloseBtn.Margin = new System.Windows.Forms.Padding(0);
            CloseBtn.Name = "CloseBtn";
            CloseBtn.Size = new System.Drawing.Size(55, 28);
            CloseBtn.TabIndex = 3;
            CloseBtn.Text = "X";
            CloseBtn.UseVisualStyleBackColor = true;
            CloseBtn.Click += CloseBtn_Click;
            // 
            // AuthPnl
            // 
            AuthPnl.BackColor = System.Drawing.Color.FromArgb(46, 51, 73);
            AuthPnl.Controls.Add(CloseBtn);
            AuthPnl.Controls.Add(AuthHavingPnl);
            AuthPnl.Controls.Add(AuthBtn);
            AuthPnl.Controls.Add(AuthHeaderLbl);
            AuthPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            AuthPnl.Location = new System.Drawing.Point(0, 0);
            AuthPnl.Name = "AuthPnl";
            AuthPnl.Size = new System.Drawing.Size(420, 510);
            AuthPnl.TabIndex = 4;
            AuthPnl.Click += LoginPnl_Click;
            // 
            // AuthHavingPnl
            // 
            AuthHavingPnl.Controls.Add(AuthHavingLinkLbl);
            AuthHavingPnl.Controls.Add(AuthHavingLbl);
            AuthHavingPnl.Font = new System.Drawing.Font("Cascadia Code", 7.8F);
            AuthHavingPnl.Location = new System.Drawing.Point(85, 377);
            AuthHavingPnl.Name = "AuthHavingPnl";
            AuthHavingPnl.Size = new System.Drawing.Size(250, 37);
            AuthHavingPnl.TabIndex = 4;
            // 
            // AuthHavingLinkLbl
            // 
            AuthHavingLinkLbl.AutoSize = true;
            AuthHavingLinkLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            AuthHavingLinkLbl.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 204);
            AuthHavingLinkLbl.Location = new System.Drawing.Point(132, 8);
            AuthHavingLinkLbl.Name = "AuthHavingLinkLbl";
            AuthHavingLinkLbl.Size = new System.Drawing.Size(84, 16);
            AuthHavingLinkLbl.TabIndex = 1;
            AuthHavingLinkLbl.Text = "Регистрация";
            AuthHavingLinkLbl.Click += AuthHavingLinkLbl_Click;
            // 
            // AuthHavingLbl
            // 
            AuthHavingLbl.AutoSize = true;
            AuthHavingLbl.Font = new System.Drawing.Font("Cascadia Code", 9F);
            AuthHavingLbl.Location = new System.Drawing.Point(12, 8);
            AuthHavingLbl.Name = "AuthHavingLbl";
            AuthHavingLbl.Size = new System.Drawing.Size(98, 16);
            AuthHavingLbl.TabIndex = 0;
            AuthHavingLbl.Text = "Нет аккаунта?";
            // 
            // AuthBtn
            // 
            AuthBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            AuthBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            AuthBtn.ForeColor = System.Drawing.Color.FromArgb(0, 180, 249);
            AuthBtn.Location = new System.Drawing.Point(145, 332);
            AuthBtn.Name = "AuthBtn";
            AuthBtn.Size = new System.Drawing.Size(130, 42);
            AuthBtn.TabIndex = 3;
            AuthBtn.Text = "Войти";
            AuthBtn.UseVisualStyleBackColor = true;
            AuthBtn.Click += AuthBtn_ClickAsync;
            // 
            // AuthHeaderLbl
            // 
            AuthHeaderLbl.AutoSize = true;
            AuthHeaderLbl.Font = new System.Drawing.Font("Cascadia Code", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            AuthHeaderLbl.ForeColor = System.Drawing.Color.FromArgb(0, 180, 249);
            AuthHeaderLbl.Location = new System.Drawing.Point(177, 79);
            AuthHeaderLbl.Name = "AuthHeaderLbl";
            AuthHeaderLbl.Size = new System.Drawing.Size(56, 25);
            AuthHeaderLbl.TabIndex = 2;
            AuthHeaderLbl.Text = "Вход";
            // 
            // AuthForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(24, 30, 54);
            ClientSize = new System.Drawing.Size(420, 510);
            Controls.Add(AuthPnl);
            Font = new System.Drawing.Font("Cascadia Code", 12F);
            ForeColor = System.Drawing.Color.FromArgb(158, 161, 176);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4);
            Name = "AuthForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "AccountManager";
            Load += AuthForm_Load;
            AuthPnl.ResumeLayout(false);
            AuthPnl.PerformLayout();
            AuthHavingPnl.ResumeLayout(false);
            AuthHavingPnl.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Panel AuthPnl;
        private System.Windows.Forms.Button AuthBtn;
        private System.Windows.Forms.Label AuthHeaderLbl;
        private System.Windows.Forms.Panel AuthHavingPnl;
        private System.Windows.Forms.Label AuthHavingLinkLbl;
        private System.Windows.Forms.Label AuthHavingLbl;
    }
}