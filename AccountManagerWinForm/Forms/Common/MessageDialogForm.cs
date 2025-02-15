using AccountManager.Application.Common;
using AccountManagerWinForm.Properties;
using Microsoft.Extensions.Logging;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AccountManagerWinForm.Forms.Common
{
    public partial class MessageDialogForm : Form
    {
        private readonly string _message;
        private readonly MessageType _type;
        private readonly ILogger<MessageDialogForm> _logger;

        public Label MessageLbl { get; private set; }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        public MessageDialogForm(string message, MessageType type, ILogger<MessageDialogForm> logger)
        {
            InitializeComponent();

            int messageLblGrowth = 16;
            MessageLbl = new Label
            {
                Width = Width - TypePctrBx.Width - (TypePctrBx.Left * 2),
                ForeColor = Color.FromArgb(158, 161, 176),
                BackColor = BackColor,
                Height = TypePctrBx.Height + messageLblGrowth,
                BorderStyle = BorderStyle.None,
                Cursor = Cursors.Default,
                TextAlign = ContentAlignment.MiddleLeft
            };
            MessageLbl.Location = new Point
            (
                Width - MessageLbl.Width - TypePctrBx.Left, 
                TypePctrBx.Top - (messageLblGrowth / 2)
            );
            Controls.Add(MessageLbl);

            _message = message;
            _type = type;
            _logger = logger;
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            MessageLbl.Text = _message.Length > 87
                ? string.Concat(_message.Substring(0, 87), "...")
                : _message;

            if (_type == MessageType.ERROR)
            {
                TypePctrBx.Image = Resources.Error24;
                _logger.LogError(_message);
            }
            else
            {
                TypePctrBx.Image = Resources.Warn24;
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e) => Close();

        private void OkBtn_Click(object sender, EventArgs e) => Close();
    }
}