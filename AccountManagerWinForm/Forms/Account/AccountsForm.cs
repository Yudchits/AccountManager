using AccountManager.Application.Context;
using AccountManager.Application.Features.Account.GetByResourceId;
using AccountManager.Application.Features.UserAccountBookmark.CheckCount;
using AccountManager.Application.Features.UserAccountBookmark.Create;
using AccountManager.Application.Features.UserAccountBookmark.Delete;
using AccountManagerWinForm.Extensions;
using AccountManagerWinForm.Factories;
using AccountManagerWinForm.Forms.Common.Elements.List;
using AccountManagerWinForm.Forms.Common.Elements.Mat;
using AccountManagerWinForm.Properties;
using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountManagerWinForm.Forms.Account
{
    public partial class AccountsForm : Form
    {
        private bool isFormLoaded = false;

        private const int ACCOUNTS_ON_PAGE = 6;
        private const int HEADER_HEIGHT = 60;

        private readonly int _resourceId;
        private readonly IMediator _mediator;
        private readonly IFormFactory _formFactory;
        private readonly UserContext _userContext;

        private ICollection<GetAccountsByResourceIdResponse> _accounts;
        private ICollection<GetAccountsByResourceIdResponse> _accountsToDisplay;

        private bool isDragging = false;
        private int initialMouseY;
        private readonly int maxMouseY;

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

            isFormLoaded = true;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (isFormLoaded)
            {
                ScrollPnl.Location = new Point(Width - ScrollPnl.Width, 0);
            }
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
            CheckPaginationPnl();
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
                PaginationPnl.Visible = false;
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
                CheckPaginationPnl();
            }
            CheckScrollVisibility();
        }

        private void UpdateUIWithAccounts()
        {
            AccsFLPnl.Controls.Clear();
            AccsFLPnl.Height = 0;

            int lastAccountIdOnPage = currentPage * ACCOUNTS_ON_PAGE - 1;
            int accountStartId = lastAccountIdOnPage - ACCOUNTS_ON_PAGE + 1;
            for (int i = accountStartId; i <= lastAccountIdOnPage && i < _accountsToDisplay.Count; i++)
            {
                var account = _accountsToDisplay.ElementAt(i);

                var accountPnl = new AccountItemPanel
                (
                    account.Id,
                    account.Name,
                    account.Login,
                    account.Password,
                    account.IsBookmarked
                )
                {
                    Width = AccsFLPnl.Width,
                    Dock = DockStyle.Top
                };

                var bookmarkBtn = new Button
                {
                    FlatStyle = FlatStyle.Flat,
                    Image = account.IsBookmarked
                        ? Resources.DeleteBookmark16
                        : Resources.AddBookmark16
                };
                bookmarkBtn.FlatAppearance.BorderSize = 0;
                bookmarkBtn.Tag = account;
                bookmarkBtn.Click += BookmarkBtn_Click;

                var updateBtn = new Button
                {
                    FlatStyle = FlatStyle.Flat,
                    Image = Resources.Edit16,
                    Tag = account.Id
                };
                updateBtn.FlatAppearance.BorderSize = 0;
                updateBtn.Click += UpdateBtn_Click;

                var deleteBtn = new Button
                {
                    FlatStyle = FlatStyle.Flat,
                    Image = Resources.Delete16,
                    Tag = account.Id
                };
                deleteBtn.Click += DeleteBtn_Click;
                deleteBtn.FlatAppearance.BorderSize = 0;
                
                accountPnl.AddButton(deleteBtn);
                accountPnl.AddButton(updateBtn);
                accountPnl.AddButton(bookmarkBtn);

                AccsFLPnl.Height += accountPnl.Height + 3;
                AccsFLPnl.Controls.Add(accountPnl);
            }
        }

        private void CheckPaginationPnl()
        {
            double countDouble = (double)_accountsToDisplay.Count / ACCOUNTS_ON_PAGE;
            maxPageCount = (int)Math.Floor(Math.Ceiling(countDouble));

            if (maxPageCount <= 1)
            {
                PaginationPnl.Visible = false;
            }
            else
            {
                PaginationPnl.Visible = true;
                SetCurrentPageNumber();
            }
        }

        private void SetCurrentPageNumber()
        {
            if (PaginationPnl.Visible)
            {
                PageNumberLbl.Text = $"{currentPage} из {maxPageCount}";
            }
        } 

        private void NextPageBtn_Click(object? sender, EventArgs e)
        {
            currentPage = currentPage < maxPageCount ? currentPage + 1 : 1;
            OpenCurrentPage();
        }

        private void OpenCurrentPage()
        {
            ScrollAccountsFLPnl(-ScrollPnl.Top);
            UpdateUIWithAccounts();
            CheckScrollVisibility();
            SetCurrentPageNumber();
        }

        private void CheckScrollVisibility()
        {
            if (AccsFLPnl.Height > Height - HEADER_HEIGHT)
            {
                if (!ScrollPnl.Visible)
                {
                    MouseWheel += AccountsForm_MouseWheel;
                    ScrollPnl.Visible = true;
                }
            }
            else
            {
                MouseWheel -= AccountsForm_MouseWheel;
                ScrollPnl.Visible = false;
            }
        }

        private void PreviousPageBtn_Click(object? sender, EventArgs e)
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
                    Bitmap bookmarkImage;

                    if (account.IsBookmarked)
                    {
                        bookmarkImage = await DeleteUserAccountBookmark(account.Id);
                    }
                    else
                    {
                        await CheckUserAccountBookmarkCount();
                        bookmarkImage = await CreateUserAccountBookmark(account.Id);
                    }
                    account.IsBookmarked = !account.IsBookmarked;

                    bookmarkBtn.Image = bookmarkImage;
                }
            }
        }

        private async Task CheckUserAccountBookmarkCount()
        {
            await _mediator.Send(new CheckUserAccountBookmarkCountRequest());
        }

        private async Task<Bitmap> CreateUserAccountBookmark(int accountId)
        {
            await _mediator.Send
            (
                new CreateUserAccountBookmarkRequest(_userContext.UserId, accountId)
            );

            return Resources.DeleteBookmark16;
        }

        private async Task<Bitmap> DeleteUserAccountBookmark(int accountId)
        {
            await _mediator.Send
            (
                new DeleteUserAccountBookmarkRequest(_userContext.UserId, accountId)
            );

            return Resources.AddBookmark16;
        }

        private void UpdateBtn_Click(object? sender, EventArgs e)
        {
            var updateBtn = sender as Button;
            int id = int.Parse(updateBtn.Tag.ToString());

            var account = _accounts.First(a => a.Id == id);
            var updateForm = _formFactory.CreateUpdateAccountForm(account);
            this.ShowWithinIndex(updateForm, "Редактирование аккаунта");
        }

        private async void DeleteBtn_Click(object? sender, EventArgs e)
        {
            var deleteBtn = sender as Button;
            int accountId = int.Parse(deleteBtn.Tag.ToString());

            var deleteDialogForm = _formFactory.CreateDeleteAccountDialogForm(accountId);
            if (deleteDialogForm.ShowDialog() == DialogResult.OK)
            {
                await InitAccounts();
            }
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