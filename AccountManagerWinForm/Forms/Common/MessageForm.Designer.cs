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
            panel1 = new System.Windows.Forms.Panel();
            MessageTextBox = new System.Windows.Forms.TextBox();
            OkBtn = new System.Windows.Forms.Button();
            CloseBtn = new System.Windows.Forms.Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.FromArgb(46, 51, 73);
            panel1.Controls.Add(MessageTextBox);
            panel1.Controls.Add(OkBtn);
            panel1.Controls.Add(CloseBtn);
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(400, 200);
            panel1.TabIndex = 0;
            // 
            // MessageTextBox
            // 
            MessageTextBox.BackColor = System.Drawing.Color.FromArgb(46, 51, 73);
            MessageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            MessageTextBox.ForeColor = System.Drawing.Color.White;
            MessageTextBox.Location = new System.Drawing.Point(50, 69);
            MessageTextBox.Multiline = true;
            MessageTextBox.Name = "MessageTextBox";
            MessageTextBox.ReadOnly = true;
            MessageTextBox.Size = new System.Drawing.Size(300, 69);
            MessageTextBox.TabIndex = 8;
            MessageTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // OkBtn
            // 
            OkBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            OkBtn.ForeColor = System.Drawing.Color.White;
            OkBtn.Location = new System.Drawing.Point(322, 155);
            OkBtn.Name = "OkBtn";
            OkBtn.Size = new System.Drawing.Size(66, 33);
            OkBtn.TabIndex = 7;
            OkBtn.Text = "Ок";
            OkBtn.UseVisualStyleBackColor = true;
            OkBtn.Click += OkBtn_Click;
            // 
            // CloseBtn
            // 
            CloseBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(28, 29, 35);
            CloseBtn.FlatAppearance.BorderSize = 0;
            CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            CloseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            CloseBtn.ForeColor = System.Drawing.Color.White;
            CloseBtn.Location = new System.Drawing.Point(340, 0);
            CloseBtn.Name = "CloseBtn";
            CloseBtn.Size = new System.Drawing.Size(60, 30);
            CloseBtn.TabIndex = 2;
            CloseBtn.Text = "X";
            CloseBtn.UseVisualStyleBackColor = true;
            CloseBtn.Click += CloseBtn_Click;
            // 
            // MessageForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(400, 200);
            Controls.Add(panel1);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "MessageForm";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "MessageForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.TextBox MessageTextBox;
    }
}