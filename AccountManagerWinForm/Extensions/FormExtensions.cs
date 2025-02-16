using AccountManagerWinForm.Forms;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace AccountManagerWinForm.Extensions
{
    public static class FormExtensions
    {
        public static void SetDoubleBuffered(this Control control, bool value)
        {
            var property = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
            property?.SetValue(control, value, null);
        }

        public static void ShowWithinIndex(this Form currentForm, Form newForm, string activeLbl)
        {
            var indexForm = Program.IndexForm;

            if (indexForm == null)
            {
                throw new InvalidOperationException("Не удалось найти IndexForm");
            }

            indexForm.SearchPnl.Controls.Clear();
            indexForm.BodyPnl.Controls.Clear();
            indexForm.ActiveFormNameLbl.Text = activeLbl;

            newForm.TopLevel = false;
            newForm.TopMost = true;
            newForm.Dock = DockStyle.Fill;

            indexForm.BodyPnl.Controls.Add(newForm);
            newForm.Show();
        }
    }
}