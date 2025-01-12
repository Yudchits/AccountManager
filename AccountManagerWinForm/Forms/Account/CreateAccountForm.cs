﻿using AccountManager.Application.Features.Account.Create;
using AccountManagerWinForm.Factories;
using AccountManagerWinForm.Forms.Common.Elements;
using MediatR;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AccountManagerWinForm.Forms.Account
{
    public partial class CreateAccountForm : Form
    {
        private readonly int _resourceId;
        private readonly IMediator _mediator;
        private readonly IFormFactory _formFactory;

        private Label createLbl;
        private MatTextBox nameTxtBx;
        private MatTextBox loginTxtBx;
        private MatTextBox passwordTxtBx;

        public CreateAccountForm(int resourceId, IMediator mediator, IFormFactory formFactory)
        {
            InitializeComponent();
            InitializeCreateForm();
            
            _resourceId = resourceId;
            _mediator = mediator;
            _formFactory = formFactory;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SaveBtn.Focus();
        }

        private void InitializeCreateForm()
        {
            int inputWidth = Width / 2;
            int inputMarginBottom = 30;
            int x = inputWidth - (inputWidth / 2);
            var font = new Font("Cascadia Code", 12f);

            var createPnl = new Panel
            {
                BorderStyle = BorderStyle.None,
                Width = inputWidth,
                Location = new Point(x, 0)
            };
            Controls.Add(createPnl);

            createLbl = new Label
            {
                Parent = createPnl,
                AutoSize = true,
                Text = "Создание",
                Padding = new Padding(0, 0, 0, 15),
                Font = new Font(Font.Name, 14f, FontStyle.Underline)
            };
            createLbl.Location = new Point((createPnl.Width / 2) - (createLbl.Width / 2), 0);
            createPnl.Controls.Add(createLbl);

            nameTxtBx = new MatTextBox
            {
                Parent = createPnl,
                Width = inputWidth,
                Placeholder = "Имя",
                Font = font,
                Location = new Point(0, createLbl.Bottom),
                Padding = new Padding(0, 0, 0, inputMarginBottom),
            };
            createPnl.Controls.Add(nameTxtBx);

            loginTxtBx = new MatTextBox
            {
                Parent = createPnl,
                Width = inputWidth,
                Placeholder = "Логин",
                Location = new Point(0, nameTxtBx.Bottom),
                Font = font,
                Padding = new Padding(0, 0, 0, inputMarginBottom)
            };
            createPnl.Controls.Add(loginTxtBx);

            passwordTxtBx = new MatTextBox
            {
                Parent = createPnl,
                Width = inputWidth,
                Placeholder = "Пароль",
                Location = new Point(0, loginTxtBx.Bottom),
                Font = font,
                Padding = new Padding(0, 0, 0, inputMarginBottom),
                PasswordChar = '*'
            };
            createPnl.Controls.Add(passwordTxtBx);

            SaveBtn.Parent = createPnl;
            SaveBtn.Location = new Point(passwordTxtBx.Right - SaveBtn.Width, passwordTxtBx.Bottom);

            createPnl.Height = createLbl.Height 
                + nameTxtBx.Height 
                + loginTxtBx.Height 
                + passwordTxtBx.Height 
                + SaveBtn.Height;
            createPnl.Location = new Point(x, 50);
        }

        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            var createRequest = new CreateAccountRequest(_resourceId, nameTxtBx.Text, loginTxtBx.Text, passwordTxtBx.Text);
            await _mediator.Send(createRequest);

            Controls.Clear();
            var accountsForm = _formFactory.CreateAccountsForm(_resourceId);
            accountsForm.TopLevel = false;
            accountsForm.TopMost = true;
            accountsForm.Dock = DockStyle.Fill;
            Controls.Add(accountsForm);
            accountsForm.Show();
        }

        private void CreateAccountForm_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
        }
    }
}