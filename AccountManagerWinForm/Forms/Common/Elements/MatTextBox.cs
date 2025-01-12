using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace AccountManagerWinForm.Forms.Common.Elements
{
    public class MatTextBox : Panel
    {
        private readonly TextBox textBox;
        private readonly Panel panel;
        
        private Color activeColor = Color.FromArgb(0, 180, 249);
        private Color foreColor = Color.FromArgb(158, 161, 176);

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

        public string Placeholder
        {
            get { return textBox.PlaceholderText; }
            set { textBox.PlaceholderText = value; }
        }

        public char PasswordChar
        {
            get { return textBox.PasswordChar; }
            set { textBox.PasswordChar = value; }
        }

        public MatTextBox()
        {
            textBox = new TextBox
            {
                Width = Width,
                BorderStyle = BorderStyle.None,
                BackColor = Color.FromArgb(46, 51, 73),
                Margin = new Padding(0),
                Location = new Point(0, 0),
                ForeColor = foreColor,
                Font = Font
            };
            textBox.GotFocus += TextBox_GotFocus;
            textBox.LostFocus += TextBox_LostFocus;
            Controls.Add(textBox);

            /*textBox.Multiline = true;
            var size = TextRenderer.MeasureText(textBox.Text, textBox.Font, Size.Empty, TextFormatFlags.TextBoxControl);
            textBox.MinimumSize = new Size(0, size.Height);
            textBox.Multiline = false;*/

            int panelMarginTop = 1;
            int panelHeight = 3;
            panel = new Panel
            {
                Parent = this,
                Width = Width,
                Height = panelHeight,
                BackColor = Color.FromArgb(158, 161, 176),
                Margin = new Padding(0),
                Location = new Point(0, textBox.Bottom + panelHeight + panelMarginTop)
            };
            Controls.Add(panel);

            Height = textBox.Height + panel.Height + panelHeight + 30;
        }

        private void TextBox_LostFocus(object? sender, EventArgs e)
        {
            textBox.ForeColor = foreColor;
            panel.BackColor = foreColor;
        }

        private void TextBox_GotFocus(object? sender, EventArgs e)
        {
            textBox.ForeColor = activeColor;
            panel.BackColor = activeColor;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            textBox.Width = Width;
            textBox.Multiline = true;
            textBox.MinimumSize = new Size(0, textBox.Height);
            textBox.Multiline = false;
            textBox.Font = Font;
            panel.Width = Width;
        }
    }
}
