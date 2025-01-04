using AccountManager.Application.Features.Account.GetByResourceId;
using AccountManagerWinForm.Properties;
using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AccountManagerWinForm.Forms.Account
{
    public partial class AccountsForm : Form
    {
        private const string PASSWORD_CHAR = "********";
        private readonly IMediator _mediator;
        private ICollection<GetAccountsByResourceIdResponse> _accounts;
        private bool isDragging = false;
        private int initialMouseY;
        private int maxMouseY;

        public int ResourceId { get; set; }

        public AccountsForm(IMediator mediator)
        {
            InitializeComponent();
            ScrollPnl.BringToFront();
            MouseWheel += ScrollPnl_MouseWheel;

            _mediator = mediator;
            _accounts = new List<GetAccountsByResourceIdResponse>();
            maxMouseY = Height - ScrollPnl.Height;
        }

        private async void AccountsForm_Load(object sender, EventArgs e)
        {
            if (ResourceId < 1)
            {
                Controls.Clear();
                throw new ArgumentException("Идентификатор ресурса задан неверно");
            }

            _accounts = await _mediator.Send(new GetAccountsByResourceIdRequest(ResourceId));
            UpdateUIWithAccounts();
        }

        private void UpdateUIWithAccounts()
        {
            AccountsFLPnl.Controls.Clear();

            int cardMarginBottom = 40;
            int descLblWidth = 100;
            int lblHeight = 27;
            int loginPnlMarginTop = 7;
            int btnWidth = 24;
            int passwordPnlMarginTop = 5;

            foreach (var account in _accounts)
            {
                var cardPnl = new Panel
                {
                    Parent = AccountsFLPnl,
                    Dock = DockStyle.Top,
                    Width = AccountsFLPnl.Width,
                    Margin = new Padding(0, 0, 0, cardMarginBottom)
                };

                var nameLbl = new Label
                {
                    Parent = cardPnl,
                    Text = account.Name,
                    Dock = DockStyle.Top,
                    AutoSize = true,
                    Width = cardPnl.Width,
                    Font = new Font(Font, FontStyle.Underline)
                };
                cardPnl.Controls.Add(nameLbl);

                var loginPnl = new Panel
                {
                    Parent = cardPnl,
                    Width = cardPnl.Width,
                    BorderStyle = BorderStyle.None,
                    Location = new Point(0, nameLbl.Height + loginPnlMarginTop),
                };

                var loginDescLbl = new Label
                {
                    Parent = loginPnl,
                    Text = "Логин:",
                    Width = descLblWidth,
                    Height = lblHeight,
                    TextAlign = ContentAlignment.MiddleRight,
                };

                loginPnl.Controls.Add(loginDescLbl);

                var lightBlue = Color.FromArgb(0, 180, 249);
                var loginValueLbl = new Label
                {
                    Parent = loginPnl,
                    Text = account.Login,
                    Location = new Point(loginDescLbl.Location.X + loginDescLbl.Width, loginDescLbl.Location.Y),
                    ForeColor = lightBlue,
                    AutoSize = true,
                    MaximumSize = new Size(loginPnl.Width, loginDescLbl.Height)
                };

                loginPnl.Height = loginValueLbl.Height;
                loginPnl.Controls.Add(loginValueLbl);

                cardPnl.Controls.Add(loginPnl);

                var loginCopyBtn = new Button
                {
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(loginValueLbl.Location.X + loginValueLbl.Width, loginValueLbl.Location.Y),
                    Size = new Size(btnWidth, loginValueLbl.Height),
                    Image = Resources.Copy24,
                    Tag = account.Login
                };
                loginCopyBtn.Click += LoginCopyBtn_Click;

                loginCopyBtn.FlatAppearance.BorderSize = 0;
                loginPnl.Controls.Add(loginCopyBtn);

                var passwordPnl = new Panel
                {
                    Parent = cardPnl,
                    Width = cardPnl.Width,
                    BorderStyle = BorderStyle.None,
                    Location = new Point(0, loginPnl.Location.Y + loginPnl.Height + passwordPnlMarginTop),
                };
                cardPnl.Controls.Add(passwordPnl);

                var passwordLbl = new Label
                {
                    Parent = passwordPnl,
                    Text = "Пароль:",
                    Width = descLblWidth,
                    Height = lblHeight,
                    TextAlign = ContentAlignment.MiddleRight
                };
                passwordPnl.Controls.Add(passwordLbl);

                var passwordValueLbl = new Label
                {
                    Parent = passwordPnl,
                    Text = PASSWORD_CHAR,
                    Location = new Point(passwordLbl.Location.X + passwordLbl.Width, passwordLbl.Location.Y),
                    ForeColor = lightBlue,
                    AutoSize = true,
                    MaximumSize = new Size(passwordPnl.Width, passwordPnl.Height),
                    Tag = account.Password
                };
                passwordPnl.Height = passwordValueLbl.Height;
                passwordPnl.Controls.Add(passwordValueLbl);

                var passwordCopyBtn = new Button
                {
                    Parent = passwordPnl,
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(passwordValueLbl.Location.X + passwordValueLbl.Width, passwordValueLbl.Location.Y),
                    Size = new Size(btnWidth, passwordValueLbl.Height),
                    Image = Resources.Copy24,
                    Tag = passwordValueLbl.Tag
                };
                passwordCopyBtn.FlatAppearance.BorderSize = 0;
                passwordCopyBtn.Click += PasswordCopyBtn_Click;
                passwordPnl.Controls.Add(passwordCopyBtn);

                var passwordEyeBtn = new Button
                {
                    Parent = passwordPnl,
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(passwordCopyBtn.Location.X + passwordCopyBtn.Width, passwordCopyBtn.Location.Y),
                    Size = new Size(btnWidth, passwordCopyBtn.Height),
                    Image = Resources.Eye24,
                    Tag = account.Password
                };
                passwordEyeBtn.FlatAppearance.BorderSize = 0;
                passwordEyeBtn.Click += PasswordEyeBtn_Click;
                passwordPnl.Controls.Add(passwordEyeBtn);

                cardPnl.Height = nameLbl.Height + loginPnlMarginTop + loginValueLbl.Height + passwordPnlMarginTop + passwordValueLbl.Height;
             
                AccountsFLPnl.Controls.Add(cardPnl);
            }
        }

        private void LoginCopyBtn_Click(object? sender, EventArgs e)
        {
            if (sender is not null)
            {
                var button = sender as Button;
                Clipboard.SetText(button?.Tag.ToString());
            }
        }

        private void PasswordCopyBtn_Click(object? sender, EventArgs e)
        {
            if (sender is not null)
            {
                var button = sender as Button;
                Clipboard.SetText(button?.Tag.ToString());
            }
        }

        private void PasswordEyeBtn_Click(object? sender, EventArgs e)
        {

        }

        private void ScrollPnl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                initialMouseY = e.Y;
            }
        }

        private void ScrollPnl_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int deltaY = e.Y - initialMouseY;
                int currentMouseY = Math.Max(0, ScrollPnl.Top + deltaY);
                currentMouseY = Math.Min(currentMouseY, maxMouseY);

                ScrollPnl.Top = currentMouseY;

                AccountsFLPnl.Top = 0 - currentMouseY;
                AccountsFLPnl.Height += currentMouseY;
            }
        }

        private void ScrollPnl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void ScrollPnl_MouseWheel(object? sender, MouseEventArgs e)
        {
            int scrollStep = 15;
            int deltaY = e.Delta > 0 ? -scrollStep : scrollStep;

            int newScrollTop = Math.Max(0, ScrollPnl.Top + deltaY);
            newScrollTop = Math.Min(newScrollTop, maxMouseY);

            ScrollPnl.Top = newScrollTop;

            AccountsFLPnl.Top = 0 - newScrollTop;
            AccountsFLPnl.Height += newScrollTop;
        }
    }
}
