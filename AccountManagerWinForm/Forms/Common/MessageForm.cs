using System;
using System.Windows.Forms;

namespace AccountManagerWinForm.Forms.Common
{
    public partial class MessageForm : Form
    {
        public MessageForm()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, EventArgs e) => Close();

        private void OkBtn_Click(object sender, EventArgs e) => Close();
    }
}
