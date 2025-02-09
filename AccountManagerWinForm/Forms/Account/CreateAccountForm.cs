using AccountManager.Application.Features.Account.Create;
using AccountManager.Application.Features.Account.GetByResourceId;
using AccountManager.Application.Features.Account.Update;
using AccountManager.Application.Features.Common.Cryptography.Aes.Decrypt;
using AccountManagerWinForm.Extensions;
using AccountManagerWinForm.Factories;
using AccountManagerWinForm.Forms.Common.Elements;
using AccountManagerWinForm.Properties;
using MediatR;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountManagerWinForm.Forms.Account
{
    public partial class CreateAccountForm : Form
    {
        private readonly int? _accountId;

        private readonly int _resourceId;
        private readonly IMediator _mediator;
        private readonly IFormFactory _formFactory;
        private MatTextBox nameTxtBx;
        private MatTextBox loginTxtBx;
        private MatTextBox passwordTxtBx;
        private Button backBtn;
        private Button saveBtn;

        private CreateAccountForm(int? accountId, int resourceId, IMediator mediator, IFormFactory formFactory)
        {
            _accountId = accountId;

            InitializeComponent();
            InitializeCreateForm();

            _resourceId = resourceId;
            _mediator = mediator;
            _formFactory = formFactory;
        }

        public CreateAccountForm
        (
            int resourceId, 
            IMediator mediator, 
            IFormFactory formFactory
        ) : this(null, resourceId, mediator, formFactory)
        {
        }

        public CreateAccountForm
        (
            GetAccountsByResourceIdResponse account, 
            IMediator mediator, 
            IFormFactory formFactory
        ) : this(account.Id, account.ResourceId, mediator, formFactory)
        {
            nameTxtBx.Text = account.Name;
            loginTxtBx.Text = account.Login;
            passwordTxtBx.Text = account.Password;
        }

        protected async override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            backBtn.Focus();

            if (_accountId != null)
            {
                passwordTxtBx.Text = await DecryptText(passwordTxtBx.Text);
            }
        }

        private async Task<string> DecryptText(string encryptedText)
        {
            var decryptResult = await _mediator.Send(new AesDecryptRequest(encryptedText));
            return decryptResult.PlainText;
        }

        private void InitializeCreateForm()
        {
            int inputWidth = Width / 2;
            int inputMarginBottom = 10;
            int x = inputWidth - (inputWidth / 2);
            var font = new Font("Cascadia Code", 12f);

            var createPnl = new Panel
            {
                BorderStyle = BorderStyle.None,
                Width = inputWidth,
                Location = new Point(x, 0)
            };
            Controls.Add(createPnl);

            nameTxtBx = new MatTextBox
            {
                Parent = createPnl,
                Width = inputWidth,
                Font = font,
                Location = new Point(0, 15),
                Label = "Имя"
            };
            createPnl.Controls.Add(nameTxtBx);

            loginTxtBx = new MatTextBox
            {
                Parent = createPnl,
                Width = inputWidth,
                Location = new Point(0, nameTxtBx.Bottom + inputMarginBottom),
                Label = "Логин",
                Font = font
            };
            createPnl.Controls.Add(loginTxtBx);

            passwordTxtBx = new MatTextBox
            {
                Parent = createPnl,
                Width = inputWidth,
                Location = new Point(0, loginTxtBx.Bottom + inputMarginBottom),
                Label = "Пароль",
                Font = font,
                PasswordChar = '*'
            };
            passwordTxtBx.GotFocus += PasswordTxtBx_GotFocus;
            passwordTxtBx.LostFocus += PasswordTxtBx_LostFocus;
            createPnl.Controls.Add(passwordTxtBx);

            backBtn = new Button
            {
                Parent = createPnl,
                FlatStyle = FlatStyle.Flat,
                Text = "Назад",
                Image = Resources.Back24,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                AutoSize = true,
                Padding = new Padding(3)
            };
            backBtn.FlatAppearance.BorderSize = 0;
            int btnMarginTop = 25;
            int btnTop = passwordTxtBx.Bottom + btnMarginTop;
            backBtn.Location = new Point(0, btnTop);
            backBtn.Click += BackBtn_Click;
            createPnl.Controls.Add(backBtn);

            saveBtn = new Button
            {
                Parent = createPnl,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.FromArgb(0, 180, 249),
                Text = "Сохранить",
                Image = Resources.Save24,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                AutoSize = true,
                Padding = new Padding(3)
            };
            saveBtn.Location = new Point(passwordTxtBx.Right - saveBtn.Width, btnTop);
            saveBtn.Click += SaveBtn_Click;
            createPnl.Controls.Add(saveBtn);

            createPnl.Height = nameTxtBx.Height 
                + loginTxtBx.Height 
                + passwordTxtBx.Height 
                + saveBtn.Height
                + inputMarginBottom * 4
                + btnMarginTop;
            createPnl.Location = new Point(x, 30);
        }

        private void PasswordTxtBx_GotFocus(object? sender, EventArgs e)
        {
            passwordTxtBx.PasswordChar = '\0';
        }

        private void PasswordTxtBx_LostFocus(object? sender, EventArgs e)
        {
            passwordTxtBx.PasswordChar = '*';
        }

        private void BackBtn_Click(object? sender, EventArgs e)
        {
            ShowAccountsForm();
        }

        private void ShowAccountsForm()
        {
            var accountsForm = _formFactory.CreateAccountsForm(_resourceId);
            this.ShowWithinIndex(accountsForm, "Аккаунты");
        }

        private async void SaveBtn_Click(object? sender, EventArgs e)
        {
            if (_accountId == null)
            {
                await CreateAccount();
            }
            else
            {
                await UpdateAccount();
            }

            ShowAccountsForm();
        }

        private async Task CreateAccount()
        {
            await _mediator.Send(new CreateAccountRequest
            (
                _resourceId,
                nameTxtBx.Text,
                loginTxtBx.Text,
                passwordTxtBx.Text
            ));
        }

        private async Task UpdateAccount()
        {
            if (_accountId != null)
            {
                await _mediator.Send(new UpdateAccountRequest(
                    (int)_accountId, 
                    _resourceId, 
                    nameTxtBx.Text, 
                    loginTxtBx.Text, 
                    passwordTxtBx.Text
                ));
            }
        }

        private void CreateAccountForm_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
        }
    }
}