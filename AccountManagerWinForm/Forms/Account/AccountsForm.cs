using AccountManager.Application.Context;
using AccountManager.Application.Features.Account.GetByResourceId;
using AccountManager.Application.Features.Common.Cryptography.Encrypt.Aes.Decrypt;
using AccountManager.Application.Features.UserAccountBookmark.Create;
using AccountManager.Domain.Entities;
using AccountManagerWinForm.Extensions;
using AccountManagerWinForm.Factories;
using AccountManagerWinForm.Forms.Common.Elements.Mat;
using AccountManagerWinForm.Properties;
using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
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
        private readonly UserContext _userContext;
        private readonly Color lightBlue = Color.FromArgb(0, 180, 249);

        private ICollection<GetAccountsByResourceIdResponse> _accounts;
        private ICollection<GetAccountsByResourceIdResponse> _accountsToDisplay;

        private bool isDragging = false;
        private int initialMouseY;
        private int maxMouseY;

        private Label? pageLbl;
        private int currentPage = 1;
        private int maxPageCount;

        public AccountsForm(int resourceId, IMediator mediator, IFormFactory formFactory, UserContext userContext)
        {
            InitializeComponent();

            _resourceId = resourceId;
            _mediator = mediator;
            _formFactory = formFactory;
            _userContext = userContext;
            
            _accounts = new List<GetAccountsByResourceIdResponse>();
            _accountsToDisplay = _accounts;

            maxMouseY = Height - ScrollPnl.Height;
        }

        private async void AccountsForm_Load(object sender, EventArgs e)
        {
            ScrollPnl.BringToFront();
            CreateAccBtn.SendToBack();
            InitializeSearchMatTxtBx();
            await InitAccounts();
        }

        private void InitializeSearchMatTxtBx()
        {
            var font = new Font("Cascadia Code", 12f);

            var searchPnl = Program.IndexForm?.SearchPnl;

            if (searchPnl != null)
            {
                var searchTxtBx = new MatTextBox
                {
                    Label = "Поиск",
                    Font = font,
                    Location = new Point(0, 0),
                    Width = searchPnl.Width
                };
                searchTxtBx.TextChanged += SearchTxtBx_TextChanged;
                searchPnl.Controls.Add(searchTxtBx);
            }
        }

        private void SearchTxtBx_TextChanged(object? sender, string text)
        {
            currentPage = 1;
            _accountsToDisplay = _accounts
                .Where(a => a.Name.Contains
                (
                    text, StringComparison.CurrentCultureIgnoreCase)
                    || a.Login.Contains(text, StringComparison.CurrentCultureIgnoreCase)
                ).ToList();

            OpenCurrentPage();
        }

        private async Task InitAccounts()
        {
            _accounts = await _mediator.Send
            (
                new GetAccountsByResourceIdRequest(_resourceId, _userContext.UserId)
            );
            _accountsToDisplay = _accounts;

            if (_accounts.Count == 0)
            {
                AccsFLPnl.Controls.Clear();
                var noAccountsLbl = new Label
                {
                    AutoSize = true,
                    Text = "Список аккаунтов пуст"
                };
                AccsFLPnl.Controls.Add(noAccountsLbl);
            }
            else
            {
                UpdateUIWithAccounts();
                UpdatePaginationPnl();
            }
            CheckScrollVisibility();
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
            for (int i = accountStartId; i <= lastAccountIdOnPage && i < _accountsToDisplay.Count; i++)
            {
                var account = _accountsToDisplay.ElementAt(i);

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

                var bookmarkBtn = new Button
                {
                    Parent = accountPnl,
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(nameLbl.Right, nameLbl.Top),
                    Size = new Size(btnWidth, nameLbl.Height)
                };
                using (var stream = new MemoryStream(Resources.AddBookmark16))
                {
                    bookmarkBtn.Image = Image.FromStream(stream);
                }
                bookmarkBtn.FlatAppearance.BorderSize = 0;
                bookmarkBtn.Tag = account;
                bookmarkBtn.Click += BookmarkBtn_Click;
                accountPnl.Controls.Add(bookmarkBtn);

                var updateBtn = new Button
                {
                    Parent = accountPnl,
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(bookmarkBtn.Right, nameLbl.Top),
                    Image = Resources.Edit16,
                    Size = new Size(btnWidth, nameLbl.Height),
                    Tag = account.Id
                };
                updateBtn.FlatAppearance.BorderSize = 0;
                updateBtn.Click += UpdateBtn_Click;
                accountPnl.Controls.Add(updateBtn);

                var deleteBtn = new Button
                {
                    Parent = accountPnl,
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(updateBtn.Right, nameLbl.Top),
                    Image = Resources.Delete16,
                    Size = new Size(btnWidth, nameLbl.Height),
                    Tag = account.Id
                };
                deleteBtn.Click += DeleteBtn_Click;
                deleteBtn.FlatAppearance.BorderSize = 0;
                accountPnl.Controls.Add(deleteBtn);

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
                passwordCopyBtn.Click += PasswordCopyBtn_ClickAsync;
                passwordPnl.Controls.Add(passwordCopyBtn);

                var passwordEyeBtn = new Button
                {
                    Parent = passwordPnl,
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(passwordCopyBtn.Right, passwordCopyBtn.Top),
                    Size = new Size(btnWidth, passwordCopyBtn.Height),
                    Image = Resources.Eye24,
                    Tag = passwordValueLbl
                };
                passwordEyeBtn.FlatAppearance.BorderSize = 0;
                passwordEyeBtn.Click += PasswordEyeBtn_Click;
                passwordPnl.Controls.Add(passwordEyeBtn);

                passwordValueLbl.Resize += (sender, e) =>
                {
                    passwordCopyBtn.Left = passwordValueLbl.Right;
                    passwordEyeBtn.Left = passwordCopyBtn.Right;
                };

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

            if (maxPageCount <= 1)
            {
                return;
            }

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
            if (AccsFLPnl.Height > Height - HEADER_HEIGHT)
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

        private async void BookmarkBtn_Click(object? sender, EventArgs e)
        {
            if (sender is Button bookmarkBtn)
            {
                if (bookmarkBtn.Tag is GetAccountsByResourceIdResponse account)
                {
                    byte[] bookmarkImage;

                    if (account.IsBookmarked)
                    {
                        bookmarkImage = await DeleteUserAccountBookmark(account.Id);
                    }
                    else
                    {
                        bookmarkImage = await CreateUserAccountBookmark(account.Id);
                    }
                    account.IsBookmarked = !account.IsBookmarked;

                    using (var imageStream = new MemoryStream(bookmarkImage))
                    {
                        bookmarkBtn.Image = Image.FromStream(imageStream);
                    }
                }
            }
        }

        private async Task<byte[]> CreateUserAccountBookmark(int accountId)
        {
            await _mediator.Send
            (
                new CreateUserAccountBookmarkRequest(_userContext.UserId, accountId)
            );

            return Resources.DeleteBookmark16;
        }

        private async Task<byte[]> DeleteUserAccountBookmark(int accountId)
        {
            return Resources.AddBookmark16;
        }

        private void UpdateBtn_Click(object? sender, EventArgs e)
        {
            if (sender == null)
            {
                return;
            }

            var updateBtn = sender as Button;
            var isId = int.TryParse(updateBtn?.Tag.ToString(), out int id);
            if (!isId)
            {
                return;
            }

            var account = _accounts.FirstOrDefault(a => a.Id == id);
            if (account == null)
            {
                return;
            }

            var updateForm = _formFactory.CreateUpdateAccountForm(account);
            this.ShowWithinIndex(updateForm, "Редактирование аккаунта");
        }

        private async void DeleteBtn_Click(object? sender, EventArgs e)
        {
            if (sender == null)
            {
                return;
            }

            var deleteBtn = sender as Button;
            int accountId = int.Parse(deleteBtn.Tag.ToString());

            var deleteDialogForm = _formFactory.CreateDeleteAccountDialogForm(accountId);
            if (deleteDialogForm.ShowDialog() == DialogResult.OK)
            {
                await InitAccounts();
            }
        }

        private void LoginCopyBtn_Click(object? sender, EventArgs e)
        {
            if (sender is not null)
            {
                var button = sender as Button;
                Clipboard.SetText(button?.Tag?.ToString());
            }
        }

        private async void PasswordCopyBtn_ClickAsync(object? sender, EventArgs e)
        {
            if (sender is not null)
            {
                var button = sender as Button;

                var plainTextResult = await _mediator.Send
                (
                    new AesDecryptRequest(button?.Tag?.ToString())
                );
                string plainText = plainTextResult.PlainText;
                Clipboard.SetText(plainText);
            }
        }

        private async void PasswordEyeBtn_Click(object? sender, EventArgs e)
        {
            var button = sender as Button;
            if (button is not null)
            {
                var passwordValueLbl = button.Tag as Label;

                if (passwordValueLbl != null)
                {
                    if (passwordValueLbl.Text == PASSWORD_CHAR)
                    {
                        await SetDecryptedPasswordValueLbl(passwordValueLbl);
                        button.Image = Resources.EyeHidden24;
                    }
                    else
                    {
                        SetEncryptedPasswordValueLbl(passwordValueLbl);
                        button.Image = Resources.Eye24;
                    }
                }
            }
        }

        private async Task SetDecryptedPasswordValueLbl(Label passwordValueLbl)
        {
            var plainText = await _mediator.Send
            (
                new AesDecryptRequest(passwordValueLbl.Tag?.ToString())
            );

            passwordValueLbl.Text = plainText.PlainText;
        }

        private void SetEncryptedPasswordValueLbl(Label passwordValueLbl)
        {
            passwordValueLbl.Text = PASSWORD_CHAR;
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
            this.ShowWithinIndex(createForm, "Добавление аккаунта");
        }
    }
}