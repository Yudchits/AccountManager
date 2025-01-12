using AccountManager.Application.Features.Account.GetByResourceId;
using AccountManagerWinForm.Factories;
using AccountManagerWinForm.Properties;
using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AccountManagerWinForm.Forms.Account
{
    public partial class AccountsForm : Form
    {
        private const string PASSWORD_CHAR = "********";
        private const int ACCOUNTS_ON_PAGE = 6;
        private const int HEADER_HEIGHT = 60;
        private const int FOOTER_HEIGHT = 60;

        private readonly int _resourceId;
        private readonly IMediator _mediator;
        private readonly IFormFactory _formFactory;
        private readonly Color lightBlue = Color.FromArgb(0, 180, 249);

        private ICollection<GetAccountsByResourceIdResponse> _accounts = new List<GetAccountsByResourceIdResponse>();

        private bool isDragging = false;
        private int initialMouseY;
        private int maxMouseY;

        private Label? pageLbl;
        private int currentPage = 1;
        private int maxPageCount;

        public AccountsForm(int resourceId, IMediator mediator, IFormFactory formFactory)
        {
            InitializeComponent();

            _resourceId = resourceId;
            _mediator = mediator;
            _formFactory = formFactory;
            
            maxMouseY = Height - ScrollPnl.Height;
        }

        private async void AccountsForm_Load(object sender, EventArgs e)
        {
            ScrollPnl.BringToFront();
            CreateAccBtn.SendToBack();

            _accounts = await _mediator.Send(new GetAccountsByResourceIdRequest(_resourceId));

            if (_accounts.Count == 0)
            {
                // TODO: add message
            }
            else
            {
                UpdateUIWithAccounts();
                UpdatePaginationPnl();
                CheckScrollVisibility();
            }
        }

        private void UpdateUIWithAccounts()
        {
            AccsFLPnl.Controls.Clear();
            AccsFLPnl.Height = 0;

            int accountMarginBottom = 30;
            int descLblWidth = 100;
            int lblHeight = 27;
            int loginPnlMarginTop = 7;
            int btnWidth = 24;
            int passwordPnlMarginTop = 5;

            int lastAccountIdOnPage = currentPage * ACCOUNTS_ON_PAGE - 1;
            int accountStartId = lastAccountIdOnPage - ACCOUNTS_ON_PAGE + 1;
            for (int i = accountStartId; i <= lastAccountIdOnPage && i < _accounts.Count; i++)
            {
                var account = _accounts.ElementAt(i);

                var accountPnl = new Panel
                {
                    Parent = AccsFLPnl,
                    Dock = DockStyle.Top,
                    Width = AccsFLPnl.Width,
                    Margin = new Padding(0, 0, 0, accountMarginBottom)
                };

                var nameLbl = new Label
                {
                    Parent = accountPnl,
                    Text = account.Name,
                    Dock = DockStyle.Top,
                    AutoSize = true,
                    Width = accountPnl.Width,
                    Font = new Font(Font, FontStyle.Underline)
                };
                accountPnl.Controls.Add(nameLbl);

                var loginPnl = new Panel
                {
                    Parent = accountPnl,
                    Width = accountPnl.Width,
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

                var loginValueLbl = new Label
                {
                    Parent = loginPnl,
                    Text = account.Login,
                    Location = new Point(loginDescLbl.Right, loginDescLbl.Top),
                    ForeColor = lightBlue,
                    AutoSize = true,
                    MaximumSize = new Size(loginPnl.Width, loginDescLbl.Height)
                };

                loginPnl.Height = loginValueLbl.Height;
                loginPnl.Controls.Add(loginValueLbl);

                accountPnl.Controls.Add(loginPnl);

                var loginCopyBtn = new Button
                {
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(loginValueLbl.Right, loginValueLbl.Top),
                    Size = new Size(btnWidth, loginValueLbl.Height),
                    Image = Resources.Copy24,
                    Tag = account.Login
                };
                loginCopyBtn.Click += LoginCopyBtn_Click;

                loginCopyBtn.FlatAppearance.BorderSize = 0;
                loginPnl.Controls.Add(loginCopyBtn);

                var passwordPnl = new Panel
                {
                    Parent = accountPnl,
                    Width = accountPnl.Width,
                    BorderStyle = BorderStyle.None,
                    Location = new Point(0, loginPnl.Bottom + passwordPnlMarginTop),
                };
                accountPnl.Controls.Add(passwordPnl);

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
                    Location = new Point(passwordLbl.Right, passwordLbl.Top),
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
                    Location = new Point(passwordValueLbl.Right, passwordValueLbl.Top),
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
                    Location = new Point(passwordCopyBtn.Right, passwordCopyBtn.Top),
                    Size = new Size(btnWidth, passwordCopyBtn.Height),
                    Image = Resources.Eye24,
                    Tag = account.Password
                };
                passwordEyeBtn.FlatAppearance.BorderSize = 0;
                passwordEyeBtn.Click += PasswordEyeBtn_Click;
                passwordPnl.Controls.Add(passwordEyeBtn);

                accountPnl.Height = nameLbl.Height + loginPnlMarginTop + loginValueLbl.Height + passwordPnlMarginTop + passwordValueLbl.Height;

                AccsFLPnl.Height += accountPnl.Height + accountMarginBottom;
                AccsFLPnl.Controls.Add(accountPnl);
            }
            AccsFLPnl.Height -= accountMarginBottom;
        }

        private void UpdatePaginationPnl()
        {
            double countDouble = (double)_accounts.Count / ACCOUNTS_ON_PAGE;
            maxPageCount = (int)Math.Floor(Math.Ceiling(countDouble));

            var paginationPnl = new Panel
            {
                Parent = this,
                Width = AccsFLPnl.Width,
                Height = FOOTER_HEIGHT
            };

            var previousBtn = new Button
            {
                Parent = paginationPnl,
                FlatStyle = FlatStyle.Flat,
                Dock = DockStyle.Left,
                Text = "Предыдущая",
                ForeColor = lightBlue,
                Image = Resources.Previous24,
                Width = 170,
                Height = FOOTER_HEIGHT,
                TextImageRelation = TextImageRelation.ImageBeforeText
            };
            previousBtn.FlatAppearance.BorderSize = 0;
            previousBtn.Click += PreviousBtn_Click;
            paginationPnl.Controls.Add(previousBtn);

            pageLbl = new Label
            {
                Parent = paginationPnl,
                Height = FOOTER_HEIGHT,
                Text = $"{currentPage} из {maxPageCount}",
                ForeColor = lightBlue,
                TextAlign = ContentAlignment.MiddleCenter
            };
            int pageLblX = (paginationPnl.Width / 2) - (pageLbl.Width / 2);
            paginationPnl.Controls.Add(pageLbl);

            var nextBtn = new Button
            {
                Parent = paginationPnl,
                FlatStyle = FlatStyle.Flat,
                Dock = DockStyle.Right,
                Text = "Следующая",
                ForeColor = lightBlue,
                Image = Resources.Next24,
                Width = 155,
                Height = FOOTER_HEIGHT,
                TextImageRelation = TextImageRelation.TextBeforeImage
            };
            nextBtn.FlatAppearance.BorderSize = 0;
            nextBtn.Click += NextBtn_Click;
            paginationPnl.Controls.Add(nextBtn);

            pageLbl.Location = new Point(pageLblX, (paginationPnl.Height / 2) - (pageLbl.Height / 2));
            paginationPnl.Location = new Point(AccsFLPnl.Left, Height - paginationPnl.Height);

            Controls.Add(paginationPnl);
            paginationPnl.BringToFront();
        }

        private void NextBtn_Click(object? sender, EventArgs e)
        {
            currentPage = currentPage < maxPageCount ? currentPage + 1 : 1;
            OpenCurrentPage();
        }

        private void OpenCurrentPage()
        {
            ScrollAccountsFLPnl(-ScrollPnl.Top);
            UpdateUIWithAccounts();
            CheckScrollVisibility();
            if (pageLbl != null)
            {
                pageLbl.Text = $"{currentPage} из {maxPageCount}";
            }
        }

        private void CheckScrollVisibility()
        {
            if (AccsFLPnl.Height >= Height - HEADER_HEIGHT - FOOTER_HEIGHT)
            {
                MouseWheel += AccountsForm_MouseWheel;
                ScrollPnl.Visible = true;
            }
            else
            {
                MouseWheel -= AccountsForm_MouseWheel;
                ScrollPnl.Visible = false;
            }
        }

        private void PreviousBtn_Click(object? sender, EventArgs e)
        {
            currentPage = currentPage > 1 ? currentPage - 1 : maxPageCount;
            OpenCurrentPage();
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
                ScrollAccountsFLPnl(deltaY);
            }
        }

        private void ScrollAccountsFLPnl(int deltaY)
        {
            int currentMouseY = Math.Max(0, ScrollPnl.Top + deltaY);
            currentMouseY = Math.Min(currentMouseY, maxMouseY);

            ScrollPnl.Top = currentMouseY;
            AccsFLPnl.Top = HEADER_HEIGHT - currentMouseY;
        }

        private void ScrollPnl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void AccountsForm_MouseWheel(object? sender, MouseEventArgs e)
        {
            int scrollStep = 15;
            int deltaY = e.Delta > 0 ? -scrollStep : scrollStep;
            ScrollAccountsFLPnl(deltaY);
        }

        private void CreateAccBtn_Click(object sender, EventArgs e)
        {
            var createForm = _formFactory.CreateCreateAccountForm(_resourceId);
            if (createForm != null)
            {
                Controls.Clear();
                createForm.TopLevel = false;
                createForm.TopMost = true;
                createForm.Dock = DockStyle.Fill;
                
                Controls.Add(createForm);
                createForm.Show();
            }
        }
    }
}