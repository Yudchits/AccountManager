using System;
using System.Windows.Forms;

namespace AccountManagerWinForm.Forms.Common
{
    public partial class MessageForm : Form
    {
        public string Message
        {
            set 
            {
                var message = value.Length > 64 ? string.Concat(value.Substring(0, 64), "...") : value;
                MessageTextBox.Text = string.Concat(message);
            }
        }

        public MessageForm()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, EventArgs e) => Close();

        private void OkBtn_Click(object sender, EventArgs e) => Close();
    }
}
