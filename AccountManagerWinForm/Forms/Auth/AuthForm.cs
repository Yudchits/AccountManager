using MediatR;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AccountManagerWinForm.Forms.Auth
{
    public partial class AuthForm : Form
    {
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
        }

        private void AuthForm_Load(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            LoginTxtBx.BackColor = Color.FromArgb(24, 30, 54);
            PasswordTxtBx.BackColor = Color.FromArgb(24, 30, 54);
            AuthHavingLinkLbl.Font = new Font(AuthHavingLbl.Font, FontStyle.Underline);
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

        private void AuthBtn_Click(object sender, EventArgs e)
        {

        }

        private void AuthHavingLinkLbl_Click(object sender, EventArgs e)
        {
            isLogin = !isLogin;
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