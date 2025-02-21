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
            PasswordTxtBx = new Common.Elements.MatTextBox();
            LoginTxtBx = new Common.Elements.MatTextBox();
            AuthPnl.SuspendLayout();
            AuthHavingPnl.SuspendLayout();
            SuspendLayout();
            // 
            // CloseBtn
            // 
            CloseBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(28, 29, 35);
            CloseBtn.FlatAppearance.BorderSize = 0;
            CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            CloseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            CloseBtn.ForeColor = System.Drawing.Color.White;
            CloseBtn.Location = new System.Drawing.Point(314, 0);
            CloseBtn.Margin = new System.Windows.Forms.Padding(0);
            CloseBtn.Name = "CloseBtn";
            CloseBtn.Size = new System.Drawing.Size(66, 36);
            CloseBtn.TabIndex = 3;
            CloseBtn.Text = "X";
            CloseBtn.UseVisualStyleBackColor = true;
            CloseBtn.Click += CloseBtn_Click;
            // 
            // AuthPnl
            // 
            AuthPnl.Controls.Add(AuthHavingPnl);
            AuthPnl.Controls.Add(AuthBtn);
            AuthPnl.Controls.Add(AuthHeaderLbl);
            AuthPnl.Controls.Add(PasswordTxtBx);
            AuthPnl.Controls.Add(LoginTxtBx);
            AuthPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            AuthPnl.Location = new System.Drawing.Point(0, 0);
            AuthPnl.Name = "AuthPnl";
            AuthPnl.Size = new System.Drawing.Size(380, 450);
            AuthPnl.TabIndex = 4;
            AuthPnl.Click += LoginPnl_Click;
            // 
            // AuthHavingPnl
            // 
            AuthHavingPnl.Controls.Add(AuthHavingLinkLbl);
            AuthHavingPnl.Controls.Add(AuthHavingLbl);
            AuthHavingPnl.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            AuthHavingPnl.Location = new System.Drawing.Point(65, 340);
            AuthHavingPnl.Name = "AuthHavingPnl";
            AuthHavingPnl.Size = new System.Drawing.Size(250, 37);
            AuthHavingPnl.TabIndex = 4;
            // 
            // AuthHavingLinkLbl
            // 
            AuthHavingLinkLbl.AutoSize = true;
            AuthHavingLinkLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            AuthHavingLinkLbl.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            AuthHavingLinkLbl.Location = new System.Drawing.Point(132, 8);
            AuthHavingLinkLbl.Name = "AuthHavingLinkLbl";
            AuthHavingLinkLbl.Size = new System.Drawing.Size(108, 20);
            AuthHavingLinkLbl.TabIndex = 1;
            AuthHavingLinkLbl.Text = "Регистрация";
            AuthHavingLinkLbl.Click += AuthHavingLinkLbl_Click;
            // 
            // AuthHavingLbl
            // 
            AuthHavingLbl.AutoSize = true;
            AuthHavingLbl.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            AuthHavingLbl.Location = new System.Drawing.Point(12, 8);
            AuthHavingLbl.Name = "AuthHavingLbl";
            AuthHavingLbl.Size = new System.Drawing.Size(126, 20);
            AuthHavingLbl.TabIndex = 0;
            AuthHavingLbl.Text = "Нет аккаунта?";
            // 
            // AuthBtn
            // 
            AuthBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            AuthBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            AuthBtn.ForeColor = System.Drawing.Color.FromArgb(0, 180, 249);
            AuthBtn.Location = new System.Drawing.Point(125, 295);
            AuthBtn.Name = "AuthBtn";
            AuthBtn.Size = new System.Drawing.Size(130, 42);
            AuthBtn.TabIndex = 3;
            AuthBtn.Text = "Войти";
            AuthBtn.UseVisualStyleBackColor = true;
            AuthBtn.Click += AuthBtn_ClickAsync;
            // 
            // AuthLbl
            // 
            AuthHeaderLbl.AutoSize = true;
            AuthHeaderLbl.Font = new System.Drawing.Font("Cascadia Code SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            AuthHeaderLbl.ForeColor = System.Drawing.Color.FromArgb(0, 180, 249);
            AuthHeaderLbl.Location = new System.Drawing.Point(157, 55);
            AuthHeaderLbl.Name = "AuthLbl";
            AuthHeaderLbl.Size = new System.Drawing.Size(65, 30);
            AuthHeaderLbl.TabIndex = 2;
            AuthHeaderLbl.Text = "Вход";
            // 
            // PasswordTxtBx
            // 
            PasswordTxtBx.ActiveColor = System.Drawing.Color.FromArgb(0, 180, 249);
            PasswordTxtBx.Label = "Пароль";
            PasswordTxtBx.Location = new System.Drawing.Point(65, 190);
            PasswordTxtBx.Name = "PasswordTxtBx";
            PasswordTxtBx.PasswordChar = '\0';
            PasswordTxtBx.Size = new System.Drawing.Size(250, 57);
            PasswordTxtBx.TabIndex = 1;
            // 
            // LoginTxtBx
            // 
            LoginTxtBx.ActiveColor = System.Drawing.Color.FromArgb(0, 180, 249);
            LoginTxtBx.Label = "Логин";
            LoginTxtBx.Location = new System.Drawing.Point(65, 110);
            LoginTxtBx.Name = "LoginTxtBx";
            LoginTxtBx.PasswordChar = '\0';
            LoginTxtBx.Size = new System.Drawing.Size(250, 57);
            LoginTxtBx.TabIndex = 0;
            // 
            // AuthForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(24, 30, 54);
            ClientSize = new System.Drawing.Size(380, 450);
            Controls.Add(CloseBtn);
            Controls.Add(AuthPnl);
            Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ForeColor = System.Drawing.Color.FromArgb(158, 161, 176);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4);
            Name = "AuthForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "AuthForm";
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
        private Common.Elements.MatTextBox PasswordTxtBx;
        private Common.Elements.MatTextBox LoginTxtBx;
        private System.Windows.Forms.Panel AuthHavingPnl;
        private System.Windows.Forms.Label AuthHavingLinkLbl;
        private System.Windows.Forms.Label AuthHavingLbl;
    }
}