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
            // AccountsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(46, 51, 73);
            ClientSize = new System.Drawing.Size(800, 490);
            Controls.Add(CreateAccBtn);
            Controls.Add(ScrollPnl);
            Controls.Add(AccsFLPnl);
            Font = new System.Drawing.Font("Cascadia Code", 12F);
            ForeColor = System.Drawing.Color.FromArgb(158, 161, 176);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(4);
            Name = "AccountsForm";
            Text = "AccountsForm";
            Load += AccountsForm_Load;
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel AccsFLPnl;
        private System.Windows.Forms.Label Scroller;
        private System.Windows.Forms.Label PnlTop;
        private System.Windows.Forms.Panel ScrollPnl;
        private System.Windows.Forms.Button CreateAccBtn;
    }
}