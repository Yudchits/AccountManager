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
            ((System.ComponentModel.ISupportInitialize)ImagePctrBx).BeginInit();
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
            // ResourcesForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(46, 51, 73);
            ClientSize = new System.Drawing.Size(800, 490);
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
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.PictureBox ImagePctrBx;
        private System.Windows.Forms.Button PreviousBtn;
        private System.Windows.Forms.Button NextBtn;
        private System.Windows.Forms.Label NoResourcesLbl;
        private System.Windows.Forms.TextBox SearchTxtBx;
    }
}