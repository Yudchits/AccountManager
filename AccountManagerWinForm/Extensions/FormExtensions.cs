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
    }
}