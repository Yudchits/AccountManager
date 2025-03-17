namespace AccountManagerWinForm.Forms.Account
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
            AccsFLPnl = new System.Windows.Forms.FlowLayoutPanel();
            ScrollPnl = new System.Windows.Forms.Panel();
            CreateAccBtn = new System.Windows.Forms.Button();
            PaginationPnl = new System.Windows.Forms.Panel();
            PageNumberLbl = new System.Windows.Forms.Label();
            NextPageBtn = new System.Windows.Forms.Button();
            PreviousPageBtn = new System.Windows.Forms.Button();
            PaginationPnl.SuspendLayout();
            SuspendLayout();
            // 
            // AccsFLPnl
            // 
            AccsFLPnl.Location = new System.Drawing.Point(15, 60);
            AccsFLPnl.Name = "AccsFLPnl";
            AccsFLPnl.Size = new System.Drawing.Size(760, 430);
            AccsFLPnl.TabIndex = 1;
            // 
            // ScrollPnl
            // 
            ScrollPnl.BackColor = System.Drawing.Color.FromArgb(0, 180, 249);
            ScrollPnl.Cursor = System.Windows.Forms.Cursors.Hand;
            ScrollPnl.Location = new System.Drawing.Point(793, 0);
            ScrollPnl.Name = "ScrollPnl";
            ScrollPnl.Size = new System.Drawing.Size(7, 125);
            ScrollPnl.TabIndex = 2;
            ScrollPnl.Visible = false;
            ScrollPnl.MouseDown += ScrollPnl_MouseDown;
            ScrollPnl.MouseMove += ScrollPnl_MouseMove;
            ScrollPnl.MouseUp += ScrollPnl_MouseUp;
            // 
            // CreateAccBtn
            // 
            CreateAccBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            CreateAccBtn.Image = Properties.Resources.Add16;
            CreateAccBtn.Location = new System.Drawing.Point(15, 0);
            CreateAccBtn.Name = "CreateAccBtn";
            CreateAccBtn.Size = new System.Drawing.Size(150, 40);
            CreateAccBtn.TabIndex = 3;
            CreateAccBtn.Text = "Добавить";
            CreateAccBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            CreateAccBtn.UseVisualStyleBackColor = true;
            CreateAccBtn.Click += CreateAccBtn_Click;
            // 
            // PaginationPnl
            // 
            PaginationPnl.Controls.Add(PageNumberLbl);
            PaginationPnl.Controls.Add(NextPageBtn);
            PaginationPnl.Controls.Add(PreviousPageBtn);
            PaginationPnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            PaginationPnl.Location = new System.Drawing.Point(0, 430);
            PaginationPnl.Margin = new System.Windows.Forms.Padding(0);
            PaginationPnl.Name = "PaginationPnl";
            PaginationPnl.Size = new System.Drawing.Size(800, 60);
            PaginationPnl.TabIndex = 4;
            PaginationPnl.Visible = false;
            // 
            // PageNumberLbl
            // 
            PageNumberLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            PageNumberLbl.Location = new System.Drawing.Point(136, 0);
            PageNumberLbl.Name = "PageNumberLbl";
            PageNumberLbl.Size = new System.Drawing.Size(528, 60);
            PageNumberLbl.TabIndex = 2;
            PageNumberLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NextPageBtn
            // 
            NextPageBtn.AutoSize = true;
            NextPageBtn.Dock = System.Windows.Forms.DockStyle.Right;
            NextPageBtn.FlatAppearance.BorderSize = 0;
            NextPageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            NextPageBtn.ForeColor = System.Drawing.Color.FromArgb(0, 180, 249);
            NextPageBtn.Image = Properties.Resources.Next24;
            NextPageBtn.Location = new System.Drawing.Point(664, 0);
            NextPageBtn.Name = "NextPageBtn";
            NextPageBtn.Size = new System.Drawing.Size(136, 60);
            NextPageBtn.TabIndex = 1;
            NextPageBtn.Text = "Следующая";
            NextPageBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            NextPageBtn.UseVisualStyleBackColor = true;
            NextPageBtn.Click += NextPageBtn_Click;
            // 
            // PreviousPageBtn
            // 
            PreviousPageBtn.AutoSize = true;
            PreviousPageBtn.Dock = System.Windows.Forms.DockStyle.Left;
            PreviousPageBtn.FlatAppearance.BorderSize = 0;
            PreviousPageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            PreviousPageBtn.ForeColor = System.Drawing.Color.FromArgb(0, 180, 249);
            PreviousPageBtn.Image = Properties.Resources.Previous24;
            PreviousPageBtn.Location = new System.Drawing.Point(0, 0);
            PreviousPageBtn.Name = "PreviousPageBtn";
            PreviousPageBtn.Size = new System.Drawing.Size(136, 60);
            PreviousPageBtn.TabIndex = 0;
            PreviousPageBtn.Text = "Предыдущая";
            PreviousPageBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            PreviousPageBtn.UseVisualStyleBackColor = true;
            PreviousPageBtn.Click += PreviousPageBtn_Click;
            // 
            // AccountsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(46, 51, 73);
            ClientSize = new System.Drawing.Size(800, 490);
            Controls.Add(ScrollPnl);
            Controls.Add(PaginationPnl);
            Controls.Add(CreateAccBtn);
            Controls.Add(AccsFLPnl);
            Font = new System.Drawing.Font("Cascadia Code", 12F);
            ForeColor = System.Drawing.Color.FromArgb(158, 161, 176);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(4);
            Name = "AccountsForm";
            Text = "AccountsForm";
            Load += AccountsForm_Load;
            PaginationPnl.ResumeLayout(false);
            PaginationPnl.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel AccsFLPnl;
        private System.Windows.Forms.Label Scroller;
        private System.Windows.Forms.Label PnlTop;
        private System.Windows.Forms.Panel ScrollPnl;
        private System.Windows.Forms.Button CreateAccBtn;
        private System.Windows.Forms.Panel PaginationPnl;
        private System.Windows.Forms.Button PreviousPageBtn;
        private System.Windows.Forms.Button NextPageBtn;
        private System.Windows.Forms.Label PageNumberLbl;
    }
}