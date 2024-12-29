using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;

namespace AccountManagerWinForm.Forms
{
    public partial class IndexForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        public IndexForm()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        private void Index_Load(object sender, EventArgs e)
        {

        }

        private void CloseBtn_Click(object sender, EventArgs e) => Application.Exit();

        private void Btn_ToMain_Click(object sender, EventArgs e)
        {
            ActivePnl.Location = new Point(0, Btn_ToMain.Location.Y);
        }

        private void Btn_ToResources_Click(object sender, EventArgs e)
        {
            ActivePnl.Location = new Point(0, Btn_ToResources.Location.Y);
        }

        private void Btn_ToSettings_Click(object sender, EventArgs e)
        {
            ActivePnl.Location = new Point(0, Btn_ToSettings.Location.Y);
        }
    }
}
