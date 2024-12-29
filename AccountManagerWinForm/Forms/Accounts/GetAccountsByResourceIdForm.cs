using AccountManager.Application.Features.Account.GetByResourceId;
using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountManagerWinForm.Forms.Accounts
{
    public partial class GetAccountsByResourceIdForm : Form
    {
        private readonly IMediator _mediator;

        public GetAccountsByResourceIdForm(IMediator mediator)
        {
            InitializeComponent();

            _mediator = mediator;
        }

        public async Task GetAccountsByResourceId(int resourceId)
        {
            var accounts = await _mediator.Send(new GetAccountsByResourceIdRequest(resourceId));
            DisplayAccounts(accounts);
        }

        private void DisplayAccounts(ICollection<GetAccountsByResourceIdResponse> accounts)
        {
            foreach (var account in accounts)
            {
                var panel = new Panel
                {
                    Width = AccountsFLP.Width,
                    Margin = new Padding(0, 0, 0, 10),
                    BorderStyle = BorderStyle.FixedSingle,
                };

                var nameLabel = new Label
                {
                    Text = account.Name,
                    Location = new Point(10, 10),
                    AutoSize = true
                };
                panel.Controls.Add(nameLabel);

                var loginLabel = new Label
                {
                    Text = $"Логин: {account.Login}",
                    Location = new Point(10, 40),
                    AutoSize = true
                };
                panel.Controls.Add(loginLabel);

                var passwordLabel = new Label
                {
                    Text = $"Пароль: {account.Password}",
                    Location = new Point(10, 70),
                    AutoSize = true
                };
                panel.Controls.Add(passwordLabel);

                AccountsFLP.Controls.Add(panel);
            }

            HideHorizontalScrollBar();
        }

        private void HideHorizontalScrollBar()
        {
            AccountsFLP.Width += SystemInformation.VerticalScrollBarWidth;
            AccountsFLP.Padding = new Padding
            {
                Left = 0,
                Top = 0,
                Right = SystemInformation.VerticalScrollBarWidth,
                Bottom = 0
            };
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
