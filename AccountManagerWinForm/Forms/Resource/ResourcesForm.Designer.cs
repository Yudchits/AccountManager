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
            DeleteResBtn = new System.Windows.Forms.Button();
            UpdateResBtn = new System.Windows.Forms.Button();
            Btn_ToAccounts = new System.Windows.Forms.Button();
            CreateResBtn = new System.Windows.Forms.Button();
            ResourcesPnl = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)ImagePctrBx).BeginInit();
            HoverPnl.SuspendLayout();
            ResourcesPnl.SuspendLayout();
            SuspendLayout();
            // 
            // ImagePctrBx
            // 
            ImagePctrBx.Location = new System.Drawing.Point(120, 0);
            ImagePctrBx.Margin = new System.Windows.Forms.Padding(0);
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
            PreviousBtn.Location = new System.Drawing.Point(0, 120);
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
            NextBtn.Location = new System.Drawing.Point(660, 120);
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
            NoResourcesLbl.Location = new System.Drawing.Point(120, 18);
            NoResourcesLbl.Name = "NoResourcesLbl";
            NoResourcesLbl.Size = new System.Drawing.Size(252, 27);
            NoResourcesLbl.TabIndex = 4;
            NoResourcesLbl.Text = "Список ресурсов пуст";
            // 
            // HoverPnl
            // 
            HoverPnl.BackColor = System.Drawing.Color.FromArgb(46, 51, 73);
            HoverPnl.Controls.Add(DeleteResBtn);
            HoverPnl.Controls.Add(UpdateResBtn);
            HoverPnl.Cursor = System.Windows.Forms.Cursors.Hand;
            HoverPnl.Location = new System.Drawing.Point(150, 252);
            HoverPnl.Name = "HoverPnl";
            HoverPnl.Size = new System.Drawing.Size(500, 106);
            HoverPnl.TabIndex = 5;
            HoverPnl.Click += HoverPnl_Click;
            HoverPnl.MouseLeave += HoverPnl_MouseLeave;
            // 
            // DeleteResBtn
            // 
            DeleteResBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            DeleteResBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            DeleteResBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            DeleteResBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            DeleteResBtn.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            DeleteResBtn.ForeColor = System.Drawing.Color.Red;
            DeleteResBtn.Image = Properties.Resources.Delete24;
            DeleteResBtn.Location = new System.Drawing.Point(268, 32);
            DeleteResBtn.Name = "DeleteResBtn";
            DeleteResBtn.Size = new System.Drawing.Size(175, 45);
            DeleteResBtn.TabIndex = 0;
            DeleteResBtn.Text = "Удалить";
            DeleteResBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            DeleteResBtn.UseVisualStyleBackColor = true;
            // 
            // UpdateResBtn
            // 
            UpdateResBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            UpdateResBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            UpdateResBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            UpdateResBtn.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            UpdateResBtn.ForeColor = System.Drawing.Color.FromArgb(0, 180, 249);
            UpdateResBtn.Image = Properties.Resources.Edit24;
            UpdateResBtn.Location = new System.Drawing.Point(54, 32);
            UpdateResBtn.Name = "UpdateResBtn";
            UpdateResBtn.Size = new System.Drawing.Size(175, 45);
            UpdateResBtn.TabIndex = 0;
            UpdateResBtn.Text = "Редактировать";
            UpdateResBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            UpdateResBtn.UseVisualStyleBackColor = true;
            UpdateResBtn.Click += UpdateResBtn_Click;
            // 
            // Btn_ToAccounts
            // 
            Btn_ToAccounts.Cursor = System.Windows.Forms.Cursors.Hand;
            Btn_ToAccounts.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            Btn_ToAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Btn_ToAccounts.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Btn_ToAccounts.ForeColor = System.Drawing.Color.FromArgb(0, 180, 249);
            Btn_ToAccounts.Image = Properties.Resources.Account24;
            Btn_ToAccounts.Location = new System.Drawing.Point(275, 333);
            Btn_ToAccounts.Name = "Btn_ToAccounts";
            Btn_ToAccounts.Size = new System.Drawing.Size(210, 45);
            Btn_ToAccounts.TabIndex = 0;
            Btn_ToAccounts.Text = "Данные аккаунтов";
            Btn_ToAccounts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            Btn_ToAccounts.UseVisualStyleBackColor = true;
            Btn_ToAccounts.Click += Btn_ToAccounts_Click;
            // 
            // CreateResBtn
            // 
            CreateResBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            CreateResBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            CreateResBtn.Image = Properties.Resources.Add16;
            CreateResBtn.Location = new System.Drawing.Point(150, 0);
            CreateResBtn.Name = "CreateResBtn";
            CreateResBtn.Size = new System.Drawing.Size(150, 40);
            CreateResBtn.TabIndex = 6;
            CreateResBtn.Text = "Добавить";
            CreateResBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            CreateResBtn.UseVisualStyleBackColor = true;
            CreateResBtn.Click += CreateResBtn_Click;
            // 
            // ResourcesPnl
            // 
            ResourcesPnl.Controls.Add(NoResourcesLbl);
            ResourcesPnl.Controls.Add(ImagePctrBx);
            ResourcesPnl.Controls.Add(PreviousBtn);
            ResourcesPnl.Controls.Add(Btn_ToAccounts);
            ResourcesPnl.Controls.Add(NextBtn);
            ResourcesPnl.Location = new System.Drawing.Point(30, 58);
            ResourcesPnl.Name = "ResourcesPnl";
            ResourcesPnl.Size = new System.Drawing.Size(740, 393);
            ResourcesPnl.TabIndex = 7;
            // 
            // ResourcesForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(46, 51, 73);
            ClientSize = new System.Drawing.Size(800, 490);
            Controls.Add(CreateResBtn);
            Controls.Add(HoverPnl);
            Controls.Add(ResourcesPnl);
            Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ForeColor = System.Drawing.Color.FromArgb(158, 161, 176);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(4);
            Name = "ResourcesForm";
            Text = "ResourcesForm";
            Load += ResourcesForm_Load;
            ((System.ComponentModel.ISupportInitialize)ImagePctrBx).EndInit();
            HoverPnl.ResumeLayout(false);
            ResourcesPnl.ResumeLayout(false);
            ResourcesPnl.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.PictureBox ImagePctrBx;
        private System.Windows.Forms.Button PreviousBtn;
        private System.Windows.Forms.Button NextBtn;
        private System.Windows.Forms.Label NoResourcesLbl;
        private System.Windows.Forms.TextBox SearchTxtBx;
        private System.Windows.Forms.Panel HoverPnl;
        private System.Windows.Forms.Button UpdateResBtn;
        private System.Windows.Forms.Button DeleteResBtn;
        private System.Windows.Forms.Button Btn_ToAccounts;
        private System.Windows.Forms.Button CreateResBtn;
        private System.Windows.Forms.Panel ResourcesPnl;
    }
}