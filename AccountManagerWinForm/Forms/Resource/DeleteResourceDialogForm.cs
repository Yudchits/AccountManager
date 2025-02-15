using MediatR;
using System.Runtime.InteropServices;
using System;
using System.Windows.Forms;
using System.Drawing;
using AccountManager.Application.Features.Resource.Delete;

namespace AccountManagerWinForm.Forms.Resource
{
    public partial class DeleteResourceDialogForm : Form
    {
        private readonly int _resourceId;
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

        public DeleteResourceDialogForm(int resourceId, IMediator mediator)
        {
            InitializeComponent();
            _resourceId = resourceId;
            _mediator = mediator;
        }

        private void DeleteResourceDialogForm_Load(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        private async void DeleteBtn_Click(object sender, EventArgs e)
        {
            await _mediator.Send(new DeleteResourceRequest(_resourceId));
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.None;
            Close();
        }
    }
}