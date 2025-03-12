using AccountManager.Application.Context;
using AccountManager.Application.Features.Auth.GetById;
using AccountManager.Application.Features.UserAccountBookmark.GetByUserId;
using AccountManagerWinForm.Extensions;
using AccountManagerWinForm.Factories;
using AccountManagerWinForm.Forms.Common.Elements.List;
using AccountManagerWinForm.Properties;
using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountManagerWinForm.Forms.Welcome
{
    public partial class WelcomeForm : Form
    {
        private readonly IMediator _mediator;
        private readonly IFormFactory _formFactory;
        private readonly UserContext _userContext;

        private ICollection<GetBookmarkedAccountsByUserIdResponse> userAccountBookmarks;

        public WelcomeForm(IMediator mediator, IFormFactory formFactory, UserContext userContext)
        {
            InitializeComponent();
            _mediator = mediator;
            _formFactory = formFactory;
            _userContext = userContext;

            userAccountBookmarks = [];
        }

        protected async override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            await InitializeHeaderUserLoginLblAsync();
            await InitializeUserAccountBookmarksAsync();
        }

        private async Task InitializeHeaderUserLoginLblAsync()
        {
            var user = await _mediator.Send(new GetUserByIdRequest(_userContext.UserId));
            HeaderUserLoginLbl.Text = user.Login;
            int headerLblsWidth = HeaderWelcomeLbl.Width + HeaderUserLoginLbl.Width;
            HeaderWelcomeLbl.Left = (HeaderPnl.Width - headerLblsWidth) / 2;
            HeaderUserLoginLbl.Left = HeaderWelcomeLbl.Right;
        }

        private async Task InitializeUserAccountBookmarksAsync()
        {
            userAccountBookmarks = await _mediator.Send
            (
                new GetBookmarkedAccountsByUserIdRequest()
            );

            DisplayUserAccountBookmarks();
        }

        private void DisplayUserAccountBookmarks()
        {
            if (userAccountBookmarks.Count > 0)
            {
                var containerPnl = UserAccountBookmarksPnl;

                foreach (var bookmark in userAccountBookmarks)
                {
                    var pnl = new AccountItemPanel(bookmark.Id, bookmark.Name, bookmark.Login, bookmark.Password, true)
                    {
                        Width = containerPnl.Width,
                        Dock = DockStyle.Top
                    };
                    containerPnl.Controls.Add(pnl);
                }

                var headerPnl = new Panel
                {
                    Height = 40,
                    Dock = DockStyle.Top
                };
                containerPnl.Controls.Add(headerPnl);
                var headerLbl = new Label
                {
                    Image = Resources.DeleteBookmark24,
                    ImageAlign = ContentAlignment.MiddleLeft,
                    Text = "Закладки",
                    Width = 150,
                    TextAlign = ContentAlignment.MiddleCenter,
                };
                headerPnl.Controls.Add(headerLbl);
            }
        }

        private void CreateResBtn_Click(object sender, EventArgs e)
        {
            Program.IndexForm.LocateActivePnlToResources();
            var createResForm = _formFactory.CreateCreateResourceForm();
            this.ShowWithinIndex(createResForm, "Создать ресурс");
        }
    }
}
