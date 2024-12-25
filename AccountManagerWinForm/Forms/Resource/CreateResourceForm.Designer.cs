namespace AccountManagerWinForm.Forms.Resource
{
    partial class CreateResourceForm
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
            CreateResourceMainPanel = new System.Windows.Forms.Panel();
            CreateResourceChooseImagePictureBox = new System.Windows.Forms.PictureBox();
            CreateResourceChooseImageLabel = new System.Windows.Forms.Label();
            CreateResourceSaveBtn = new System.Windows.Forms.Button();
            CreateResourceImagePictureBox = new System.Windows.Forms.PictureBox();
            CreateResourceNameTextBox = new System.Windows.Forms.TextBox();
            CreateResourceTopLabel = new System.Windows.Forms.Label();
            CloseBtn = new System.Windows.Forms.Button();
            CreateResourceMainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CreateResourceChooseImagePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CreateResourceImagePictureBox).BeginInit();
            SuspendLayout();
            // 
            // CreateResourceMainPanel
            // 
            CreateResourceMainPanel.BackColor = System.Drawing.Color.FromArgb(34, 32, 51);
            CreateResourceMainPanel.Controls.Add(CreateResourceChooseImagePictureBox);
            CreateResourceMainPanel.Controls.Add(CreateResourceChooseImageLabel);
            CreateResourceMainPanel.Controls.Add(CreateResourceSaveBtn);
            CreateResourceMainPanel.Controls.Add(CreateResourceImagePictureBox);
            CreateResourceMainPanel.Controls.Add(CreateResourceNameTextBox);
            CreateResourceMainPanel.Controls.Add(CreateResourceTopLabel);
            CreateResourceMainPanel.Controls.Add(CloseBtn);
            CreateResourceMainPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            CreateResourceMainPanel.ForeColor = System.Drawing.Color.White;
            CreateResourceMainPanel.Location = new System.Drawing.Point(0, 0);
            CreateResourceMainPanel.Name = "CreateResourceMainPanel";
            CreateResourceMainPanel.Size = new System.Drawing.Size(400, 500);
            CreateResourceMainPanel.TabIndex = 0;
            // 
            // CreateResourceChooseImagePictureBox
            // 
            CreateResourceChooseImagePictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            CreateResourceChooseImagePictureBox.Image = Properties.Resources.ChooseImage;
            CreateResourceChooseImagePictureBox.Location = new System.Drawing.Point(175, 240);
            CreateResourceChooseImagePictureBox.Name = "CreateResourceChooseImagePictureBox";
            CreateResourceChooseImagePictureBox.Size = new System.Drawing.Size(50, 50);
            CreateResourceChooseImagePictureBox.TabIndex = 8;
            CreateResourceChooseImagePictureBox.TabStop = false;
            CreateResourceChooseImagePictureBox.Click += CreateResourceChooseImagePictureBox_Click;
            // 
            // CreateResourceChooseImageLabel
            // 
            CreateResourceChooseImageLabel.AutoSize = true;
            CreateResourceChooseImageLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            CreateResourceChooseImageLabel.Location = new System.Drawing.Point(113, 303);
            CreateResourceChooseImageLabel.Name = "CreateResourceChooseImageLabel";
            CreateResourceChooseImageLabel.Size = new System.Drawing.Size(174, 20);
            CreateResourceChooseImageLabel.TabIndex = 7;
            CreateResourceChooseImageLabel.Text = "Выберите картинку";
            CreateResourceChooseImageLabel.Click += CreateFormResourceChooseImageLabel_Click;
            // 
            // CreateResourceSaveBtn
            // 
            CreateResourceSaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            CreateResourceSaveBtn.Location = new System.Drawing.Point(250, 428);
            CreateResourceSaveBtn.Name = "CreateResourceSaveBtn";
            CreateResourceSaveBtn.Padding = new System.Windows.Forms.Padding(3);
            CreateResourceSaveBtn.Size = new System.Drawing.Size(120, 42);
            CreateResourceSaveBtn.TabIndex = 6;
            CreateResourceSaveBtn.Text = "Сохранить";
            CreateResourceSaveBtn.UseVisualStyleBackColor = true;
            CreateResourceSaveBtn.Click += CreateResourceSaveBtn_Click;
            // 
            // CreateResourceImagePictureBox
            // 
            CreateResourceImagePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            CreateResourceImagePictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            CreateResourceImagePictureBox.InitialImage = null;
            CreateResourceImagePictureBox.Location = new System.Drawing.Point(30, 192);
            CreateResourceImagePictureBox.Name = "CreateResourceImagePictureBox";
            CreateResourceImagePictureBox.Size = new System.Drawing.Size(340, 165);
            CreateResourceImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            CreateResourceImagePictureBox.TabIndex = 5;
            CreateResourceImagePictureBox.TabStop = false;
            CreateResourceImagePictureBox.Click += CreateResourceImagePictureBox_Click;
            // 
            // CreateResourceNameTextBox
            // 
            CreateResourceNameTextBox.BackColor = System.Drawing.Color.FromArgb(34, 32, 51);
            CreateResourceNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            CreateResourceNameTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            CreateResourceNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            CreateResourceNameTextBox.ForeColor = System.Drawing.Color.White;
            CreateResourceNameTextBox.Location = new System.Drawing.Point(30, 135);
            CreateResourceNameTextBox.Name = "CreateResourceNameTextBox";
            CreateResourceNameTextBox.PlaceholderText = "Название ресурса";
            CreateResourceNameTextBox.Size = new System.Drawing.Size(340, 28);
            CreateResourceNameTextBox.TabIndex = 3;
            // 
            // CreateResourceTopLabel
            // 
            CreateResourceTopLabel.AutoSize = true;
            CreateResourceTopLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            CreateResourceTopLabel.Location = new System.Drawing.Point(110, 60);
            CreateResourceTopLabel.Name = "CreateResourceTopLabel";
            CreateResourceTopLabel.Size = new System.Drawing.Size(179, 25);
            CreateResourceTopLabel.TabIndex = 2;
            CreateResourceTopLabel.Text = "Создание ресурса";
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
            CloseBtn.TabIndex = 1;
            CloseBtn.Text = "X";
            CloseBtn.UseVisualStyleBackColor = true;
            CloseBtn.Click += CloseBtn_Click;
            // 
            // CreateResourceForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(400, 500);
            Controls.Add(CreateResourceMainPanel);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "CreateResourceForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "CreateResourceForm";
            CreateResourceMainPanel.ResumeLayout(false);
            CreateResourceMainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)CreateResourceChooseImagePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)CreateResourceImagePictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel CreateResourceMainPanel;
        private System.Windows.Forms.Label CreateResourceTopLabel;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.TextBox CreateResourceNameTextBox;
        private System.Windows.Forms.Button CreateResourceSaveBtn;
        private System.Windows.Forms.PictureBox CreateResourceImagePictureBox;
        private System.Windows.Forms.Label CreateResourceChooseImageLabel;
        private System.Windows.Forms.PictureBox CreateResourceChooseImagePictureBox;
    }
}