namespace AccountManagerWinForm.Forms.Resource
{
    partial class GetAllResourcesForm
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
            GetAllResourcesMainPanel = new System.Windows.Forms.Panel();
            CreateResourceBtn = new System.Windows.Forms.Button();
            ScrollDownBtn = new System.Windows.Forms.Button();
            ScrollUpBtn = new System.Windows.Forms.Button();
            ResourcesFLP = new System.Windows.Forms.FlowLayoutPanel();
            CloseBtn = new System.Windows.Forms.Button();
            GetAllResourcesMainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // GetAllResourcesMainPanel
            // 
            GetAllResourcesMainPanel.BackColor = System.Drawing.Color.FromArgb(28, 29, 35);
            GetAllResourcesMainPanel.Controls.Add(CreateResourceBtn);
            GetAllResourcesMainPanel.Controls.Add(ScrollDownBtn);
            GetAllResourcesMainPanel.Controls.Add(ScrollUpBtn);
            GetAllResourcesMainPanel.Controls.Add(ResourcesFLP);
            GetAllResourcesMainPanel.Controls.Add(CloseBtn);
            GetAllResourcesMainPanel.Location = new System.Drawing.Point(0, 0);
            GetAllResourcesMainPanel.Name = "GetAllResourcesMainPanel";
            GetAllResourcesMainPanel.Size = new System.Drawing.Size(1000, 800);
            GetAllResourcesMainPanel.TabIndex = 1;
            // 
            // CreateResourceBtn
            // 
            CreateResourceBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            CreateResourceBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            CreateResourceBtn.ForeColor = System.Drawing.Color.White;
            CreateResourceBtn.Location = new System.Drawing.Point(720, 36);
            CreateResourceBtn.Name = "CreateResourceBtn";
            CreateResourceBtn.Padding = new System.Windows.Forms.Padding(3);
            CreateResourceBtn.Size = new System.Drawing.Size(180, 48);
            CreateResourceBtn.TabIndex = 4;
            CreateResourceBtn.Text = "Добавить ресурс";
            CreateResourceBtn.UseVisualStyleBackColor = true;
            CreateResourceBtn.Click += CreateResourceBtn_Click;
            // 
            // ScrollDownBtn
            // 
            ScrollDownBtn.FlatAppearance.BorderSize = 0;
            ScrollDownBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ScrollDownBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ScrollDownBtn.ForeColor = System.Drawing.Color.White;
            ScrollDownBtn.Image = Properties.Resources.SlideDown;
            ScrollDownBtn.Location = new System.Drawing.Point(430, 717);
            ScrollDownBtn.Name = "ScrollDownBtn";
            ScrollDownBtn.Size = new System.Drawing.Size(102, 58);
            ScrollDownBtn.TabIndex = 3;
            ScrollDownBtn.UseVisualStyleBackColor = true;
            ScrollDownBtn.Click += ScrollDownBtn_Click;
            // 
            // ScrollUpBtn
            // 
            ScrollUpBtn.FlatAppearance.BorderSize = 0;
            ScrollUpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ScrollUpBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ScrollUpBtn.ForeColor = System.Drawing.Color.White;
            ScrollUpBtn.Image = Properties.Resources.SlideUp;
            ScrollUpBtn.Location = new System.Drawing.Point(426, 26);
            ScrollUpBtn.Name = "ScrollUpBtn";
            ScrollUpBtn.Size = new System.Drawing.Size(106, 68);
            ScrollUpBtn.TabIndex = 2;
            ScrollUpBtn.UseVisualStyleBackColor = false;
            ScrollUpBtn.Click += ScrollUpBtn_Click;
            // 
            // ResourcesFLP
            // 
            ResourcesFLP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ResourcesFLP.ForeColor = System.Drawing.Color.White;
            ResourcesFLP.Location = new System.Drawing.Point(100, 100);
            ResourcesFLP.Name = "ResourcesFLP";
            ResourcesFLP.Size = new System.Drawing.Size(800, 600);
            ResourcesFLP.TabIndex = 1;
            // 
            // CloseBtn
            // 
            CloseBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(28, 29, 35);
            CloseBtn.FlatAppearance.BorderSize = 0;
            CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            CloseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            CloseBtn.ForeColor = System.Drawing.Color.White;
            CloseBtn.Location = new System.Drawing.Point(940, 0);
            CloseBtn.Name = "CloseBtn";
            CloseBtn.Size = new System.Drawing.Size(60, 30);
            CloseBtn.TabIndex = 0;
            CloseBtn.Text = "X";
            CloseBtn.UseVisualStyleBackColor = true;
            CloseBtn.Click += CloseBtn_Click;
            // 
            // GetAllResourcesForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1000, 800);
            ControlBox = false;
            Controls.Add(GetAllResourcesMainPanel);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GetAllResourcesForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "GetAllResource";
            Load += GetAllResource_Load;
            GetAllResourcesMainPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel GetAllResourcesMainPanel;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.FlowLayoutPanel ResourcesFLP;
        private System.Windows.Forms.Button ScrollDownBtn;
        private System.Windows.Forms.Button ScrollUpBtn;
        private System.Windows.Forms.Button CreateResourceBtn;
    }
}