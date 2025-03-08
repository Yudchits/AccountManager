using AccountManagerWinForm.Forms.Common.Elements.Mat.Common;
using AccountManagerWinForm.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AccountManagerWinForm.Forms.Common.Elements.Mat
{
    public class MatPictureBox : Panel, IMatControl
    {
        private readonly PictureBox imagePctrBx;
        private readonly Label noImgLbl;
        private readonly Label errorLbl;

        private Color errorColor = Color.FromArgb(255, 0, 0);
        private Color borderColor = Color.FromArgb(158, 161, 176);
        private Font font = new Font("Cascadia Code", 12f);

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
            imagePctrBx.Click += ImagePctrBx_Click;
            imagePctrBx.Paint += ImagePctrBx_Paint;
            Controls.Add(imagePctrBx);

            noImgLbl = new Label
            {
                Parent = imagePctrBx,
                Width = 40,
                Height = 40,
                ImageAlign = ContentAlignment.MiddleCenter
            };
            
            using (var stream = new MemoryStream(Resources.AddImg24))
            {
                noImgLbl.Image = Image.FromStream(stream);
            }
            noImgLbl.BringToFront();
            noImgLbl.Click += ImagePctrBx_Click;
            imagePctrBx.Controls.Add(noImgLbl);

            errorLbl = new Label
            {
                AutoSize = true,
                Dock = DockStyle.Bottom,
                Padding = new Padding(0)
            };
            Controls.Add(errorLbl);
        }

        private void ImagePctrBx_Click(object? sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.InitialDirectory = "C:\\";
                dialog.Filter = "Изображения (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                dialog.Title = "Выберите изображение";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    noImgLbl.Visible = false;

                    using (var tempImage = Image.FromFile(dialog.FileName))
                    {
                        imagePctrBx.Image?.Dispose();
                        imagePctrBx.Image = new Bitmap(tempImage);
                        imagePctrBx.ImageLocation = dialog.FileName;
                    }
                }
            }
        }

        private void ImagePctrBx_Paint(object? sender, PaintEventArgs e)
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
            errorLbl.Font = new Font(font.Name, (float)(font.Size * 0.9));

            noImgLbl.Location = new Point
            (
                x: (imagePctrBx.Width / 2) - (noImgLbl.Width / 2),
                y: (imagePctrBx.Height / 2) - (noImgLbl.Height / 2)
            );
        }
    }
}