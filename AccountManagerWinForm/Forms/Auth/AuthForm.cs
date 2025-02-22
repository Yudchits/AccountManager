using AccountManager.Application.Common;
using AccountManager.Application.Features.Auth.Login;
using AccountManager.Application.Features.Auth.Registration;
using AccountManager.Domain.Entities;
using AccountManagerWinForm.Forms.Common.Elements;
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
        private readonly IDictionary<string, MatTextBox> _validationMappings;

        private readonly IMediator _mediator;
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

        public AuthForm(IMediator mediator)
        {
            InitializeComponent();

            _mediator = mediator;

            _validationMappings = new Dictionary<string, MatTextBox>
            {
                { nameof(User.Login), LoginTxtBx },
                { nameof(User.Password), PasswordTxtBx }
            };
        }

        private void AuthForm_Load(object sender, EventArgs e)
        {
            AuthHeaderLbl.Focus();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            LoginTxtBx.BackColor = Color.FromArgb(24, 30, 54);
            PasswordTxtBx.BackColor = Color.FromArgb(24, 30, 54);
            AuthHavingLinkLbl.Font = new Font(AuthHavingLbl.Font, FontStyle.Underline);
            AuthHeaderLbl.Font = new Font(AuthHeaderLbl.Font, FontStyle.Underline);
            LocateAuthHavingLbls();
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
            int? userId = isLogin
                ? await LoginAsync() 
                : await RegistrationAsync();

            if (userId != null)
            {
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
                        LoginTxtBx.Text,
                        PasswordTxtBx.Text
                    )
                );

                return loginResponse.Id;
            }
            catch (ApplicationExceptionBase ex)
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
                        LoginTxtBx.Text,
                        PasswordTxtBx.Text
                    )
                );

                return registrationResponse.Id;
            }
            catch (ApplicationExceptionBase ex)
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
            LoginTxtBx.Text = string.Empty;
            LoginTxtBx.Error = string.Empty;
            PasswordTxtBx.Text = string.Empty;
            PasswordTxtBx.Error = string.Empty;
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