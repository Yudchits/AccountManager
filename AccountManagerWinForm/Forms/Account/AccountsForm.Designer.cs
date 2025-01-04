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
            AccountsFLPnl = new System.Windows.Forms.FlowLayoutPanel();
            ScrollPnl = new System.Windows.Forms.Panel();
            SuspendLayout();
            // 
            // AccountsFLPnl
            // 
            AccountsFLPnl.Location = new System.Drawing.Point(35, 15);
            AccountsFLPnl.Name = "AccountsFLPnl";
            AccountsFLPnl.Size = new System.Drawing.Size(730, 450);
            AccountsFLPnl.TabIndex = 1;
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
            // AccountsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(46, 51, 73);
            ClientSize = new System.Drawing.Size(800, 490);
            Controls.Add(ScrollPnl);
            Controls.Add(AccountsFLPnl);
            Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ForeColor = System.Drawing.Color.FromArgb(158, 161, 176);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(4);
            Name = "AccountsForm";
            Text = "AccountsForm";
            Load += AccountsForm_Load;
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel AccountsFLPnl;
        private System.Windows.Forms.Label Scroller;
        private System.Windows.Forms.Label PnlTop;
        private System.Windows.Forms.Panel ScrollPnl;
    }
}