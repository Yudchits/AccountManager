using AccountManager.Application.Common;
using AccountManagerWinForm.Properties;
using Microsoft.Extensions.Logging;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AccountManagerWinForm.Forms.Common
{
    public partial class MessageForm : Form
    {
        private readonly string _message;
        private readonly MessageType _type;
        private readonly ILogger<MessageForm>? _logger;

        public Label MessageLbl { get; private set; }

        public MessageForm(string message, MessageType type, ILogger<MessageForm> logger)
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
            MessageLbl.Text = _message.Length > 87
                ? string.Concat(_message.Substring(0, 87), "...")
                : _message;

            if (_type == MessageType.ERROR)
            {
                TypePctrBx.Image = Resources.Error24;
                _logger?.LogError(_message);
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