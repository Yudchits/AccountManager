using AccountManager.Application.Features.Account.Delete;
using MediatR;
using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;

namespace AccountManagerWinForm.Forms.Account
{
    public partial class DeleteAccountDialogForm : Form
    {
        private readonly int _accountId;
        private readonly IMediator _mediator;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        public DeleteAccountDialogForm(int accountId, IMediator mediator)
        {
            InitializeComponent();

            _accountId = accountId;
            _mediator = mediator;
        }

        private void DeleteAccountDialogForm_Load(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.None;
            Close();
        }

        private async void DeleteBtn_Click(object sender, EventArgs e)
        {
            await _mediator.Send(new DeleteAccountRequest(_accountId));
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}