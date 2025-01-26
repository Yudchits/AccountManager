using System.Drawing;
using System.Windows.Forms;

namespace AccountManagerWinForm.Forms.Common.Elements
{
    public class MatPictureBox : PictureBox
    {
        private Color borderColor;
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, borderColor, ButtonBorderStyle.Solid);
        }
    }
}