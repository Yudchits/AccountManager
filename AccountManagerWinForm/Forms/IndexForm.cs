using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using AccountManagerWinForm.Factories;
using AccountManagerWinForm.Extensions;

namespace AccountManagerWinForm.Forms
{
    public partial class IndexForm : Form
    {
        private readonly IFormFactory _formFactory;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        public IndexForm(IFormFactory formFactory)
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            ActivePnl.BringToFront();

            _formFactory = formFactory;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            OpenWelcomeForm();
        }

        private void OpenWelcomeForm()
        {
            var welcomeForn = _formFactory.CreateWelcomeForm();
            this.ShowWithinIndex(welcomeForn, "Главная");
        }

        private void CloseBtn_Click(object sender, EventArgs e) => Application.Exit();

        private void Btn_ToWelcome_Click(object sender, EventArgs e)
        {
            ActivePnl.Location = new Point(0, Btn_ToWelcome.Location.Y);
            OpenWelcomeForm();
        }

        private void Btn_ToResources_Click(object sender, EventArgs e)
        {
            LocateActivePnlToResources();
            var resourcesForm = _formFactory.CreateResourcesForm();
            this.ShowWithinIndex(resourcesForm, "Ресурсы");
        }

        public void LocateActivePnlToResources()
        {
            ActivePnl.Location = new Point(0, Btn_ToResources.Location.Y);
        }

        private void Btn_ToSettings_Click(object sender, EventArgs e)
        {
            ActivePnl.Location = new Point(0, Btn_ToSettings.Location.Y);
            ActiveFormNameLbl.Text = "Настройки";
            BodyPnl.Controls.Clear();
        }

        private void MinimizeBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}