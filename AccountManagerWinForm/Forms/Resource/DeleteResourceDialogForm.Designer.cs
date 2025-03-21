﻿namespace AccountManagerWinForm.Forms.Resource
{
    partial class DeleteResourceDialogForm
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
            CloseBtn = new System.Windows.Forms.Button();
            DeleteBtn = new System.Windows.Forms.Button();
            WarningLbl = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // CloseBtn
            // 
            CloseBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(28, 29, 35);
            CloseBtn.FlatAppearance.BorderSize = 0;
            CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            CloseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            CloseBtn.ForeColor = System.Drawing.Color.White;
            CloseBtn.Location = new System.Drawing.Point(425, 0);
            CloseBtn.Margin = new System.Windows.Forms.Padding(0);
            CloseBtn.Name = "CloseBtn";
            CloseBtn.Size = new System.Drawing.Size(55, 28);
            CloseBtn.TabIndex = 3;
            CloseBtn.Text = "X";
            CloseBtn.UseVisualStyleBackColor = true;
            CloseBtn.Click += CloseBtn_Click;
            // 
            // DeleteBtn
            // 
            DeleteBtn.AutoSize = true;
            DeleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            DeleteBtn.ForeColor = System.Drawing.Color.Red;
            DeleteBtn.Image = Properties.Resources.Delete24;
            DeleteBtn.Location = new System.Drawing.Point(333, 186);
            DeleteBtn.Margin = new System.Windows.Forms.Padding(0);
            DeleteBtn.Name = "DeleteBtn";
            DeleteBtn.Size = new System.Drawing.Size(135, 42);
            DeleteBtn.TabIndex = 8;
            DeleteBtn.Text = "Удалить";
            DeleteBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            DeleteBtn.UseVisualStyleBackColor = true;
            DeleteBtn.Click += DeleteBtn_Click;
            // 
            // WarningLbl
            // 
            WarningLbl.Location = new System.Drawing.Point(12, 60);
            WarningLbl.Name = "WarningLbl";
            WarningLbl.Size = new System.Drawing.Size(456, 103);
            WarningLbl.TabIndex = 9;
            WarningLbl.Text = "Вы действительно хотите удалить ресурс? Данное действие приведет к безвозвратному удаление всех данных аккаунтов, относящихся к выбранному ресурсу";
            // 
            // DeleteResourceDialogForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(24, 30, 54);
            ClientSize = new System.Drawing.Size(480, 240);
            Controls.Add(WarningLbl);
            Controls.Add(DeleteBtn);
            Controls.Add(CloseBtn);
            Font = new System.Drawing.Font("Cascadia Code", 10.8F);
            ForeColor = System.Drawing.Color.FromArgb(158, 161, 176);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(4);
            Name = "DeleteResourceDialogForm";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "DeleteResourceDialogForm";
            TopMost = true;
            Load += DeleteResourceDialogForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Label WarningLbl;
    }
}