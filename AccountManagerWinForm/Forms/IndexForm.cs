using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using Microsoft.Extensions.DependencyInjection;
using AccountManagerWinForm.Forms.Resource;

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
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        private void CloseBtn_Click(object sender, EventArgs e) => Application.Exit();

        private void Btn_ToMain_Click(object sender, EventArgs e)
        {
            ActivePnl.Location = new Point(0, Btn_ToMain.Location.Y);
            ActiveFormNameLbl.Text = "Главная";
            BodyPnl.Controls.Clear();
        }

        private void Btn_ToResources_Click(object sender, EventArgs e)
        {
            ActivePnl.Location = new Point(0, Btn_ToResources.Location.Y);
            ActiveFormNameLbl.Text = "Ресурсы";
            BodyPnl.Controls.Clear();
            var resourcesForm = Program.ServiceProvider?.GetRequiredService<ResourcesForm>();
            if (resourcesForm != null)
            {
                resourcesForm.TopLevel = false;
                resourcesForm.TopMost = true;
                resourcesForm.Dock = DockStyle.Fill;
                BodyPnl.Controls.Add(resourcesForm);
                resourcesForm.Show();
            }
        }

        private void Btn_ToSettings_Click(object sender, EventArgs e)
        {
            ActivePnl.Location = new Point(0, Btn_ToSettings.Location.Y);
            ActiveFormNameLbl.Text = "Настройки";
            BodyPnl.Controls.Clear();
        }
    }
}