namespace AccountManagerWinForm.Forms.Account
{
    partial class CreateAccountForm
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
            SaveBtn = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // SaveBtn
            // 
            SaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            SaveBtn.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            SaveBtn.ForeColor = System.Drawing.Color.FromArgb(0, 180, 249);
            SaveBtn.Image = Properties.Resources.Save24;
            SaveBtn.Location = new System.Drawing.Point(618, 428);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new System.Drawing.Size(150, 45);
            SaveBtn.TabIndex = 2;
            SaveBtn.Text = "Сохранить";
            SaveBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            SaveBtn.UseVisualStyleBackColor = true;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // CreateAccountForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(46, 51, 73);
            ClientSize = new System.Drawing.Size(800, 490);
            Controls.Add(SaveBtn);
            Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ForeColor = System.Drawing.Color.FromArgb(158, 161, 176);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(4);
            Name = "CreateAccountForm";
            Text = "CreateAccountForm";
            Click += CreateAccountForm_Click;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button SaveBtn;
    }
}