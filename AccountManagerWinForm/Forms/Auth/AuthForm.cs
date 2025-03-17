using AccountManager.Application.Common.Exceptions;
using AccountManager.Application.Context;
using AccountManager.Application.Features.Auth.Login;
using AccountManager.Application.Features.Auth.Registration;
using AccountManager.Application.Features.Common.Cryptography.Hash.Generate;
using AccountManager.Domain.Entities;
using AccountManagerWinForm.Forms.Common.Elements.Mat;
using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountManagerWinForm.Forms.Auth
{
    public partial class AuthForm : Form
    {
        private MatTextBox loginTxtBx;
        private MatTextBox passwordTxtBx;

        private readonly IDictionary<string, MatTextBox> _validationMappings;
        private readonly IMediator _mediator;
        private readonly UserContext _userContext;
        private bool isLogin = true;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        public AuthForm(IMediator mediator, UserContext userContext)
        {
            InitializeComponent();
            InitializeTextBoxes();

            _mediator = mediator;
            _userContext = userContext;

            _validationMappings = new Dictionary<string, MatTextBox>
            {
                { nameof(User.Login), loginTxtBx },
                { nameof(User.Password), passwordTxtBx }
            };
        }

        private void InitializeTextBoxes()
        {
            loginTxtBx = new MatTextBox
            {
                Width = 300,
                Location = new Point(60, 135),
                Label = "Логин"
            };
            AuthPnl.Controls.Add(loginTxtBx);

            passwordTxtBx = new MatTextBox
            {
                Width = 300,
                Location = new Point(60, loginTxtBx.Bottom + 15),
                Label = "Пароль",
                PasswordChar = '*'
            };
            AuthPnl.Controls.Add(passwordTxtBx);
        }

        private void AuthForm_Load(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            LocateAuthHavingLbls();
            passwordTxtBx.KeyDown += PasswordTxtBx_KeyPressAsync;
        }

        private async void PasswordTxtBx_KeyPressAsync(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await SendAuthRequest();
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginPnl_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
        }

        private async void AuthBtn_ClickAsync(object sender, EventArgs e)
        {
            await SendAuthRequest();
        }

        private async Task SendAuthRequest()
        {
            int? userId = isLogin
                ? await LoginAsync()
                : await RegistrationAsync();

            if (userId != null)
            {
                var generateCryptoKeyResponse = await _mediator.Send
                (
                    new GenerateHashRequest(passwordTxtBx.Text)
                );

                _userContext.Configure((int)userId, generateCryptoKeyResponse.Hash);

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private async Task<int?> LoginAsync()
        {
            try
            {
                var loginResponse = await _mediator.Send
                (
                    new AuthLoginRequest
                    (
                        loginTxtBx.Text,
                        passwordTxtBx.Text
                    )
                );

                return loginResponse.Id;
            }
            catch (UserExceptionBase ex)
            {
                _validationMappings.TryGetValue(ex.PropertyName, out var txtBx);
                if (txtBx == null)
                {
                    throw;
                }

                txtBx.Error = ex.Message;
            }

            return null;
        }

        private async Task<int?> RegistrationAsync()
        {
            try
            {
                var registrationResponse = await _mediator.Send
                (
                    new AuthRegistrationRequest
                    (
                        loginTxtBx.Text,
                        passwordTxtBx.Text
                    )
                );

                return registrationResponse.Id;
            }
            catch (UserExceptionBase ex)
            {
                _validationMappings.TryGetValue(ex.PropertyName, out var txtBx);
                if (txtBx == null)
                {
                    throw;
                }

                txtBx.Error = ex.Message;
            }

            return null;
        }

        private void AuthHavingLinkLbl_Click(object sender, EventArgs e)
        {
            isLogin = !isLogin;
            loginTxtBx.Text = string.Empty;
            loginTxtBx.Error = string.Empty;
            passwordTxtBx.Text = string.Empty;
            passwordTxtBx.Error = string.Empty;
            ActiveControl = null;

            if (isLogin)
            {
                DisplayLogin();
            }
            else
            {
                DisplayRegistration();
            }
        }

        private void DisplayLogin()
        {
            AuthHeaderLbl.Text = "Вход";
            AuthHavingLbl.Text = "Нет аккаунта?";
            AuthHavingLinkLbl.Text = "Регистрация";
            LocateAuthHeaderLbl();
            LocateAuthHavingLbls();
        }

        private void LocateAuthHeaderLbl()
        {
            AuthHeaderLbl.Location = new Point((Width - AuthHeaderLbl.Width) / 2, AuthHeaderLbl.Top);
        }

        private void LocateAuthHavingLbls()
        {
            int x = (AuthHavingPnl.Width - AuthHavingLbl.Width - AuthHavingLinkLbl.Width) / 2;
            int y = AuthHavingLbl.Top;
            AuthHavingLbl.Location = new Point(x, y);
            AuthHavingLinkLbl.Location = new Point(AuthHavingLbl.Right, y);
        }

        private void DisplayRegistration()
        {
            AuthHeaderLbl.Text = "Регистрация";
            AuthHavingLbl.Text = "Есть аккаунт?";
            AuthHavingLinkLbl.Text = "Вход";
            LocateAuthHeaderLbl();
            LocateAuthHavingLbls();
        }
    }
}