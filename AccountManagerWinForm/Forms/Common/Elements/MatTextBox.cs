using System;
using System.Drawing;
using System.Windows.Forms;

namespace AccountManagerWinForm.Forms.Common.Elements
{
    public class MatTextBox : Panel
    {
        private readonly Label label;
        private readonly TextBox textBox;
        private readonly Panel panel;
        private readonly Label error;

        private Color activeColor = Color.FromArgb(0, 180, 249);
        private Color foreColor = Color.FromArgb(158, 161, 176);
        private Color backColor = Color.FromArgb(46, 51, 73);
        private Color errorColor = Color.FromArgb(255, 0, 0);
        private Font font = new Font("Cascadia Code", 12f);

        public new event EventHandler<string> TextChanged;

        public string Label
        {
            get { return label.Text; }
            set { label.Text = value; }
        }

        public override string Text
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }

        public override Color ForeColor
        {
            get { return foreColor; }
            set
            {
                foreColor = value;
                label.ForeColor = value;
                panel.BackColor = value;
            }
        }

        public Color ActiveColor
        {
            get { return activeColor; }
            set { activeColor = value; }
        }

        public char PasswordChar
        {
            get { return textBox.PasswordChar; }
            set { textBox.PasswordChar = value; }
        }

        public override Font Font {
            get
            {
                return font;
            }
            set
            {
                font = value;
                label.Font = value;
                textBox.Font = value;
            }
        }

        public override Color BackColor
        {
            get
            {
                return backColor;
            }
            set
            {
                backColor = value;
                textBox.BackColor = value;
            }
        }

        public string Error { 
            get 
            {
                return error.Text;
            } 
            set
            {
                var color = string.IsNullOrEmpty(value)
                    ? foreColor
                    : errorColor;

                label.ForeColor = color;
                textBox.ForeColor = color;
                panel.BackColor = color;
                error.Text = value;
            }
        }

        public MatTextBox()
        {
            label = new Label
            {
                AutoSize = true,
                Cursor = Cursors.IBeam,
                Padding = new Padding(0),
                Margin = new Padding(0),
            };
            label.Click += Label_Click;
            Controls.Add(label);

            textBox = new TextBox
            {
                Width = Width,
                BorderStyle = BorderStyle.None,
                BackColor = Color.FromArgb(46, 51, 73),
                Margin = new Padding(0),
                ForeColor = foreColor,
                Font = new Font("Cascadia Code", 12f)
            };
            textBox.TextChanged += TextBox_TextChanged;
            textBox.GotFocus += TextBox_GotFocus;
            textBox.LostFocus += TextBox_LostFocus;
            Controls.Add(textBox);

            panel = new Panel
            {
                Width = Width,
                Height = 3,
                BackColor = foreColor,
                Margin = new Padding(0),
            };
            Controls.Add(panel);
            
            error = new Label
            {
                AutoSize = true,
                Font = new Font(Font.Name, (float)(font.Size * 0.9)),
                ForeColor = errorColor
            };
            Controls.Add(error);

            Height = label.Height 
                + textBox.Height 
                + panel.Height
                + error.Height;

            label.Location = new Point(-5, label.Height);
            textBox.Location = new Point(0, label.Height);
            panel.Location = new Point(0, textBox.Bottom);
            error.Location = new Point(-5, panel.Bottom);
        }

        private void Label_Click(object? sender, EventArgs e)
        {
            textBox.Focus();
        }

        private void TextBox_TextChanged(object? sender, EventArgs e)
        {
            TextChanged?.Invoke(this, textBox.Text);
            CheckLabelLocation();
        }

        private void TextBox_LostFocus(object? sender, EventArgs e)
        {
            label.ForeColor = foreColor;
            CheckLabelLocation();
            textBox.ForeColor = foreColor;
            panel.BackColor = foreColor;
            OnLostFocus(EventArgs.Empty);
        }

        private void CheckLabelLocation()
        {
            int labelTop = textBox.Text.Length > 0 || textBox.Focused ? 0 : label.Height;
            label.Location = new Point(label.Left, labelTop);
        }

        private void TextBox_GotFocus(object? sender, EventArgs e)
        {
            error.Text = string.Empty;
            label.ForeColor = activeColor;
            CheckLabelLocation();
            textBox.ForeColor = activeColor;
            panel.BackColor = activeColor;
            OnGotFocus(EventArgs.Empty);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            textBox.Width = Width;
            textBox.Multiline = true;
            textBox.MinimumSize = new Size(0, label.Height);
            textBox.Multiline = false;
            textBox.Font = Font;
            textBox.BackColor = BackColor;
            panel.Width = Width;
            error.Font = new Font(Font.Name, (float)(font.Size * 0.85));
            
            label.Location = new Point(label.Left, label.Height);
            textBox.Location = new Point(textBox.Left, label.Height);
            panel.Location = new Point(panel.Left, textBox.Bottom);
            error.Location = new Point(error.Left, panel.Bottom);

            label.ForeColor = foreColor;
            panel.BackColor = foreColor;
            Height = label.Height
                + textBox.Height
                + panel.Height
                + error.Height;
        }
    }
}