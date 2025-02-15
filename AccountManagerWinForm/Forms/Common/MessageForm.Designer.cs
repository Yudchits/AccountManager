namespace AccountManagerWinForm.Forms.Common
{
    partial class MessageForm
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
            OkBtn = new System.Windows.Forms.Button();
            TypePctrBx = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)TypePctrBx).BeginInit();
            SuspendLayout();
            // 
            // CloseBtn
            // 
            CloseBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(28, 29, 35);
            CloseBtn.FlatAppearance.BorderSize = 0;
            CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            CloseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            CloseBtn.ForeColor = System.Drawing.Color.White;
            CloseBtn.Location = new System.Drawing.Point(374, 0);
            CloseBtn.Margin = new System.Windows.Forms.Padding(0);
            CloseBtn.Name = "CloseBtn";
            CloseBtn.Size = new System.Drawing.Size(66, 36);
            CloseBtn.TabIndex = 2;
            CloseBtn.Text = "X";
            CloseBtn.UseVisualStyleBackColor = true;
            CloseBtn.Click += CloseBtn_Click;
            // 
            // OkBtn
            // 
            OkBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            OkBtn.ForeColor = System.Drawing.Color.White;
            OkBtn.Location = new System.Drawing.Point(365, 200);
            OkBtn.Margin = new System.Windows.Forms.Padding(0);
            OkBtn.Name = "OkBtn";
            OkBtn.Size = new System.Drawing.Size(70, 35);
            OkBtn.TabIndex = 7;
            OkBtn.Text = "Ок";
            OkBtn.UseVisualStyleBackColor = true;
            OkBtn.Click += OkBtn_Click;
            // 
            // TypePctrBx
            // 
            TypePctrBx.Location = new System.Drawing.Point(10, 85);
            TypePctrBx.Margin = new System.Windows.Forms.Padding(0);
            TypePctrBx.Name = "TypePctrBx";
            TypePctrBx.Size = new System.Drawing.Size(70, 70);
            TypePctrBx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            TypePctrBx.TabIndex = 9;
            TypePctrBx.TabStop = false;
            // 
            // MessageForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(24, 30, 54);
            ClientSize = new System.Drawing.Size(440, 240);
            Controls.Add(OkBtn);
            Controls.Add(TypePctrBx);
            Controls.Add(CloseBtn);
            Font = new System.Drawing.Font("Cascadia Code", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ForeColor = System.Drawing.Color.FromArgb(158, 161, 176);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(4);
            Name = "MessageForm";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "MessageForm";
            Load += MessageForm_Load;
            ((System.ComponentModel.ISupportInitialize)TypePctrBx).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.PictureBox TypePctrBx;
    }
}