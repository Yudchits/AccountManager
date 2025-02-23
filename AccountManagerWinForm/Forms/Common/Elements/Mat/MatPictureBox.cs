using AccountManagerWinForm.Forms.Common.Elements.Mat.Common;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AccountManagerWinForm.Forms.Common.Elements.Mat
{
    public class MatPictureBox : Panel, IMatControl
    {
        private readonly PictureBox imagePctrBx;
        private readonly Label errorLbl;

        private Color errorColor = Color.FromArgb(255, 0, 0);
        private Color borderColor = Color.FromArgb(158, 161, 176);
        private Font font = new Font("Cascadia Code", 10f);

        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                borderColor = value;
                imagePctrBx.Invalidate();
            }
        }

        public string Error
        {
            get
            {
                return errorLbl.Text;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    errorLbl.Text = string.Empty;
                    BorderColor = borderColor;
                }
                else
                {
                    errorLbl.Text = value;
                    errorLbl.ForeColor = errorColor;
                    BorderColor = errorColor;
                }
            }
        }

        public Image Image
        {
            get
            {
                return imagePctrBx.Image;
            }
            set
            {
                imagePctrBx.Image = value;
            }
        }

        public string ImageLocation
        {
            get
            {
                return imagePctrBx.ImageLocation;
            }
            set
            {
                imagePctrBx.ImageLocation = value;
            }
        }

        public MatPictureBox()
        {
            imagePctrBx = new PictureBox
            {
                BorderStyle = BorderStyle.None,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Dock = DockStyle.Fill,
                Cursor = Cursors.Hand,
                Padding = new Padding(0)
            };
            imagePctrBx.Click += (sender, e) => OnClick(e);
            imagePctrBx.Paint += ImagePctrBx_Paint;
            Controls.Add(imagePctrBx);

            errorLbl = new Label
            {
                AutoSize = true,
                Dock = DockStyle.Bottom,
                Padding = new Padding(0, 5, 0, 0),
                Font = new Font(Font.Name, (float)(font.Size * 0.9)),
            };
            Controls.Add(errorLbl);
        }

        private void ImagePctrBx_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(
                e.Graphics,
                imagePctrBx.ClientRectangle,
                borderColor,
                ButtonBorderStyle.Solid
            ); ;
        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            errorLbl.Font = font;
        }
    }
}