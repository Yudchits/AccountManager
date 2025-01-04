namespace AccountManagerWinForm.Forms.Resource
{
    partial class ResourcesForm
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
            ImagePctrBx = new System.Windows.Forms.PictureBox();
            PreviousBtn = new System.Windows.Forms.Button();
            NextBtn = new System.Windows.Forms.Button();
            NoResourcesLbl = new System.Windows.Forms.Label();
            HoverPnl = new System.Windows.Forms.Panel();
            DeleteResourceBtn = new System.Windows.Forms.Button();
            EditResourceBtn = new System.Windows.Forms.Button();
            Btn_ToAccounts = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)ImagePctrBx).BeginInit();
            HoverPnl.SuspendLayout();
            SuspendLayout();
            // 
            // ImagePctrBx
            // 
            ImagePctrBx.Location = new System.Drawing.Point(150, 47);
            ImagePctrBx.Name = "ImagePctrBx";
            ImagePctrBx.Size = new System.Drawing.Size(500, 300);
            ImagePctrBx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            ImagePctrBx.TabIndex = 2;
            ImagePctrBx.TabStop = false;
            ImagePctrBx.MouseEnter += ImagePctrBx_MouseEnter;
            // 
            // PreviousBtn
            // 
            PreviousBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            PreviousBtn.FlatAppearance.BorderSize = 0;
            PreviousBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            PreviousBtn.Image = Properties.Resources.Previous64;
            PreviousBtn.Location = new System.Drawing.Point(30, 167);
            PreviousBtn.Name = "PreviousBtn";
            PreviousBtn.Size = new System.Drawing.Size(80, 80);
            PreviousBtn.TabIndex = 3;
            PreviousBtn.UseVisualStyleBackColor = true;
            PreviousBtn.Click += PreviousBtn_Click;
            // 
            // NextBtn
            // 
            NextBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            NextBtn.FlatAppearance.BorderSize = 0;
            NextBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            NextBtn.Image = Properties.Resources.Next64;
            NextBtn.Location = new System.Drawing.Point(690, 167);
            NextBtn.Name = "NextBtn";
            NextBtn.Size = new System.Drawing.Size(80, 80);
            NextBtn.TabIndex = 3;
            NextBtn.UseVisualStyleBackColor = true;
            NextBtn.Click += NextBtn_Click;
            // 
            // NoResourcesLbl
            // 
            NoResourcesLbl.AutoSize = true;
            NoResourcesLbl.ForeColor = System.Drawing.Color.FromArgb(158, 161, 176);
            NoResourcesLbl.Location = new System.Drawing.Point(274, 194);
            NoResourcesLbl.Name = "NoResourcesLbl";
            NoResourcesLbl.Size = new System.Drawing.Size(252, 27);
            NoResourcesLbl.TabIndex = 4;
            NoResourcesLbl.Text = "Список ресурсов пуст";
            // 
            // HoverPnl
            // 
            HoverPnl.BackColor = System.Drawing.Color.FromArgb(46, 51, 73);
            HoverPnl.Controls.Add(DeleteResourceBtn);
            HoverPnl.Controls.Add(EditResourceBtn);
            HoverPnl.Cursor = System.Windows.Forms.Cursors.Hand;
            HoverPnl.Location = new System.Drawing.Point(150, 241);
            HoverPnl.Name = "HoverPnl";
            HoverPnl.Size = new System.Drawing.Size(500, 106);
            HoverPnl.TabIndex = 5;
            HoverPnl.Click += HoverPnl_Click;
            HoverPnl.MouseLeave += HoverPnl_MouseLeave;
            // 
            // DeleteResourceBtn
            // 
            DeleteResourceBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            DeleteResourceBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            DeleteResourceBtn.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            DeleteResourceBtn.ForeColor = System.Drawing.Color.Red;
            DeleteResourceBtn.Image = Properties.Resources.Delete24;
            DeleteResourceBtn.Location = new System.Drawing.Point(268, 32);
            DeleteResourceBtn.Name = "DeleteResourceBtn";
            DeleteResourceBtn.Size = new System.Drawing.Size(175, 45);
            DeleteResourceBtn.TabIndex = 0;
            DeleteResourceBtn.Text = "Удалить";
            DeleteResourceBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            DeleteResourceBtn.UseVisualStyleBackColor = true;
            // 
            // EditResourceBtn
            // 
            EditResourceBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            EditResourceBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            EditResourceBtn.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            EditResourceBtn.ForeColor = System.Drawing.Color.FromArgb(0, 180, 249);
            EditResourceBtn.Image = Properties.Resources.Edit24;
            EditResourceBtn.Location = new System.Drawing.Point(54, 32);
            EditResourceBtn.Name = "EditResourceBtn";
            EditResourceBtn.Size = new System.Drawing.Size(175, 45);
            EditResourceBtn.TabIndex = 0;
            EditResourceBtn.Text = "Редактировать";
            EditResourceBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            EditResourceBtn.UseVisualStyleBackColor = true;
            // 
            // Btn_ToAccounts
            // 
            Btn_ToAccounts.Cursor = System.Windows.Forms.Cursors.Hand;
            Btn_ToAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Btn_ToAccounts.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Btn_ToAccounts.ForeColor = System.Drawing.Color.FromArgb(0, 180, 249);
            Btn_ToAccounts.Image = Properties.Resources.Account24;
            Btn_ToAccounts.Location = new System.Drawing.Point(305, 380);
            Btn_ToAccounts.Name = "Btn_ToAccounts";
            Btn_ToAccounts.Size = new System.Drawing.Size(210, 45);
            Btn_ToAccounts.TabIndex = 0;
            Btn_ToAccounts.Text = "Данные аккаунтов";
            Btn_ToAccounts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            Btn_ToAccounts.UseVisualStyleBackColor = true;
            Btn_ToAccounts.Click += Btn_ToAccounts_Click;
            // 
            // ResourcesForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(46, 51, 73);
            ClientSize = new System.Drawing.Size(800, 490);
            Controls.Add(HoverPnl);
            Controls.Add(Btn_ToAccounts);
            Controls.Add(NoResourcesLbl);
            Controls.Add(NextBtn);
            Controls.Add(PreviousBtn);
            Controls.Add(ImagePctrBx);
            Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ForeColor = System.Drawing.Color.FromArgb(158, 161, 176);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(4);
            Name = "ResourcesForm";
            Text = "ResourcesForm";
            Load += ResourcesForm_Load;
            ((System.ComponentModel.ISupportInitialize)ImagePctrBx).EndInit();
            HoverPnl.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.PictureBox ImagePctrBx;
        private System.Windows.Forms.Button PreviousBtn;
        private System.Windows.Forms.Button NextBtn;
        private System.Windows.Forms.Label NoResourcesLbl;
        private System.Windows.Forms.TextBox SearchTxtBx;
        private System.Windows.Forms.Panel HoverPnl;
        private System.Windows.Forms.Button EditResourceBtn;
        private System.Windows.Forms.Button DeleteResourceBtn;
        private System.Windows.Forms.Button Btn_ToAccounts;
    }
}