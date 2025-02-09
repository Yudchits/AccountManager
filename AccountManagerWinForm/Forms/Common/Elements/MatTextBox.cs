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
        
        private Color activeColor = Color.FromArgb(0, 180, 249);
        private Color foreColor = Color.FromArgb(158, 161, 176);

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
                base.ForeColor = value; 
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
                BackColor = Color.FromArgb(158, 161, 176),
                Margin = new Padding(0),
            };
            Controls.Add(panel);

            Height = label.Height + textBox.Height + panel.Height;
            label.Location = new Point(-5, label.Height);
            textBox.Location = new Point(0, label.Height);
            panel.Location = new Point(0, textBox.Bottom);
        }

        private void Label_Click(object? sender, EventArgs e)
        {
            textBox.Focus();
        }

        private void TextBox_TextChanged(object? sender, EventArgs e)
        {
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
            textBox.Font = new Font("Cascadia Code", 12f);
            panel.Width = Width;
            
            label.Location = new Point(label.Left, label.Height);
            textBox.Location = new Point(textBox.Left, label.Height);
            panel.Location = new Point(panel.Left, textBox.Bottom);
            Height = label.Height + textBox.Height + panel.Height;
        }
    }
}
