using AccountManager.Application.Context;
using AccountManager.Application.Features.Auth.GetById;
using AccountManagerWinForm.Extensions;
using AccountManagerWinForm.Factories;
using MediatR;
using System;
using System.Windows.Forms;

namespace AccountManagerWinForm.Forms.Welcome
{
    public partial class WelcomeForm : Form
    {
        private readonly IMediator _mediator;
        private readonly IFormFactory _formFactory;
        private readonly UserContext _userContext;

        public WelcomeForm(IMediator mediator, IFormFactory formFactory, UserContext userContext)
        {
            InitializeComponent();
            _mediator = mediator;
            _formFactory = formFactory;
            _userContext = userContext;
        }

        protected async override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var user = await _mediator.Send(new GetUserByIdRequest(_userContext.UserId));
            HeaderUserLoginLbl.Text = user.Login;
            int headerLblsWidth = HeaderWelcomeLbl.Width + HeaderUserLoginLbl.Width;
            HeaderWelcomeLbl.Left = (HeaderPnl.Width - headerLblsWidth) / 2;
            HeaderUserLoginLbl.Left = HeaderWelcomeLbl.Right;
        }

        private void CreateResBtn_Click(object sender, EventArgs e)
        {
            Program.IndexForm.LocateActivePnlToResources();
            var createResForm = _formFactory.CreateCreateResourceForm();
            this.ShowWithinIndex(createResForm, "Создать ресурс");
        }
    }
}
